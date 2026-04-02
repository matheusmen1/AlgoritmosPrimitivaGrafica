using ProcessamentoImagens.classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace ProcessamentoImagens
{
    public partial class frmPrincipal : Form
    {
        private Bitmap imageBitmap;

        private Point posInicial = new Point(-1, -1);
        private Point posFinal = new Point(-1, -1);
        private Point posFinalElipse = new Point(-1, -1);
        private Point posAnt = new Point(-1, -1);
        private Elipse elipseTemp = new Elipse();
        private Poligono poligonoTemp = new Poligono();

        // Listas para armazenar as primitivas gráficas
        private List<Reta> retas = new List<Reta>();
        private List<Circunferencia> circunferencias = new List<Circunferencia>();
        private List<Elipse> elipses = new List<Elipse>();
        private List<Poligono> poligonos = new List<Poligono>();

        // flags para estruturação de controle de desenho
        private bool addPoligono = false;
        private bool addReta = false;
        private bool addCirc = false;
        private bool addElipse = false;
        private bool add2Elipse = false;

        public frmPrincipal()
        {
            InitializeComponent();

            imageBitmap = new Bitmap(pictBoxImg1.ClientSize.Width, pictBoxImg1.ClientSize.Height, PixelFormat.Format24bppRgb);

            Filtros.ImagemBranca(imageBitmap);

            pictBoxImg1.SizeMode = PictureBoxSizeMode.Normal;
            pictBoxImg1.Image = imageBitmap;
            
            //definição do listView dos polígonos
            listViewPoligono.View = View.Details;
            listViewPoligono.HeaderStyle = ColumnHeaderStyle.None; // esconde o cabeçalho
            listViewPoligono.Columns.Add("", listViewPoligono.ClientSize.Width); // coluna ocupa tudo
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Filtros.ImagemBranca(imageBitmap);
            pictBoxImg1.Image = imageBitmap;
            pictBoxImg1.Refresh(); // força redesenho

            // tira seleção dos botões
            btnEquacaoReta.Checked = false;
            btnDDA.Checked = false;
            btnPontoMedioRetas.Checked = false;

            btnEquacaoCircunferencia.Checked = false;
            btnTrigonometria.Checked = false;
            btnPontoMedioCircunferencia.Checked = false;

            btnPontoMedioElipse.Checked = false;

            // INICIALIZAÇÕES ---------------------------------
            //inicializar as variáveis de controle das retas
            posInicial.X = -1;
            posInicial.Y = -1;
            posFinal.X = -1;
            posFinal.Y = -1;

            //inicializar as listas
            retas.Clear();
            poligonos.Clear();
            circunferencias.Clear();
            elipses.Clear();

            //inicializar o polígono temporário
            poligonoTemp = new Poligono();

            //inicializar a elipse temporária
            elipseTemp = new Elipse();

            //inicializar o listView
            listViewPoligono.Items.Clear();
        }

        private void ControlarBotoes(bool flag)
        {
            btnEquacaoReta.Enabled = flag;
            btnDDA.Enabled = flag;
            btnPontoMedioRetas.Enabled = flag;

            btnEquacaoCircunferencia.Enabled = flag;
            btnTrigonometria.Enabled = flag;
            btnPontoMedioCircunferencia.Enabled = flag;

            btnPontoMedioElipse.Enabled = flag;
            btnLimpar.Enabled = flag;

            btnCancelar.Visible = !flag;
        }

        private void MudarBotaoADDPoligono(bool flag)
        {
            if (flag)
            {
                btnAddPoligono.Enabled = false;
            }
            else
            {
                btnAddPoligono.Enabled = true;
                btnAddPoligono.BackColor = Color.White;
                btnAddPoligono.Text = "Add Polígono";
                btnAddPoligono.ForeColor = Color.Black;
            }
        }

        private void btnAddPoligono_Click(object sender, EventArgs e)
        {
            addPoligono = !addPoligono;
            posInicial.X = -1;
            posInicial.Y = -1;

            ControlarBotoes(!addPoligono);
            MudarBotaoADDPoligono(addPoligono);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesativarAddPoligono();
        }

        private void DesativarAddPoligono()
        {
            addPoligono = !addPoligono;

            ControlarBotoes(!addPoligono);
            MudarBotaoADDPoligono(addPoligono);

            //limpar as estruturas com o polígono temporário
            poligonoTemp.ClearPoligono();
            Filtros.ImagemBranca(imageBitmap);
            Desenhar();
        }

        private void pictBoxImg1_MouseMove(object sender, MouseEventArgs e)
        {
            bool flag = false;
            if(posInicial.X > -1)
            {
                if (addPoligono || addReta)
                {
                    flag = !flag;
                    Point posTempFinal = new Point(e.Location.X, e.Location.Y);

                    //pintarei de branco a posInicial até posAnt
                    Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, posAnt.X, posAnt.Y, 255, 255, 255);
                    posAnt.X = posTempFinal.X;
                    posAnt.Y = posTempFinal.Y;

                    //desenhar a reta imaginária
                    Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, posTempFinal.X, posTempFinal.Y, 180, 180, 180); //aresta temporária
                }
                else if (addCirc)
                {
                    flag = !flag;
                    Point posTempFinal = new Point(e.Location.X, e.Location.Y);

                    //pintarei de branco a posInicial até posAnt -> Circunferencia
                    Filtros.CircunferenciaPontoMedio(imageBitmap, posInicial.X, posInicial.Y, posAnt.X, posAnt.Y, 255, 255, 255);
                    Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, posAnt.X, posAnt.Y, 255, 255, 255);
                    posAnt.X = posTempFinal.X;
                    posAnt.Y = posTempFinal.Y;

                    //desenhar a reta imaginária
                    Filtros.CircunferenciaPontoMedio(imageBitmap, posInicial.X, posInicial.Y, posTempFinal.X, posTempFinal.Y, 180, 180, 180); //Circulo temporário
                    Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, posTempFinal.X, posTempFinal.Y, 180, 180, 180); //aresta temporária
                }
                else if (addElipse && !add2Elipse)
                {
                    flag = !flag;
                    // aqui é a exibição da reta na HORIZONTAL
                    Point posTempFinal = new Point(e.Location.X, posInicial.Y);

                    //pintarei de branco a posInicial até posAnt -> Circunferencia
                    Filtros.CircunferenciaPontoMedio(imageBitmap, posInicial.X, posInicial.Y, posAnt.X, posAnt.Y, 255, 255, 255);
                    Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, posAnt.X, posAnt.Y, 255, 255, 255);
                    posAnt.X = posTempFinal.X;
                    posAnt.Y = posTempFinal.Y;

                    //desenhar a reta imaginária
                    Filtros.CircunferenciaPontoMedio(imageBitmap, posInicial.X, posInicial.Y, posTempFinal.X, posTempFinal.Y, 180, 180, 180); //Circulo temporário
                    Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, posTempFinal.X, posTempFinal.Y, 180, 180, 180); //aresta temporária
                }
                else if (add2Elipse)
                {
                    flag = !flag;
                    // aqui é a exibição da reta na VERTICAL
                    Point posTempFinal = new Point(posInicial.X, e.Location.Y);

                    //pintarei de branco a posInicial até posAnt -> Circunferencia
                    Filtros.ElipsePontoMedio(imageBitmap, posInicial.X, posInicial.Y, posFinalElipse.X, posFinalElipse.Y, posAnt.X, posAnt.Y, 255, 255, 255);
                    Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, posAnt.X, posAnt.Y, 255, 255, 255);
                    posAnt.X = posTempFinal.X;
                    posAnt.Y = posTempFinal.Y;

                    //desenhar a reta imaginária
                    Filtros.ElipsePontoMedio(imageBitmap, posInicial.X, posInicial.Y, posFinalElipse.X, posFinalElipse.Y, posTempFinal.X, posTempFinal.Y, 180, 180, 180); //Circulo temporário
                    Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, posTempFinal.X, posTempFinal.Y, 180, 180, 180); //aresta temporária
                }
                if(flag)
                    Desenhar();
            }
        }

        private void pictBoxImg1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (addPoligono)
                {
                    if (posInicial.X == -1) //primeiro ponto do polígono
                    {
                        posInicial = e.Location;
                        posAnt = e.Location;
                    }
                    else
                    {
                        posFinal = e.Location;
                        poligonoTemp.AddAresta(new Reta(posInicial, posFinal));
                        posInicial = posFinal;
                    }
                }
                else if (btnEquacaoReta.Checked || btnDDA.Checked || btnPontoMedioRetas.Checked)
                {
                    if (!addReta)//não tá ativado é primeiro ponto
                    {
                        addReta = true;
                        posInicial = e.Location;
                        posAnt = e.Location;
                    }
                    else
                    {
                        posFinal = e.Location;
                        if (btnEquacaoReta.Checked)
                        {
                            Filtros.EquacaoReta(imageBitmap, posInicial.X, posInicial.Y, posFinal.X, posFinal.Y);
                        }
                        else if (btnDDA.Checked)
                        {
                            Filtros.DDA(imageBitmap, posInicial.X, posInicial.Y, posFinal.X, posFinal.Y);
                        }
                        else if (btnPontoMedioRetas.Checked)
                        {
                            Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, posFinal.X, posFinal.Y, 0, 0, 0);
                        }

                        Point iniTemp = new Point(posInicial.X, posInicial.Y);
                        Point fimTemp = new Point(posFinal.X, posFinal.Y);
                        Reta reta = new Reta(iniTemp, fimTemp);
                        retas.Add(reta);

                        //inicializar como não tendo mais nenhum ponto
                        posInicial.X = -1;
                        posInicial.Y = -1;
                        addReta = false;
                    }
                }
                else if (btnEquacaoCircunferencia.Checked || btnTrigonometria.Checked || btnPontoMedioCircunferencia.Checked)
                {
                    if (!addCirc)//não tá ativado é primeiro ponto
                    {
                        addCirc = true;
                        posInicial = e.Location;
                        posAnt = e.Location;
                    }
                    else
                    {
                        posFinal = e.Location;
                        if (btnEquacaoCircunferencia.Checked)
                        {
                            Filtros.CircunferenciaEquacao(imageBitmap, posInicial.X, posInicial.Y, posFinal.X, posFinal.Y);
                        }
                        else if (btnTrigonometria.Checked)
                        {
                            Filtros.CircunferenciaTrigonometria(imageBitmap, posInicial.X, posInicial.Y, posFinal.X, posFinal.Y);
                        }
                        else if (btnPontoMedioCircunferencia.Checked)
                        {
                            Filtros.CircunferenciaPontoMedio(imageBitmap, posInicial.X, posInicial.Y, posFinal.X, posFinal.Y, 0, 0, 0);
                        }

                        Point iniTemp = new Point(posInicial.X, posInicial.Y);
                        Point fimTemp = new Point(posFinal.X, posFinal.Y);
                        Reta reta = new Reta(iniTemp, fimTemp);
                        Circunferencia c = new Circunferencia(reta);
                        circunferencias.Add(c);

                        //inicializar como não tendo mais nenhum ponto
                        posInicial.X = -1;
                        posInicial.Y = -1;
                        addCirc = false;
                    }
                }
                else if (btnPontoMedioElipse.Checked)
                {
                    if (!addElipse)//não tá ativado é primeiro ponto
                    {
                        addElipse = true;
                        posInicial = e.Location;
                        posAnt = e.Location;
                    }
                    else
                    {
                        if (!add2Elipse)
                        {
                            // PEGAR O SEGUNDO PONTO -> final da primeira reta 
                            posFinalElipse = e.Location;

                            Point iniTemp = new Point(posInicial.X, posInicial.Y);
                            Point fimTemp = new Point(posFinalElipse.X, posInicial.Y);
                            Reta reta = new Reta(iniTemp, fimTemp);
                            elipseTemp.SetEixoA(reta);

                            //ativar para pegar o segundo ponto da segunda reta
                            add2Elipse = true;
                        }
                        else
                        {
                            // PEGAR O TERCEIRO PONTO -> final da segunda reta 
                            posFinal = e.Location;

                            Point iniTemp = new Point(posInicial.X, posInicial.Y);
                            Point fimTemp = new Point(posInicial.X, posFinal.Y);
                            Reta reta = new Reta(iniTemp, fimTemp);
                            elipseTemp.SetEixoB(reta);
                            elipses.Add(elipseTemp);
                            elipseTemp = new Elipse();

                            //inicializar como não tendo mais nenhum ponto
                            posInicial.X = -1;
                            posInicial.Y = -1;
                            addElipse = false;
                            add2Elipse = false;
                        }
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                // fechar o polígono
                if (addPoligono && posInicial.X != -1)
                {
                    posFinal = poligonoTemp.GetAresta(0).GetIni(); //pega o último ponto do polígono
                    poligonoTemp.AddAresta(new Reta(posInicial, posFinal)); //fecha o polígono
                    poligonos.Add(poligonoTemp); //adiciona o polígono à lista de polígonos

                    //adicionar o polígono à minha lista de polígonos de exibição no formulário principal
                    ListViewItem item = new ListViewItem("Obj. " + poligonos.Count + " | " + "Qtde. Arestas: " + poligonoTemp.CountArestas());
                    item.Tag = poligonoTemp;
                    listViewPoligono.Items.Add(item);

                    //inicializa o polígono temporário
                    poligonoTemp = new Poligono(); 

                    //inicializar ponto inicial
                    posInicial.X = -1;
                    posInicial.Y = -1;

                    DesativarAddPoligono();
                }
            }

            Filtros.ImagemBranca(imageBitmap);
            Desenhar();
        }

        // ================================================ ListView do Polígono =====================================================================
        /*
         * Funções para a plotagem de elementos na tela
         *   Recuperar um objeto real a partir do item selecionado na listView -> polígonos
        **/
        private void listViewPoligono_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPoligono.SelectedItems.Count == 0)
                return;

            ListViewItem item = listViewPoligono.SelectedItems[0];

            // Recupera seu objeto real
            Poligono p = (Poligono)item.Tag;

            //desenha de uma cor diferente
            Desenhar();
            DesenharPoligono(p, Color.Red.R, Color.Red.G, Color.Red.B);
        }

        // ================================================ DESENHAR ==================================================================================
        /*
         * Funções para a plotagem de elementos na tela
        **/
        private void Desenhar()
        {
            DesenharRetas();
            DesenharPoligonoAtual();
            DesenharPoligonos();
            DesenharCircunferencias();
            DesenharElipses();
            pictBoxImg1.Refresh();
        }

        private void DesenharRetas()
        {
            for (int i = 0; i < retas.Count; i++)
            {
                Filtros.Bresenham(imageBitmap, retas[i].GetIniX(), retas[i].GetIniY(), retas[i].GetFimX(), retas[i].GetFimY(), 0, 0, 0); //pinta de preto
            }
        }

        private void DesenharPoligonoAtual()
        {
            for (int i = 0; i < poligonoTemp.CountArestas(); i++)
            {
                Reta r = poligonoTemp.GetAresta(i);
                Filtros.Bresenham(imageBitmap, r.GetIniX(), r.GetIniY(), r.GetFimX(), r.GetFimY(), 180, 180, 180); //aresta temporária
            }
        }

        private void DesenharPoligonos()
        {
            for (int i = 0; i < poligonos.Count; i++)
            {
                Poligono p = poligonos[i];
                DesenharPoligono(p, 0, 0, 0);
            }
        }

        private void DesenharPoligono(Poligono p, int R, int G, int B)
        {
            for (int j = 0; j < p.CountArestas(); j++)
            {
                Reta r = p.GetAresta(j);
                Filtros.Bresenham(imageBitmap, r.GetIniX(), r.GetIniY(), r.GetFimX(), r.GetFimY(), R, G, B);
            }
            pictBoxImg1.Refresh();
        }

        private void DesenharCircunferencias()
        {
            for (int i = 0; i < circunferencias.Count; i++)
            {
                Circunferencia c = circunferencias[i];
                Filtros.CircunferenciaPontoMedio(imageBitmap, c.GetCentroX(), c.GetCentroY(), c.GetFimRaioX(), c.GetFimRaioY(), 0, 0, 0); //pintar de preto
            }
        }

        private void DesenharElipses()
        {
            for (int i = 0; i < elipses.Count; i++)
            {
                Elipse e = elipses[i];
                Filtros.ElipsePontoMedio(imageBitmap, e.GetOrigemX(), e.GetOrigemY(), e.GetFimEixoAX(), e.GetFimEixoAY(), e.GetFimEixoBX(), e.GetFimEixoBY(), 0, 0, 0); //pintar de preto
            }
        }


        // ================ AÇÔES TRANSFORMAÇÕES GEOMÉTRICAS =====================
        private void btnAplicarEscala_Click(object sender, EventArgs e)
        {
            //numUpDownEscalaX;
            //numUpDownEscalaY;
        }

        private void btnAplicarTranslacao_Click(object sender, EventArgs e)
        {
            //numUpDownTranslacaoX;
            //numUpDownTranslacaoY;

        }

        private void btnAplicarRotacao_Click(object sender, EventArgs e)
        {
            //numUpDownGrauRotacao;
        }

        private void btnAplicarCisalhamento_Click(object sender, EventArgs e)
        {
           // numUpDownXCisalhamento;
           // numUpDownYCisalhamento;
        }

        private void btnAplicarReflexao_Click(object sender, EventArgs e)
        {
            if (checkBoxXReflexao.Checked && checkBoxYReflexao.Checked)
            {

            }else if(checkBoxXReflexao.Checked)
            {
                //reflexão em relação ao eixo X

            } else if (checkBoxYReflexao.Checked)
            {
                //reflexão em relação ao eixo Y
            }

        }
}
