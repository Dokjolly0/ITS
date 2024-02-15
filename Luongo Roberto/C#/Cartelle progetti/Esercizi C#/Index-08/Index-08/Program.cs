using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Crea un app console che ti chiede in imput 5 temperature, assegnale ad una lista e stampale, per ogni numero:
            <15 freddo
            tra 15 e 25 temperato
            >25 caldo
             */

            List<double> temperatura; 
            temperatura = new List<double>();

            string temp1, temp2, temp3, temp4, temp5;
            double gradi1, gradi2, gradi3, gradi4, gradi5;

            temp1 = Console.ReadLine();
            gradi1 = Convert.ToDouble(temp1);
            temp2 = Console.ReadLine();
            gradi2 = Convert.ToDouble(temp2);
            temp3 = Console.ReadLine();
            gradi3 = Convert.ToDouble(temp3);
            temp4 = Console.ReadLine();
            gradi4 = Convert.ToDouble(temp4);
            temp5 = Console.ReadLine();
            gradi5 = Convert.ToDouble(temp5);

            temperatura.Add(gradi1);
            temperatura.Add(gradi2);
            temperatura.Add(gradi3);
            temperatura.Add(gradi4);
            temperatura.Add(gradi5);
            Console.WriteLine();

            // I controlli vanno fatti nella variabile e non nella lista
            foreach (double Temperatura in temperatura)
            {

                if (Temperatura < 15)
                {
                    Console.WriteLine("La temperatura è fredda!");
                    Console.WriteLine();
                }
                else if (Temperatura >= 15 && Temperatura < 25)
                {
                    Console.WriteLine("La temperatura è temperata");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("La temperatura è calda");
                    Console.WriteLine();
                }

                //Input numerico scritto in abbreviato
                //double numero = Convert.ToDouble(Console.ReadLine());
                //Dati 5 numeri double in input calcolare la media utilizzando le liste

            }
            Console.ReadLine();

        }
    }
}
