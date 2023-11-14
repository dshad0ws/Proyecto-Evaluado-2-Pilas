using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Evaluado_2_Pilas
{
    internal class Pilas
    {
        #region
        protected const int max = 5;
        string[] Elementos;
        int tope;
        #endregion

        public Pilas()
        {
            tope = -1;
            Elementos = new string[max];

        }

        private bool vacia()
        {
            return (tope == -1);
        }

        private bool llena()
        {
            return (tope == max - 1);
        }

        public void Push(string Dato)
        {
            if (llena())
            {
            }
            else
            {
                Elementos[++tope] = Dato;
            }
        }

        public string Pop()
        {
            if (vacia())
            {
                return null;
            }
            else
            {
                string D;
                D = Elementos[tope];
                tope--;
                return D;
            }
        }

        public string Poptope()
        {
            if (vacia())
            {
                return null;
            }
            else
            {
                string D;
                D = Elementos[tope];
                return D;
            }
        }

        public void Imprimir()
        {
            if (vacia())
            {
            }

            else
            {
                string d;
                Pilas Pa = new Pilas();
                while (!vacia())
                {
                    d = Pop();
                    Console.WriteLine(d);
                    Pa.Push(d);
                }

                while (!Pa.vacia())
                {
                    Push(Pa.Pop());
                }
            }

        }

        public int Count()
        {
            return ++tope;

        }

        public void Clear()
        {
            tope = -1;
        }

    }
}
