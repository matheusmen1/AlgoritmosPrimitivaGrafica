using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImagens.classes
{
    internal class Elipse
    {
        private Reta EixoA { get; set; }
        private Reta EixoB { get; set; }

        public Elipse()
        {
            // inicializando os eixos da minha elipse -> EixoA e EixoB -> Eixo maior e Eixo menor
            EixoA = new Reta();
            EixoB = new Reta();
        }

        public int GetOrigemX()
        {
            return EixoA.GetIniX();
        }
        public int GetOrigemY()
        {
            return EixoA.GetIniY();
        }
        public int GetFimEixoAX()
        {
            return EixoA.GetFimX();
        }
        public int GetFimEixoAY()
        {
            return EixoA.GetFimY();
        }
        public int GetFimEixoBX()
        {
            return EixoB.GetFimX();
        }
        public int GetFimEixoBY()
        {
            return EixoB.GetFimY();
        }

        public void SetEixoA(Reta r)
        {
            EixoA = r;
        }
        public void SetEixoB(Reta r)
        {
            EixoB = r;
        }
    }
}
