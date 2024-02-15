using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input numerico:

            //Determinare variabili
            string Base, Altezza, Messaggio;
            double Altezza1, Base1, Area, Perimetro;
            //Fase di input
            Console.WriteLine("Inserisci i dati della base e dell'altezza del rettangolo");
            Console.WriteLine();
            //Fase di elaborazione
            Console.Write("Base: ");
            Base = Console.ReadLine();           
            Base1 = Convert.ToDouble(Base);
            Console.Write("Altezza: ");
            Altezza = Console.ReadLine();
            Altezza1 = Convert.ToDouble(Altezza);

            Perimetro = (Base1 * 2) + (Altezza1 * 2);
            Area = Base1 * Altezza1;
            //Fase di output
            Console.WriteLine();
            Console.WriteLine("Il perimetro del rettangolo è di " + Perimetro + " metri, con base di " + Base + " e un'altezza di " + Altezza + " metri.");
            Console.WriteLine("L'area del rettangolo è di " + Area + " metri.");

            Console.ReadLine();
        }
    }
}
