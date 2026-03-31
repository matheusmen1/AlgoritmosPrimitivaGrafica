using System;
using System.Collections.Generic;

namespace ProcessamentoImagens.classes
{
    internal class Poligono
    {
        private List<Reta> Arestas { get; set; }
        private double[,] MatrizTransformacao { get; set; }

        public Poligono()
        {
            Arestas = new List<Reta>();
            MatrizTransformacao = new double[3, 3];

            GerarMatrizIdentidade();
        }

        public Reta GetAresta(int pos)
        {
            if(pos>-1 && pos<Arestas.Count)
                return Arestas[pos];
            return null;
        }

        public void AddAresta(Reta r)
        {
            Arestas.Add(r);
        }

        public void ClearPoligono()
        {
            Arestas.Clear();
        }

        public int CountArestas()
        {
            return Arestas.Count;
        }

        private void GerarMatrizIdentidade()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (i == j)
                        MatrizTransformacao[i, j] = 1;
                    else
                        MatrizTransformacao[i, j] = 0;
        }

        public Double? GetMatrizXY(int x,int y)
        {
            if(x>=0 && y>=0 && x<3 && y < 3)
                return MatrizTransformacao[x, y];
            return null;
        }

        public override string ToString()
        {
            string retorno =  $"{Arestas.Count}";
            for(int i=0; i<Arestas.Count; i++)
            {
                retorno += $"|{Arestas[i].GetIniX()},{Arestas[i].GetIniY()}|{Arestas[i].GetFimX()},{Arestas[i].GetFimY()}";
            }
            return retorno;
        }
    }
}
