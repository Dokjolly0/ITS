using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Chiedere in imput 3 numeri
            // Se il primo numero è 1 allora scrivi x, se è 2 allora scrivi xx fino a 10
            //fai il controllo che possano essere inseriti nei 3 numeri solo numeri da 1 a 10
            //fallo con un ciclo for e con un ciclo while

            //stampa una tavola pitagorica (tabelline da 1 a 10) con un ciclo for e con un ciclo while



            //Colonne
            for (int numero = 1; numero <= 20; numero++)
            {
                //Righe
                for (int numero2 = 1; numero2 <= 10; numero2++)
                {
                    int risultato = numero * numero2;
                    Console.Write(risultato + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

     }
}
