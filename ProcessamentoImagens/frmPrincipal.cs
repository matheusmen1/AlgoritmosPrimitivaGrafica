using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace ProcessamentoImagens
{
    public partial class frmPrincipal : Form
    {
        private Bitmap imageBitmap;


        private Point posInicial;
        private Point posFinal;

        public frmPrincipal()
        {
            InitializeComponent();

            imageBitmap = new Bitmap(pictBoxImg1.ClientSize.Width,pictBoxImg1.ClientSize.Height,
                PixelFormat.Format24bppRgb);

            Filtros.imagemBranca(imageBitmap);

            pictBoxImg1.SizeMode = PictureBoxSizeMode.Normal;
            pictBoxImg1.Image = imageBitmap;
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

            posInicial = Point.Empty;
            posFinal = Point.Empty;
        }

        


        //capturar posição mouse
        private void pictBoxImg1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                posInicial = e.Location;
                Console.WriteLine($"Início: {posInicial.X}, {posInicial.Y}");
            }
        }

        private void pictBoxImg1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                posFinal = e.Location;
                Console.WriteLine($"Fim: {posFinal.X}, {posFinal.Y}");

                //chama os algoritmos de acordo com o botão selecionado

                // retas
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
                    Filtros.bresenham(imageBitmap, posInicial.X, posInicial.Y, posFinal.X, posFinal.Y);
                }

                //circunferências
                if (btnEquacaoCircunferencia.Checked)
                {
                    //Filtros.circunferenciaEquacao(imageBitmap, posInicial.X, posInicial.Y, posFinal.X, posFinal.Y);
                }
                else if (btnTrigonometria.Checked)
                {
                    //Filtros.circunferenciaTrigonometria(imageBitmap, posInicial.X, posInicial.Y, posFinal.X, posFinal.Y);
                }
                else if (btnPontoMedioCircunferencia.Checked)
                {
                    //Filtros.circunferenciaPontoMedio(imageBitmap, posInicial.X, posInicial.Y, posFinal.X, posFinal.Y);
                }

                //elipses
                if (btnPontoMedioElipse.Checked)
                {
                    //Filtros.elipsePontoMedio(imageBitmap, posInicial.X, posInicial.Y, posFinal.X, posFinal.Y);
                }


                pictBoxImg1.Refresh();
            }
        }

        
    }
}
