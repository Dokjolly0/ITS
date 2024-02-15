using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cognome_12
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            //Crea una nuova app console che prende in input il cogniome di una persona e restituisce le prime 3 consonanti del cognome
            // + casi particolari

            Console.WriteLine("Calcolo codice fiscale: ");
            Console.WriteLine();


            {//Cognome
                Console.WriteLine("Inserisci il tuo cognome: ");
                Console.Write("Cognome: ");
                string cognome = Console.ReadLine();
                List<string> listaCognome = new List<string>();

                for (int i = 0, imax = cognome.Length; i < imax; i++)
                {
                    string lettera = cognome.Substring(i, 1);
                    if (
                        lettera == "a" || lettera == "e" || lettera == "i" || lettera == "o" || lettera == "u" ||
                        lettera == "à" || lettera == "è" || lettera == "ì" || lettera == "ò" || lettera == "ù" ||
                        lettera == "á" || lettera == "é" || lettera == "í" || lettera == "ó" || lettera == "ú" ||
                        lettera == " " || lettera == "'" || lettera == " " || lettera == "'" || lettera == "." ||
                        lettera == "1" || lettera == "2" || lettera == "3" || lettera == "4" || lettera == "5" ||
                        lettera == "6" || lettera == "7" || lettera == "8" || lettera == "9" || lettera == "0" ||
                        lettera == "," || lettera == ";" || lettera == ":" || lettera == "-" || lettera == "_" ||
                        lettera == "@" || lettera == "#" || lettera == "$" || lettera == "§" || lettera == "°" ||
                        lettera == "+" || lettera == "-" || lettera == "*" || lettera == "/" || lettera == "^" ||
                        lettera == "?" || lettera == "=" || lettera == "!" || lettera == "\"" || lettera == "£" ||
                        lettera == "$" || lettera == "%" || lettera == "&" || lettera == "(" || lettera == ")"
                        )
                    {
                        string vocale = lettera;
                    }
                    else
                    {
                        string consonante = lettera;
                        listaCognome.Add(consonante.ToUpper());
                    }
                }

                for (Int32 i = 0; i < 3; i++)
                {
                    Console.Write(listaCognome[i]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Inserisci il tuo Nome: ");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            List<string> listaNome = new List<string>();

            for (int i = 0, imax = nome.Length; i < imax; i++)
            {
                string lettera = nome.Substring(i, 1);
                if (
                    lettera == " " || lettera == "'" || lettera == " " || lettera == "'" || lettera == "." ||
                    lettera == "1" || lettera == "2" || lettera == "3" || lettera == "4" || lettera == "5" ||
                    lettera == "6" || lettera == "7" || lettera == "8" || lettera == "9" || lettera == "0" ||
                    lettera == "," || lettera == ";" || lettera == ":" || lettera == "-" || lettera == "_" ||
                    lettera == "@" || lettera == "#" || lettera == "$" || lettera == "§" || lettera == "°" ||
                    lettera == "+" || lettera == "-" || lettera == "*" || lettera == "/" || lettera == "^" ||
                    lettera == "?" || lettera == "=" || lettera == "!" || lettera == "\"" || lettera == "£" ||
                    lettera == "$" || lettera == "%" || lettera == "&" || lettera == "(" || lettera == ")"
                    )
                {
                    string simbolo = lettera;
                }
                else if(
                    lettera == "a" || lettera == "e" || lettera == "i" || lettera == "o" || lettera == "u" ||
                    lettera == "à" || lettera == "è" || lettera == "ì" || lettera == "ò" || lettera == "ù" ||
                    lettera == "á" || lettera == "é" || lettera == "í" || lettera == "ó" || lettera == "ú"
                    )
                {
                    string vocale = lettera;
                }
                else
                {
                    string consonante = lettera;
                    listaNome.Add(consonante.ToUpper());
                }
            }
            for (Int32 i = 0; i < 3; i++)
            {
                Console.Write(listaNome[i]);
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
