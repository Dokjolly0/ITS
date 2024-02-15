using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Commenti
            /*Multilinea*/
            Console.WriteLine("Benvenuti nel corso di C#");

            //Così si dchiara una variabile, prima scegli il tipo
            System.Double prezzo;
            System.Int32 quantita;
            double iva, prezzoFinale, imponibile;
            //Inizializziamo le variabili
            prezzo = 45.9;
            quantita = 2;
            imponibile = prezzo * quantita;
            iva = prezzo + prezzo * 0.22;
            prezzoFinale = iva * quantita;

            Console.WriteLine("Il prezzo totale è di " + imponibile + " euro.");
            Console.WriteLine("Il prezzo totale ivato è di " + prezzoFinale + " euro.");
            Console.ReadLine();
        }
    }
}
