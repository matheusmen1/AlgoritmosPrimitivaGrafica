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
        private Point posFinal = new Point(-1,-1);
        private Point posAnt = new Point(-1,-1);
        private List<Point> retasIni = new List<Point>();
        private List<Point> retasFim = new List<Point>();
        private List<Poligono> poligonos = new List<Poligono>();
        private Poligono poligonoTemp = new Poligono();

        // flags para estruturação de controle de desenho
        private bool addPoligono = false;
        private bool reta = false;

        public frmPrincipal()
        {
            InitializeComponent();

            imageBitmap = new Bitmap(pictBoxImg1.ClientSize.Width,pictBoxImg1.ClientSize.Height,PixelFormat.Format24bppRgb);

            Filtros.imagemBranca(imageBitmap);

            pictBoxImg1.SizeMode = PictureBoxSizeMode.Normal;
            pictBoxImg1.Image = imageBitmap;
            listViewPoligono.View = View.List;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Filtros.imagemBranca(imageBitmap);
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

            //inicializar as listas de retas
            retasIni.Clear();
            retasFim.Clear();

            //inicializar as listas de polígonos
            poligonos.Clear();

            //inicializar o polígono temporário
            poligonoTemp = new Poligono();
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

        private void MudarBotaoADD(bool flag)
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
            AtivarAddPoligono();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DesativarAddPoligono();
        }

        private void AtivarAddReta()
        {

        }

        private void DesativarAddReta()
        {

        }

        private void AtivarAddPoligono()
        {
            addPoligono = !addPoligono;

            ControlarBotoes(!addPoligono);
            MudarBotaoADD(addPoligono);
        }

        private void DesativarAddPoligono()
        {
            addPoligono = !addPoligono;

            ControlarBotoes(!addPoligono);
            MudarBotaoADD(addPoligono);

            //limpar as estruturas com o polígono temporário
            poligonoTemp.ClearPoligono();
            Filtros.imagemBranca(imageBitmap);
            Desenhar();
        }

        private void pictBoxImg1_MouseMove(object sender, MouseEventArgs e)
        {
            if(posInicial.X > -1 && (reta || addPoligono)) //tenho alguma reta para desenhar
            {
                Point posTempFinal = new Point();
                posTempFinal = e.Location;

                //pintarei de branco a posInicial até posAnt
                Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, posAnt.X, posAnt.Y, 255, 255, 255);
                posAnt.X = posTempFinal.X;
                posAnt.Y = posTempFinal.Y;

                //desenhar a reta imaginária
                Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, posTempFinal.X, posTempFinal.Y, 180, 180, 180); //aresta temporária
                pictBoxImg1.Refresh();

                //desenhar todas as informações da tela
                Desenhar();
            }
        }

        private void Desenhar()
        {
            DesenharRetas();
            DesenharPoligonoAtual();
            DesenharPoligonos();
            pictBoxImg1.Refresh();
        }

        private void DesenharRetas()
        {
            for(int i=0; i<retasIni.Count; i++)
            {
                Filtros.Bresenham(imageBitmap, retasIni[i].X, retasIni[i].Y, retasFim[i].X, retasFim[i].Y, 0, 0, 0); //pinta de preto
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

        private void pictBoxImg1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // retas ou adição de um polígono
                if (!reta || addPoligono)
                {
                    if (btnEquacaoReta.Checked || btnDDA.Checked || btnPontoMedioRetas.Checked)
                    {
                        reta = true;
                        posInicial = e.Location;
                        posAnt = e.Location;
                        Console.WriteLine($"Início: {posInicial.X}, {posInicial.Y}");
                    }
                    else if (addPoligono)
                    {
                        if(posInicial.X == -1) //primeiro ponto do polígono
                        {
                            posInicial = e.Location;
                            posAnt = e.Location;
                        }
                        else
                        {
                            posFinal = e.Location;
                            poligonoTemp.AddAresta(new Reta(posInicial, posFinal));
                            Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, posFinal.X, posFinal.Y, 0, 0, 0); //desenhar a reta do polígono
                            pictBoxImg1.Refresh();
                            posInicial = posFinal;
                        }
                    }
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

                    //add na minha lista de pontos
                    Point iniTemp = new Point(posInicial.X, posInicial.Y);
                    Point fimTemp = new Point(posFinal.X, posFinal.Y);
                    retasIni.Add(iniTemp);
                    retasFim.Add(fimTemp);

                    //inicializar como não tendo mais nenhum ponto
                    posInicial.X = -1;
                    posInicial.Y = -1;
                    reta = false;
                    pictBoxImg1.Refresh();
                }
            }
            else if(e.Button == MouseButtons.Right)
            {
                // fechar o polígono
                if(addPoligono && posInicial.X != -1)
                {
                    posFinal = poligonoTemp.GetAresta(0).GetIni(); //pega o último ponto do polígono
                    poligonoTemp.AddAresta(new Reta(posInicial, posFinal)); //fecha o polígono
                    poligonos.Add(poligonoTemp); //adiciona o polígono à lista de polígonos

                    //adicionar o polígono à minha lista de polígonos de exibição no formulário principal
                    ListViewItem item = new ListViewItem("Obj. " + poligonos.Count + " | " + "Qtde. Arestas: " + poligonoTemp.CountArestas());
                    item.Tag = poligonoTemp;
                    listViewPoligono.Items.Add(item);

                    Console.WriteLine(poligonoTemp.ToString()); //exibição do polígono em formato de string
                    poligonoTemp = new Poligono(); //inicializa um novo polígono para o próximo

                    //desenhar a reta de fechamento do polígono
                    Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, posFinal.X, posFinal.Y, 0, 0, 0);

                    Filtros.Bresenham(imageBitmap, posInicial.X, posInicial.Y, e.X, e.Y, 255, 255, 255);
                    pictBoxImg1.Refresh();
                    //inicializar como não tendo mais nenhum ponto
                    posInicial.X = -1;
                    posInicial.Y = -1;

                    DesativarAddPoligono();
                }
            }
        }

        //recuperar um objeto real a partir do item selecionado na listView -> polígonos
        private void listViewPoligono_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPoligono.SelectedItems.Count == 0)
                return;

            ListViewItem item = listViewPoligono.SelectedItems[0];

            // Recupera seu objeto real
            Poligono p = (Poligono)item.Tag;

            Console.WriteLine(poligonoTemp.ToString());

            //desenha de uma cor diferente
            DesenharPoligono(p, Color.Red.R, Color.Red.G, Color.Red.B);
        }
    }
}
