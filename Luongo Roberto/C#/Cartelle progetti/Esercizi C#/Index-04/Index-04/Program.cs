using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci un importo in euro e verrà convertito in tutte le altre valute:");

            string Euro;
            double CifraEuro, CifraDollari, CifraSterline, CifraYen;

            try
            {
                Euro = Console.ReadLine();
                CifraEuro = Convert.ToDouble(Euro);
                CifraSterline = CifraEuro * 0.87;
                CifraYen = CifraEuro * 161.06;
                CifraDollari = CifraEuro * 0.94;

                Console.WriteLine();
                Console.WriteLine("In sterline sono: " + CifraSterline + " euro:");
                Console.WriteLine("In yen sono: " + CifraYen + " euro:");
                Console.WriteLine("In dollari sono: " + CifraDollari + " euro:");

            }
            catch (Exception)
            {
                Console.WriteLine("Cè un errore nell'inserimento della cifra da convertire");
            }
            finally {
                Console.ReadLine();
            }
        }
    }
}
