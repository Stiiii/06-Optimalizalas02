using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Optimalizalas02
{
    class Program
    {
        static void Kiir(int szint, object[] E)
        {
            Console.WriteLine("Szint: " + szint);
        }
        static void Main(string[] args)
        {
            SudokuMegoldo s = new SudokuMegoldo("SudokuTabla.txt");
            s.Probalkozas += Kiir;

            try
            {
                s.Megoldas();
                Console.WriteLine("\nMegoldás: ");
                s.Megjelenites();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
