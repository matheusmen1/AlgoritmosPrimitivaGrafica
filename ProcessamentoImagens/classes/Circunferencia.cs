using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImagens.classes
{
    internal class Circunferencia
    {
        private Reta Raio { get; set; }

        public Circunferencia()
        {
            // inicializando a minha reta -> Raio da circunferência
            Raio = new Reta();
        }

        public Circunferencia(Reta r)
        {
            // inicializando a minha reta -> Raio da circunferência
            Raio = r;
        }

        public int GetCentroX()
        {
            return Raio.GetIniX();
        }
        public int GetCentroY()
        {
            return Raio.GetIniY();
        }
        public int GetFimRaioX()
        {
            return Raio.GetFimX();
        }
        public int GetFimRaioY()
        {
            return Raio.GetFimY();
        }
    }
}
