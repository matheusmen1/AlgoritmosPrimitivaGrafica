using System.Drawing;

namespace ProcessamentoImagens.classes
{
    internal class Reta
    {
        private Point Ini { get; set; }
        private Point Fim { get; set; }

        public Reta()
        {
            // inicializando os pontos da minha reta
            Ini = new Point(-1,-1);
            Fim = new Point(-1,-1);
        }

        public Reta(Point ini, Point fim)
        {
            this.Ini = ini;
            this.Fim = fim;
        }

        public Point GetIni()
        {
            return Ini;
        }

        public Point GetFim()
        {
            return Fim;
        }

        public int GetIniX()
        {
            return Ini.X;
        }
        public int GetIniY()
        {
            return Ini.Y;
        }

        public int GetFimX()
        {
            return Fim.X;
        }

        public int GetFimY()
        {
            return Fim.Y;
        }

    }
}
