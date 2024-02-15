using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String email = "alexviolattolibero,it@gmail.com";
            int lettereemail = email.Length;
            
            Console.WriteLine("Email: " + email);
            String password;
            int letterepassword = 0;

            while (letterepassword < 8) {
                Console.Write("Inserisci una password: ");
                password = Console.ReadLine();
                letterepassword = password.Length;
                if(letterepassword < 8)
                {
                    Console.WriteLine("Input errarto");
                }
            }

            string messaggio = "Interpretazione";
            string messaggio2 = messaggio.Substring(4, 2);//primo numero = dalla posizione dove vuoi partire|Secondo numero = Quante lettere vuoi prendere
            Console.WriteLine(messaggio2);

            string parola = Console.ReadLine();
            for (int i = 0; i < parola.Length; i++)
            {
                Console.WriteLine(parola[i]);
            }
            Console.WriteLine();
            Console.WriteLine(parola);

            Console.ReadLine(); 
        }
    }
}
