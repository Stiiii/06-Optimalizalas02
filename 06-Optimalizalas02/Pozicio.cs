using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Optimalizalas02
{
    class Pozicio
    {
        public int Sor { get; }
        public int Oszlop { get; }
        public bool Fix { get; }
        public object Ertek { get; set; }

        public Pozicio(int sor, int oszlop)
        {
            Sor = sor;
            Oszlop = oszlop;
            this.Fix = false;
        }
        public Pozicio(int sor, int oszlop, object ertek)
        {
            Sor = sor;
            Oszlop = oszlop;
            Ertek = ertek;
            this.Fix = true;
        }

        public static bool Kizaroak(Pozicio x, Pozicio y)
        {
            return x.Sor == y.Sor || x.Oszlop == y.Oszlop || (x.Sor / 3 == y.Sor / 3 && x.Oszlop / 3 == y.Oszlop / 3);
        }

    }
}
