using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizi_algoritmi_e_strutture_dati
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                /*
                   try
            {
                    Console.WriteLine("Inserisci un formato di carta in scala A (da 0 a 12)");
                    string stringaNumero = Console.ReadLine();
                    int numero = Convert.ToInt32(stringaNumero);
                    while (numero < 0 || numero > 12) 
                    {
                        if (numero < 0 || numero > 12)
                        {
                            Console.WriteLine("Inserisci un formato di carta in scala A (da 0 a 12)");
                            stringaNumero = Console.ReadLine();
                            numero = Convert.ToInt32(stringaNumero);
                        }
                    }
                    switch (numero)
                    {
                        case 0: Console.WriteLine("La misura è 841 x 1189 millimetri"); break;
                        case 1: Console.WriteLine("La misura è 594 x 841 millimetri"); break;
                        case 2: Console.WriteLine("La misura è 420 x 594 millimetri"); break;
                        case 3: Console.WriteLine("La misura è 297 x 420 millimetri"); break;
                        case 4: Console.WriteLine("La misura è 210 x 297 millimetri"); break;
                        case 5: Console.WriteLine("La misura è 148 x 210 millimetri"); break;
                        case 6: Console.WriteLine("La misura è 105 x 148 millimetri"); break;
                        case 7: Console.WriteLine("La misura è 74 x 105 millimetri"); break;
                        case 8: Console.WriteLine("La misura è 52 x 74 millimetri"); break;
                        case 9: Console.WriteLine("La misura è 37 x 52 millimetri"); break;
                        case 10: Console.WriteLine("La misura è 26 x 37 millimetri"); break;
                        case 11: Console.WriteLine("La misura è 18 x 26 millimetri"); break;
                        case 12: Console.WriteLine("La misura è 13 x 18 millimetri"); break;
                    }
                    Console.ReadKey();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Eccezione: " + ex.ToString());
                    Console.ReadKey();
                }*/
            }/*Ex 1 (Calcolo dimensione fogli)*/

            {
                /*
                try 
                {
                    while (true)
                    {
                        Console.WriteLine("Inserisci un numero per controllare se è pari o dispari: ");
                        string stringaNumero = Console.ReadLine();
                        double numero = Convert.ToDouble(stringaNumero);
                        if (numero % 2 == 0) 
                        {
                            Console.WriteLine("Il numero è pari");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Il numero è dispari");
                            Console.WriteLine();
                        }
                    }
                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.ReadKey();
                }*/
            }/*Ex 02 (Verifica pari/dispari)*/

            {
                /*
                try
                {
                    while (true)
                    {
                        Console.WriteLine("Inserisci le misure del rettangolo: ");
                        Console.Write("Base (cm): ");
                        string stringaBase = Console.ReadLine();
                        double Base = Convert.ToInt32(stringaBase);
                        Console.Write("Altezza (cm): ");
                        string stringaAltezza = Console.ReadLine();
                        double Altezza = Convert.ToInt32(stringaAltezza);
                        
                        double calcolaPerimetro(double B, double A){
                            double perimetro = (B * 2) + (A * 2);
                            Console.WriteLine("Il perimetro del rettangolo è di " + perimetro + " centimetri");
                            return perimetro;
                        }
                        calcolaPerimetro(Base, Altezza);
                        double calcolaArea(double B, double A)
                        {
                            double area = B * A;
                            Console.WriteLine("Il perimetro del rettangolo è di " + area + " centimetri");
                            return area;
                        }
                        calcolaArea(Base, Altezza);
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eccezione: " + ex.ToString());
                }*/
            }/*Ex 3 (perimetro/area rettangolo)*/

            {
                /*
                try
                {
                    while (true)
                    {
                        Console.Write("Prezzo: ");
                        string Sprezzo = Console.ReadLine();
                        double prezzo = Convert.ToDouble(Sprezzo);

                        Console.Write("sconto: ");
                        string Ssconto = Console.ReadLine();
                        double sconto = Convert.ToDouble(Ssconto);

                        double prezzoScontato = (prezzo / 100) * sconto;
                        prezzoScontato = prezzo - prezzoScontato;
                        Console.WriteLine(prezzoScontato);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eccezione: " + ex.ToString());
                    Console.ReadKey();
                }*/
            }/*Ex 4 (calcola sconto)*/

            {
                /*
                try
                {
                    while (true)
                    {
                        Console.Write("Esito verifica in decimali: ");
                        string Spunteggio = Console.ReadLine();
                        double punteggio = Convert.ToDouble(Spunteggio);

                        if (punteggio < 60)
                        {
                            Console.WriteLine("Bocciato!");
                        }
                        else
                        {
                            Console.WriteLine("Promosso!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eccezione: " + ex.ToString());
                    Console.ReadKey();
                }*/
            }/*Ex 5 (promosso/bocciato)*/

            {
                try
                {
                    while (true)
                    {
                        Console.Write("Numero: ");
                        string num = Console.ReadLine();
                        for (int i = 0; i < num.Length; i++)
                        {
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eccezione: " + ex.ToString());
                }
            }/*Ex 6*/
        }
    }
}
/*
                try
                {
                    while (true)
                    {

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Eccezione: " + ex.ToString());
                    Console.ReadKey();
                }
*/