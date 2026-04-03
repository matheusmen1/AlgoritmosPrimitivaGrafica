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

            //definição do listView dos vértices do polígono selecionado
            listViewVertices.View = View.Details;
            listViewVertices.HeaderStyle = ColumnHeaderStyle.None; // esconde o cabeçalho
            listViewVertices.Columns.Add("", listViewPoligono.ClientSize.Width); // coluna ocupa tudo

            //deixar desativado as transformações 2D
            DesativarBotoesTransformacoes2D();
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

            //inicializar os listView's
            listViewPoligono.Items.Clear();
            listViewVertices.Items.Clear();

            //esconder componentes
            lbVertices.Visible = false;
            btnExcluirPoligono.Visible = false;
            listViewVertices.Visible = false;
        }

        private void ControlarBotoes(bool flag)
        {
            flpPrimitivas.Enabled = flag;
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

        private void AtivarBotoesTransformacoes2D()
        {
            flpTransformacoes.Enabled = true;
        }

        private void DesativarBotoesTransformacoes2D()
        {
            flpTransformacoes.Enabled = false;
        }

        private void btnAddPoligono_Click(object sender, EventArgs e)
        {
            addPoligono = !addPoligono;
            posInicial.X = -1;
            posInicial.Y = -1;

            ControlarBotoes(!addPoligono);
            MudarBotaoADDPoligono(addPoligono);
            btnExcluirPoligono.Visible = false;
            btnPreencherPoligono.Visible = false;
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
            if (posInicial.X > -1)
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
                if (flag)
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

        // ================================================ ListViews =====================================================================
        /*
         * Funções para a plotagem de elementos na tela
         *   Recuperar um objeto real a partir do item selecionado na listView -> polígonos e vértices
        **/
        private void listViewPoligono_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPoligono.SelectedItems.Count == 0)
            {
                btnExcluirPoligono.Visible = false;
                lbVertices.Visible = false;
                listViewVertices.Visible = false;
                btnPreencherPoligono.Visible = false;
                DesativarBotoesTransformacoes2D();
                Desenhar();
                return;
            }

            ListViewItem item = listViewPoligono.SelectedItems[0];

            // Recupera seu objeto real
            Poligono p = (Poligono)item.Tag;

            //aparece o botões: exclusão e transformações
            btnExcluirPoligono.Visible = true;
            btnPreencherPoligono.Visible = true;
            AtivarBotoesTransformacoes2D();

            //limpa o listView dos vértices
            listViewVertices.Items.Clear();

            //aparece os vértices no listView
            List<Point> vertices = p.GetVerticesModificados();
            for(int i=0; i<vertices.Count; i++)
            {
                Point v = vertices[i];
                ListViewItem itemVertice = new ListViewItem("(" + v.X + "," + v.Y + ")");
                itemVertice.Tag = v;
                listViewVertices.Items.Add(itemVertice);
            }
            
            //aparecer o listView de vertices
            listViewVertices.Visible = true;
            lbVertices.Visible = true;
            lbVertices.Text = item.Text.ToString().Substring(0,6);

            //desenha de uma cor diferente
            Filtros.ImagemBranca(imageBitmap);
            Desenhar();
            DesenharPoligonoModificado(p, Color.Red.R, Color.Red.G, Color.Red.B);
        }

        private void listViewVertices_SelectedIndexChanged(object sender, EventArgs e)
        {
            //recupera o polígono selecionado
            ListViewItem itemPoligono = listViewPoligono.SelectedItems[0];
            Poligono poligono = (Poligono)itemPoligono.Tag;

            if (listViewVertices.SelectedItems.Count == 0)
            {
                Filtros.ImagemBranca(imageBitmap);
                Desenhar();
                DesenharPoligonoModificado(poligono, Color.Red.R, Color.Red.G, Color.Red.B);
                return;
            }

            ListViewItem item = listViewVertices.SelectedItems[0];

            // Recupera seu objeto real
            Point p = (Point)item.Tag;

            //pinta o vértice em questão selecionado
            Filtros.ImagemBranca(imageBitmap);
            Desenhar();
            DesenharPoligonoModificado(poligono, Color.Red.R, Color.Red.G, Color.Red.B);
            Filtros.PintaVertice(imageBitmap, p.X, p.Y, Color.Black.R, Color.Black.G, Color.Black.B);
            pictBoxImg1.Refresh();
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
                DesenharPoligonoModificado(p, 0, 0, 0); //teste
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
        private void DesenharPoligonoModificado(Poligono p, int R, int G, int B)
        {
            List<Reta> arestasModificadas = p.GetArestasTransformadas();
            for (int i = 0; i < arestasModificadas.Count; i++)
            {
                Reta r = arestasModificadas[i];
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

        // =========================== AÇÔES TRANSFORMAÇÕES GEOMÉTRICAS ================================================
        private void btnAplicarEscala_Click(object sender, EventArgs e)
        {
            //numUpDownEscalaX;
            //numUpDownEscalaY;
            if(listViewPoligono.SelectedItems.Count != 0)
            {
                //recupera o polígono selecionado
                ListViewItem itemPoligono = listViewPoligono.SelectedItems[0];
                Poligono poligono = (Poligono)itemPoligono.Tag;
                AplicarEscala(poligono);
                Desenhar();
            }
        }

        private void btnAplicarTranslacao_Click(object sender, EventArgs e)
        {
            //numUpDownTranslacaoX;
            //numUpDownTranslacaoY;
            if(listViewPoligono.SelectedItems.Count != 0)
            {
                ListViewItem itemPoligono = listViewPoligono.SelectedItems[0];
                Poligono poligono = (Poligono)itemPoligono.Tag;
                AplicarTranslacao(poligono);
                Desenhar();
            }
        }

        private void btnAplicarRotacao_Click(object sender, EventArgs e)
        {
            //numUpDownGrauRotacao;
            if(listViewPoligono.SelectedItems.Count != 0)
            {
                ListViewItem itemPoligono = listViewPoligono.SelectedItems[0];
                Poligono poligono = (Poligono)itemPoligono.Tag;
                AplicarRotacao(poligono);
                Desenhar();
            }
        }

        private void btnAplicarCisalhamento_Click(object sender, EventArgs e)
        {
            // numUpDownXCisalhamento;
            // numUpDownYCisalhamento;
            if(listViewPoligono.SelectedItems.Count != 0)
            {
                ListViewItem itemPoligono = listViewPoligono.SelectedItems[0];
                Poligono poligono = (Poligono)itemPoligono.Tag;
                AplicarCisalhamento(poligono);
                Desenhar();
            }
        }

        private void btnAplicarReflexao_Click(object sender, EventArgs e)
        {
            if(listViewPoligono.SelectedItems.Count != 0)
            {
                ListViewItem itemPoligono = listViewPoligono.SelectedItems[0];
                Poligono poligono = (Poligono)itemPoligono.Tag;
                AplicarReflexao(poligono);
                Desenhar();
            }
        }

        private void btnAplicarTudo2d_Click(object sender, EventArgs e)
        {
            if(listViewPoligono.SelectedItems.Count != 0)
            {
                ListViewItem itemPoligono = listViewPoligono.SelectedItems[0];
                Poligono p = (Poligono)itemPoligono.Tag;

                AplicarEscala(p);
                AplicarTranslacao(p);
                AplicarRotacao(p);
                AplicarCisalhamento(p);
                AplicarReflexao(p);
                Desenhar();
            }
        }
        
        private void AplicarEscala(Poligono p)
        {
            double escalaX = (double)numUpDownEscalaX.Value;
            double escalaY = (double)numUpDownEscalaY.Value;
            p.MultiplicaMatrizEscala(escalaX, escalaY);
        }

        private void AplicarTranslacao(Poligono p)
        {
            double tx = (double)numUpDownTranslacaoX.Value;
            double ty = (double)numUpDownTranslacaoY.Value;
            p.MultiplicaMatrizTranslacao(tx, ty);
        }

        private void AplicarRotacao(Poligono p)
        {
            int angulo = (int)numUpDownGrauRotacao.Value;
            p.MultiplicaMatrizRotacao(angulo);
        }

        private void AplicarCisalhamento(Poligono p)
        {
            double shx = (double)numUpDownXCisalhamento.Value;
            double shy = (double)numUpDownYCisalhamento.Value;
            p.MultiplicaMatrizCisalhamento(shx, shy);
        }

        private void AplicarReflexao(Poligono p)
        {
            bool eixoX = checkBoxXReflexao.Checked;
            bool eixoY = checkBoxYReflexao.Checked;
            if(eixoX || eixoY)
                p.MultiplicaMatrizReflexao(eixoX, eixoY);
        }

        private void btnExcluirPoligono_Click(object sender, EventArgs e)
        {
            if (listViewPoligono.SelectedItems.Count != 0)
            {
                DialogResult res = MessageBox.Show(
                    "Deseja excluir o polígono " + listViewPoligono.SelectedItems[0].Text.ToString().Substring(0,6) + "?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (res == DialogResult.Yes)
                {
                    ListViewItem item = listViewPoligono.SelectedItems[0];
                    Poligono p = (Poligono)item.Tag;

                    //remove da sua lista real
                    poligonos.Remove(p);

                    //remove da interface
                    listViewPoligono.Items.Remove(item);

                    // limpa vértices
                    listViewVertices.Items.Clear();
                    listViewVertices.Visible = false;
                    lbVertices.Visible = false;

                    // esconde botão
                    btnExcluirPoligono.Visible = false;

                    // limpa seleção
                    listViewPoligono.SelectedItems.Clear();

                    // redesenha
                    Filtros.ImagemBranca(imageBitmap);
                    Desenhar();
                }
            }
        }

        private void btnPreencherPoligono_Click(object sender, EventArgs e)
        {
            if(listViewPoligono.SelectedItems.Count != 0)
            {
                ListViewItem itemPoligono = listViewPoligono.SelectedItems[0];
                Poligono poligono = (Poligono)itemPoligono.Tag;
                Desenhar();

                //Filtros.PreencherPoligonoFloodFill(imageBitmap, poligono);
                Filtros.PreencherPoligonoScanlineAET(imageBitmap, poligono);
                DesenharPoligonoModificado(poligono, 0,0,0);
                pictBoxImg1.Refresh();
            }
        }
    }
}
