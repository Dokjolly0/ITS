using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Input numerico scritto in abbreviato
            //double numero = Convert.ToDouble(Console.ReadLine());
            //Dati 5 numeri double in input calcolare la media utilizzando le liste

            double voto1 = Convert.ToDouble(Console.ReadLine());
            double voto2 = Convert.ToDouble(Console.ReadLine());
            double voto3 = Convert.ToDouble(Console.ReadLine());
            double voto4 = Convert.ToDouble(Console.ReadLine());
            double voto5 = Convert.ToDouble(Console.ReadLine());

            List<double> valutazioni = new List<double>();

                valutazioni.Add(voto1);
                valutazioni.Add(voto2);
                valutazioni.Add(voto3);
                valutazioni.Add(voto4);
                valutazioni.Add(voto5);

            double media = valutazioni.Average();
            Console.WriteLine();
            Console.WriteLine("La tua media è di " + media);

            /*double votoMinimo = valutazioni.Min();
            double votoMassimo = valutazioni.Max();

            Console.WriteLine(votoMinimo);
            Console.WriteLine(votoMassimo); */

            double max = valutazioni[0], min = valutazioni[0];

            /*
             Spiegazioni: assegnia un valore di partenza a max e min, consigliato il primo posto della lista [0]
            crei un for che si ripeta tante volte quanti sono gli elementi della lista
            dentro il for fai un if che controlla se max è maggiore e minore della variabile di for allora indichi che max e min sono uguali alla variabile di for
             */

            for (int i = 0; i < valutazioni.Count; i++)
            {
                if(max < valutazioni[i])
                {
                    max = valutazioni[i];
                }
                // ------------------------------------------------------

                if(min > valutazioni[i])
                {
                    min = valutazioni[i];
                }
            }

            Console.WriteLine("Il voto massimo è " + max);
            Console.WriteLine("Il voto minimo è " + min);


            Console.ReadLine();

        }
    }
}
