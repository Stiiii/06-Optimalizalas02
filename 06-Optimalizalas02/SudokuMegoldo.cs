using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Optimalizalas02
{
    class SudokuMegoldo : Backtrack
    {

        Pozicio[] tabla = new Pozicio[9 * 9];
        Pozicio[] fixMezok;
        Pozicio[] uresMezok;

        void TablaBetoltes(string fajlnev)
        {
            string sor = File.ReadAllText(fajlnev);
            sor = sor.Replace("\n", "").Replace("\r", "");
            int uresCount = 0;
            for (int i = 0; i < sor.Length; i++)
            {
                if (sor[i] == '.')
                {
                    uresCount++;
                }
            }
            N = uresCount;
            M = new int[N];
            R = new object[N, 9];
            for (int i = 0; i < N; i++)
            {
                M[i] = 9;
                for (int j = 0; j < 9; j++)
                {
                    R[i, j] = j + 1;
                }
            }
            uresMezok = new Pozicio[uresCount];
            fixMezok = new Pozicio[9 * 9 - uresCount];
            int uresDB = 0;
            int fixDB = 0;
            for (int i = 0; i < tabla.Length; i++)
            {
                if (sor[i] == '.')
                {
                    tabla[i] = new Pozicio(i / 9, i % 9);
                    uresMezok[uresDB++] = tabla[i];

                }
                else
                {
                    tabla[i] = new Pozicio(i / 9, i % 9, int.Parse(sor[i].ToString()));
                    fixMezok[fixDB++] = tabla[i];
                }
            }
        }

        public SudokuMegoldo(string fajlnev)
        {
            TablaBetoltes(fajlnev);
        }
        public void Megoldas()
        {
            object[] E = Kereses();
            for (int i = 0; i < N; i++)
            {
                uresMezok[i].Ertek = E[i];
            }
        }

        public void Megjelenites()
        {
            for (int i = 0; i < tabla.Length; i++)
            {
                if (i%9 == 0 && i != 0)
                {
                    Console.WriteLine();
                }

                Console.ForegroundColor = tabla[i].Fix ? ConsoleColor.White : ConsoleColor.Green;
                Console.Write(tabla[i].Ertek != null ? tabla[i].Ertek : '.');
            }
        }
        protected override bool fk(int i, object r, int j, object q)
        {
            return !(r.Equals(q) && Pozicio.Kizaroak(uresMezok[i], uresMezok[j]));
        }

        protected override bool ft(int i, object r)
        {
            int j = 0;
            while (j < fixMezok.Length && !(Pozicio.Kizaroak(fixMezok[j], uresMezok[i]) && fixMezok[j].Ertek.Equals(r)))
            {
                j++;
            }
            return !(j < fixMezok.Length);
        }

    }
}
