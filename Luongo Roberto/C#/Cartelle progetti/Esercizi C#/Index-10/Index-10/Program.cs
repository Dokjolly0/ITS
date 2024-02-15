using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = 10, num2 = 20;
            //Dichiarazione
            void somma(double n1, double n2)
            {
                double risultato = n1 + n2;
                Console.WriteLine(risultato);
            }

            somma(num1, num2);

            List<double> numeri = new List<double>();
            
            numeri.Add(10);
            numeri.Add(200);
            numeri.Add(40);

            double calcolamedia(List <double> n)
            {
                double calcolo = 0;
                for (int i = 0; i < n.Count(); i++)
                {
                    calcolo += n[i];
                }
                return calcolo/n.Count();
            }

            //calcola la media dei valori contenuti nella lista
            double media = calcolamedia(numeri);
            Console.WriteLine(media);
            Console.ReadLine();
        }
    }
}
