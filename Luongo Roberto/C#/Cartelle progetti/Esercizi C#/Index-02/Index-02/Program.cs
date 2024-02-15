using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int area, perimetro, Base, altezza;

            Base = 20;
            altezza = 5;
            area = Base * altezza;
            perimetro = (Base * 2) + (altezza * 2);

            Console.WriteLine("L'area del rettangolo è di " + area + " metri.");
            Console.WriteLine("Il perimetro del rettangolo è di " + perimetro + " metri.");

            Console.ReadLine();
        }
    }
}
