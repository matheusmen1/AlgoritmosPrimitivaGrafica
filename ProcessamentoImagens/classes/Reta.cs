using System.Drawing;

namespace ProcessamentoImagens.classes
{
    internal class Reta
    {
        private Point ini { get; set; }
        private Point fim { get; set; }

        public Reta()
        {
            // inicializando os pontos da minha reta
            ini = new Point(-1,-1);
            fim = new Point(-1,-1);
        }

        public Reta(Point ini, Point fim)
        {
            this.ini = ini;
            this.fim = fim;
        }

        public Point GetIni()
        {
            return ini;
        }

        public Point GetFim()
        {
            return fim;
        }

        public int GetIniX()
        {
            return ini.X;
        }
        public int GetIniY()
        {
            return ini.Y;
        }

        public int GetFimX()
        {
            return fim.X;
        }

        public int GetFimY()
        {
            return fim.Y;
        }

    }
}
