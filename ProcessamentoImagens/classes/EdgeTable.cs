using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcessamentoImagens.classes.EdgeTable
{
    internal class EdgeTable
    {
        private NoEdgeTable et { get; set; } //abreviação para "Edge Table"

        public EdgeTable()
        {
            et = null;
        }

        public EdgeTable(NoEdgeTable no)
        {
            et = no;
        }

        public NoEdgeTable GetNoEdgeTableAt(int pos)
        {
            NoEdgeTable aux = et;
            int i = 0;
            while (aux != null && i < pos + 1)
                aux = aux.prox;

            if (aux != null) //achei a posição correta
                return aux;
            return null;
        }

        public void Add(NoEdgeTable no)
        {
            //se lista nulla, adiciona o único nó
            if (et == null)
            {
                et = no;
            }
            else //se não vazia, insere no final
            {
                NoEdgeTable aux = et;
                while (aux.prox != null)
                    aux = aux.prox;
                aux.prox = no;
            }
        }

        public void AddAt(NoEdgeTable no, int pos)
        {
            NoEdgeTable aux, ant;

            if (pos == 0) //inserir na primeira posição
            {
                no.prox = et;
                et = no;
            }
            else //inserir em qualquer posição depois da primeira
            {
                aux = et;
                ant = aux;
                int i = 0;
                while (aux != null && i < pos + 1)
                {
                    ant = aux;
                    aux = aux.prox;
                }

                if (aux != null) //achei a posição correta
                {
                    ant.prox = no;
                    no.prox = aux;
                }
            }
        }

        public int Count()
        {
            //contar a quantidade de nós que possuem a minha lista
            int count = 0;
            NoEdgeTable aux = et;
            while (aux != null)
            {
                aux = aux.prox;
                count++;
            }
            return count;
        }

        public void Sort()
        {
            //ordenar a lista
        }

        public void RemoveAllYMax(int y)
        {
            //remover todos os elementos da minha lista que o yMax == y
        }

        public void Clear()
        {
            //limpa a EdgeTable
            et = null;
        }

        public void Remove()
        {
            //remove o último elemento da ET
        }

        public void RemoveAt(int pos)
        {
            //remove o no da et na posição pos
        }
    }
}
