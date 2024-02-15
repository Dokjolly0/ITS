using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nome__cognome__eta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cognome, anni, nome;
            int eta;
            {
                Console.WriteLine("Inserisci il tuo cognome: ");
                Console.Write("Cognome: ");
                cognome = Console.ReadLine();
                bool verificaCognome = cognome.Any(x => char.IsDigit(x));
                //Versione scritta bene
                //foreach (char c in cognome) { if (char.IsDigit(c)) { verificaCognome = true; break; } }
                while (cognome.Count() < 2 || verificaCognome == true)
                {
                    if (cognome.Count() < 2 || verificaCognome == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Inserisci un cognome valido");
                        Console.Write("Cognome: ");
                        cognome = Console.ReadLine();
                    }
                    verificaCognome = int.TryParse(cognome, out eta);
                }
                Console.WriteLine();
            }//Cognome
            {
                Console.WriteLine("Inserisci il tuo nome: ");
                Console.Write("nome: ");
                nome = Console.ReadLine();
                bool verificaNome = nome.Any(x => char.IsDigit(x));
                while (nome.Count() < 2 || verificaNome == true)
                {
                    if (nome.Count() < 2 || verificaNome == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Inserisci un nome valido");
                        Console.Write("Nome: ");
                        nome = Console.ReadLine();
                    }
                    verificaNome = int.TryParse(nome, out eta);
                }
                Console.WriteLine();
            }//Nome
            {
                Console.WriteLine("Inserisci la tua età: ");
                Console.Write("Età: ");
                anni = Console.ReadLine();
                bool verificaEta = int.TryParse(anni, out eta);

                while (verificaEta == false || eta < 0 || eta > 121)
                {
                    if (verificaEta == false || eta < 0 || eta > 121)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Inserisci un età valida!");
                        Console.WriteLine("Inserisci la tua età: ");
                        Console.Write("Età: ");
                        anni = Console.ReadLine();
                    }
                    verificaEta = int.TryParse(anni, out eta);
                }
            }//Eta
            Console.WriteLine();
            Console.WriteLine($"Il tuo cognome è {cognome}, il tuo nome è {nome} e hai {eta} anni.");
            Console.ReadKey();
        }
    }
}
