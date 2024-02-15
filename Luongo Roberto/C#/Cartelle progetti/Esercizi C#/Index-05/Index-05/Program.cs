using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_05
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Inserisci una temperatura in gradi centigradi: ");
                double temperatura;
                string gradi;

                gradi = Console.ReadLine();
                temperatura = Convert.ToDouble(gradi);

                if (temperatura >= 100)
                {
                    Console.WriteLine("Lo stato è gassoso.");
                }
                else if (temperatura > 0 && temperatura < 100)
                {
                    Console.WriteLine("Lo stato è liquido.");
                }
                else if (temperatura < -273.15)
                {
                    Console.WriteLine("Non è una temperatura in gradi centigradi.");
                }
                else
                {
                    Console.WriteLine("Lo stato è solido.");
                }
                Console.WriteLine();
            }

        }
    }
}
