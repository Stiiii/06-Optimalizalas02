using System;
using System.Runtime.Serialization;

namespace _06_Optimalizalas02
{
    [Serializable]
    class NincsMegoldasKivetel : Exception
    {
        public NincsMegoldasKivetel() : base("Nincs megoldás")
        {
        }
    }
}