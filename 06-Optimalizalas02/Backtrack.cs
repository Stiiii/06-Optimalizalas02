using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Optimalizalas02
{
    delegate void AllapotFigyelo(int szint, object[] E);

    abstract class Backtrack
    {
        protected int N;
        protected int[] M;
        protected object[,] R;

        protected abstract bool ft(int i, object r);

        protected abstract bool fk(int i, object r, int j, object q);

        public event AllapotFigyelo Probalkozas;

        protected object[] Kereses()
        {
            bool van = false;
            object[] E = new object[N];

            Probal(0, ref van, ref E);
            if (van)
            {
                return E;
            }
            else
            {
                throw new NincsMegoldasKivetel();
            }
        }

        void Probal(int szint, ref bool van, ref object[] E)
        {
            int i = -1;
            do
            {
                i++;
                if (ft(szint, R[szint,i]))
                {
                    int k = 0;
                    while (k < szint && fk(szint, R[szint, i], k, E[k]))
                    {
                        k++;
                    }
                    if (k == szint)
                    {
                        E[szint] = R[szint, i];
                        Probalkozas?.Invoke(szint, E);
                        if (szint == N - 1)
                        {
                            van = true;
                        }
                        else
                        {
                            Probal(szint + 1, ref van, ref E);
                        }
                    }
                }
            } while (!van && i < M[szint]-1);
        }
    }
}
