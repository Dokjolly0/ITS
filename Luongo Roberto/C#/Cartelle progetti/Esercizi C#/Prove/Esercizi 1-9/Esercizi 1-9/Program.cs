using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi_1_9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*
            //Ex 1
            string nome, cognome;
            Console.WriteLine("Inserisci il tuo nome: ");
            nome = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo cognome: ");
            cognome = Console.ReadLine();
            Console.WriteLine($"ciao {nome} {cognome}, benvenuto nel sito!");
            Console.ReadKey();

            //Ex 2
            string cognome, anni;
            int eta = 0, a = 0;
            Console.WriteLine("Inserisci il tuo cognome: ");
            Console.Write("Cognome:");
            cognome = Console.ReadLine();
            while (cognome.Count() < 2)
            {
                if (cognome.Count() < 2)
                {
                    Console.WriteLine("Inserisci un nome valido");
                    Console.Write("Cognome:");
                    cognome = Console.ReadLine();
                }
            }
            Console.WriteLine("Inserisci la tua età: ");
            Console.Write("Età:");
            anni = Console.ReadLine();
            while (a >= 0 && a < 120)
            {
                if (
                    anni != "00" && anni != "01" && anni != "02" && anni != "03" && anni != "04" &&
                    anni != "05" && anni != "06" && anni != "07" && anni != "08" && anni != "09" &&
                    anni != "0" && anni != "1" && anni != "2" && anni != "3" && anni != "4" &&
                    anni != "5" && anni != "6" && anni != "7" && anni != "8" && anni != "9" &&
                    anni != "10" && anni != "11" && anni != "12" && anni != "13" && anni != "14" &&
                    anni != "15" && anni != "16" && anni != "17" && anni != "18" && anni != "19" &&
                    anni != "20" && anni != "21" && anni != "22" && anni != "23" && anni != "24" &&
                    anni != "25" && anni != "26" && anni != "27" && anni != "28" && anni != "29" &&
                    anni != "30" && anni != "31" && anni != "32" && anni != "33" && anni != "34" &&
                    anni != "35" && anni != "36" && anni != "37" && anni != "38" && anni != "39" &&
                    anni != "40" && anni != "41" && anni != "42" && anni != "43" && anni != "44" &&
                    anni != "45" && anni != "46" && anni != "47" && anni != "48" && anni != "49" &&
                    anni != "50" && anni != "51" && anni != "52" && anni != "53" && anni != "54" &&
                    anni != "55" && anni != "56" && anni != "57" && anni != "58" && anni != "59" &&
                    anni != "60" && anni != "61" && anni != "62" && anni != "63" && anni != "64" &&
                    anni != "65" && anni != "66" && anni != "67" && anni != "68" && anni != "69" &&
                    anni != "70" && anni != "71" && anni != "72" && anni != "73" && anni != "74" &&
                    anni != "75" && anni != "76" && anni != "77" && anni != "78" && anni != "79" &&
                    anni != "80" && anni != "81" && anni != "82" && anni != "83" && anni != "84" &&
                    anni != "85" && anni != "86" && anni != "87" && anni != "88" && anni != "89" &&
                    anni != "90" && anni != "91" && anni != "92" && anni != "93" && anni != "94" &&
                    anni != "95" && anni != "96" && anni != "97" && anni != "98" && anni != "99" &&
                    anni != "100" && anni != "101" && anni != "102" && anni != "103" && anni != "104" &&
                    anni != "105" && anni != "106" && anni != "107" && anni != "108" && anni != "109" &&
                    anni != "110" && anni != "111" && anni != "112" && anni != "113" && anni != "114" &&
                    anni != "115" && anni != "116" && anni != "117" && anni != "118" && anni != "119"
                )
                {
                    Console.WriteLine("Inserisci un età valida!");
                    Console.WriteLine("Inserisci la tua età: ");
                    Console.Write("Età:");
                    anni = Console.ReadLine();
                }
                else
                {
                    eta = Convert.ToInt32(anni);
                    a = eta;
                    break;
                }
            }
            Console.WriteLine($"Il tuo cognome è {cognome} e hai {eta} anni.");
            Console.ReadKey();
            

            try
            {
                Console.WriteLine("Inserisci un numero e in base al risultato avrai la lunghezza rispettiva di un foglio: ");
                Console.Write("Numero: ");
                string letteraNumero = Console.ReadLine();
                int numero = Convert.ToInt32(letteraNumero);
                switch (numero)
                {
                    case 0:
                        Console.WriteLine("841mm x 1189mm");
                        break;

                    case 1:
                        Console.WriteLine("594mm x 841mm");
                        break;
                    case 2:
                        Console.WriteLine("420mm x 594mm");
                        break;

                    case 3:
                        Console.WriteLine("297mm x 420mm");
                        break;
                    case 4:
                        Console.WriteLine("210mm x 297mm");
                        break;

                    case 5:
                        Console.WriteLine("148mm x 210mm");
                        break;
                    case 6:
                        Console.WriteLine("105mm x 148mm");
                        break;

                    case 7:
                        Console.WriteLine("74mm x 105mm");
                        break;
                    case 8:
                        Console.WriteLine("52mm x 74mm");
                        break;

                    case 9:
                        Console.WriteLine("37mm x 52mm");
                        break;
                    case 10:
                        Console.WriteLine("26mm x 37mm");
                        break;

                    case 11:
                        Console.WriteLine("18mm x 26mm");
                        break;
                    case 12:
                        Console.WriteLine("13mm x 18mm");
                        break;
                    default:
                        Console.WriteLine("Non hai inserito un numro valido!");
                        break;

                }
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Inserisci un numero valido!");
                Console.ReadKey();
            }



            Console.WriteLine("Somma 2 numeri in input: ");
            Console.Write("Numero 1: ");
            string numero = Console.ReadLine();
            int Numero = Convert.ToInt32(numero);
            Console.Write("Numero 2: ");
            string numero1 = Console.ReadLine();
            int Numero1 = Convert.ToInt32(numero1);
            Console.WriteLine(Numero + Numero1);
            Console.ReadKey();



            Console.WriteLine("Calcola prezzo scontato: ");
            Console.Write("Prezzo: ");
            string prezzo = Console.ReadLine();
            double Prezzo = Convert.ToDouble(prezzo);
            Console.WriteLine("Sconto in percentuale: ");
            Console.Write("Sconto: ");
            string sconto = Console.ReadLine();
            double Sconto = Convert.ToDouble(sconto);
            //Metodo alternativo
            //double PrezzoFinale = (Prezzo / 100) * Sconto;
            Console.WriteLine("Prezzo scontato: ");
            Console.Write(Prezzo-((Prezzo/100) * Sconto));
            Console.ReadKey();



            bool promosso;
            Console.WriteLine("Verifica al promozione: ");
            Console.Write("Voto: ");
            string voto = Console.ReadLine();
            double Voto = Convert.ToDouble(voto);
            if(Voto >= 60)
            {
                promosso = true;
                Console.WriteLine(promosso);
            }
            else
            {
                promosso= false;
                Console.WriteLine(promosso);
            }
            Console.ReadKey();


            //
            //PROBLEMA CON IL CODICE FISCALE RISOLTO
            //
            Console.WriteLine("Inserisci un numero: ");
            Console.Write("Numero: ");
            string numero = Console.ReadLine();
            string cifra = "0";

            //Crei una variabile totale
            int tot = 0;
            for (int i = 0, imax = numero.Length; i < imax; i++)
            {
                //Dividi le cifre
                cifra = numero.Substring(i, 1);
                //Converti in int la cifra
                int Cifra = Convert.ToInt32(cifra);
                //Aggiungi la cifra al totale
                tot += Cifra;
                //tot = tot + cifra (sono uguali)
            }
            if (tot%3 == 0)
            {
                Console.WriteLine($"Il numero è {tot}, ed è divisibile per 3");
            }
            else { Console.WriteLine($"Il numero è {tot}, e non è divisibile per 3, ti da di resto {tot % 3}"); }*/














            
                Console.WriteLine("Scrivi qualcosa: ");

                //Input user
                string input = Console.ReadLine();
                Console.WriteLine();
                double numInput;
                //Verifica che sia un numero

                bool Bnumero = double.TryParse(input, out numInput);
                
                    //è una parola
                    if (Bnumero ==  false )
                    {
                        Console.WriteLine("Hai scritto una parola! ");
                    }
                    if (input == "code")
                    {
                        Console.WriteLine($"{input} è proprio la mia parola preferita!");
                    }
                    else if (input != "code" && Bnumero == false)
                    {
                        Console.WriteLine($"{input} non è la mia parola preferita, la mia parola preferita è: \"code\" ");
                    }
                
                    //è un numero
                    if (Bnumero == true)
                    {
                        Console.WriteLine("Hai scritto un numero! ");
                        if (numInput == 10)
                        {
                            Console.WriteLine($"{numInput} è proprio il mio numero preferito!");
                        }
                        else if (numInput != 10)
                        {
                            Console.WriteLine($"{numInput} non è il mio numero preferito, il mio numero preferito è: 10");
                        }
                    }

                    Console.ReadKey();

















        }
    }
}