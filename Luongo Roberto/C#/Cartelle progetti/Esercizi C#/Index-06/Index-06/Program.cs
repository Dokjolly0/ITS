using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string voto;
            double votoFinale;
            
            try {
                Console.WriteLine("Inserisci il voto in decimali per conoscere la lettera collegata");

                Console.Write("Il tuo voto: ");
                voto = Console.ReadLine();
                votoFinale = Convert.ToDouble(voto);

                if (votoFinale > 0 && votoFinale <= 59)
                {
                    Console.WriteLine("Hai preso una F, mi spiace!");
                }
                else if (votoFinale >= 60 && votoFinale <= 69)
                {
                    Console.WriteLine("Hai preso una D, potevi fare meglio!");
                }
                else if (votoFinale >= 70 && votoFinale <= 79)
                {
                    Console.WriteLine("Hai preso una C, potevi fare meglio!");
                }
                else if (votoFinale >= 80 && votoFinale <= 89)
                {
                    Console.WriteLine("Hai preso una B, hai ottenuto un buon risultato!");
                }
                else if (votoFinale >= 90 && votoFinale <= 100)
                {
                    Console.WriteLine("Hai preso una A, sei uno dei migliori della classe!");
                }
                else { Console.WriteLine("Non hai inserito un numero valido");
                    Console.ReadLine();
                    //Esce dal ciclo attuale
                    return;
                }
            }

            catch (Exception ex) { Console.WriteLine("Hai scritto un numero incorretto"); }

            Console.WriteLine();
            Console.WriteLine("Ciclo for");
            Console.WriteLine();

            Int32 contatore;
            for(contatore = 10; contatore >=0; contatore--)
            {
                Console.WriteLine(contatore);
            }

            Console.WriteLine();
            Console.WriteLine("Ciclo while");
            Console.WriteLine();

            int numero = 0;
            while (numero < 20)
            {
                numero ++;
                Console.WriteLine(numero);
            };

            Console.ReadLine();

        }

    }
}
