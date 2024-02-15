using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Dipendente
    {
        public string Nome {  get; set; }
        public string Cognome { get; set; }
        public string Sesso { get; set; }
        public int GiornoDiNascita { get; set; }
        public string MEseDiNascita { get; set; }
        public int AnnoDiNascita { get; set; }
        public string ComuneDiNascita { get; set; }
        public string CodiceFiscale { get; set; }

        public Dipendente( )
        {
            
        }

        public string FunzionaCalcolo()
        {
            try
            {
                List<string> CodiceFiscaleCognome = new List<string>();
                List<string> CodiceFiscaleNome = new List<string>();
                Cognome=Cognome.ToLower();
                Nome=Nome.ToLower();

                for (int i = 0, imax = Cognome.Length; i < imax; i++)
                {
                    string lettera = Cognome.Substring(i, 1);
                    if (
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
                        CodiceFiscaleCognome.Add(consonante.ToUpper());
                    }
                }
                if (CodiceFiscaleCognome.Count < 3)
                {
                    for (int i = 0, imax = Cognome.Length; i < imax; i++)
                    {
                        string lettera = Cognome.Substring(i, 1);
                        if (
                            lettera == "a" || lettera == "e" || lettera == "i" || lettera == "o" || lettera == "u" ||
                            lettera == "à" || lettera == "è" || lettera == "ì" || lettera == "ò" || lettera == "ù" ||
                            lettera == "á" || lettera == "é" || lettera == "í" || lettera == "ó" || lettera == "ú")
                        {
                            string vocale = lettera;
                            CodiceFiscaleCognome.Add(vocale.ToUpper());
                        }
                    }
                }
                if (CodiceFiscaleCognome.Count < 3)
                {
                    CodiceFiscaleCognome.Add("X");
                }
                for (Int32 i = 0; i < 3; i++)
                {
                    this.CodiceFiscale += CodiceFiscaleCognome[i];
                }

                //

                for (int i = 0, imax = Nome.Length; i < imax; i++)
                {
                    string lettera = Nome.Substring(i, 1);
                    if (
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
                        CodiceFiscaleCognome.Add(consonante.ToUpper());
                    }
                }
                if (CodiceFiscaleCognome.Count < 3)
                {
                    for (int i = 0, imax = Nome.Length; i < imax; i++)
                    {
                        string lettera = Nome.Substring(i, 1);
                        if (
                            lettera == "a" || lettera == "e" || lettera == "i" || lettera == "o" || lettera == "u" ||
                            lettera == "à" || lettera == "è" || lettera == "ì" || lettera == "ò" || lettera == "ù" ||
                            lettera == "á" || lettera == "é" || lettera == "í" || lettera == "ó" || lettera == "ú")
                        {
                            string vocale = lettera;
                            CodiceFiscaleNome.Add(vocale.ToUpper());
                        }
                    }
                }
                for (int i = 0, imax = Nome.Length; i < imax; i++)
                {
                    string lettera = Nome.Substring(i, 1);
                    if (
                        lettera == "a" || lettera == "e" || lettera == "i" || lettera == "o" || lettera == "u" ||
                        lettera == "à" || lettera == "è" || lettera == "ì" || lettera == "ò" || lettera == "ù" ||
                        lettera == "á" || lettera == "é" || lettera == "í" || lettera == "ó" || lettera == "ú")
                    {
                        string vocale = lettera;
                    }
                    else
                    {
                        string consonante = lettera;
                        CodiceFiscaleNome.Add(consonante.ToUpper());
                    }
                }
                while (CodiceFiscaleNome.Count < 3)
                {
                    for (int i = 0, imax = Nome.Length; i < imax; i++)
                    {
                        string lettera = Nome.Substring(i, 1);
                        if (
                            lettera == "a" || lettera == "e" || lettera == "i" || lettera == "o" || lettera == "u" ||
                            lettera == "à" || lettera == "è" || lettera == "ì" || lettera == "ò" || lettera == "ù" ||
                            lettera == "á" || lettera == "é" || lettera == "í" || lettera == "ó" || lettera == "ú")
                        {
                            string vocale = lettera;
                            CodiceFiscaleNome.Add(vocale.ToUpper());
                        }
                    }
                }
                while (CodiceFiscaleNome.Count < 3)
                {
                    CodiceFiscaleNome.Add("X");
                }
                for (Int32 i = 0; i < 3; i++)
                {
                    this.CodiceFiscale += CodiceFiscaleNome[i];
                }


                //


                string anno = AnnoDiNascita.ToString();
                anno = anno.Substring(2, 2);
                this.CodiceFiscale += anno;

                /*if(anno.Length == 1)
                {
                    anno = AnnoDiNascita.ToString();
                    anno = anno.Substring(0, 1);
                    this.CodiceFiscale += anno;
                }
                else if(anno.Length == 2)
                {
                    anno = AnnoDiNascita.ToString();
                    anno = anno.Substring(0, 2);
                    this.CodiceFiscale += anno;
                }
                else if (anno.Length == 3)
                {
                    anno = AnnoDiNascita.ToString();
                    anno = anno.Substring(1, 2);
                    this.CodiceFiscale += anno;
                }*/


                //

                string Mese = MEseDiNascita;

                switch (Mese)
                {
                    case "1": Mese = this.CodiceFiscale += "A"; break;
                    case "2": Mese = this.CodiceFiscale += "B"; break;
                    case "3": Mese = this.CodiceFiscale += "C"; break;
                    case "4": Mese = this.CodiceFiscale += "D"; break;
                    case "5": Mese = this.CodiceFiscale += "E"; break;
                    case "6": Mese = this.CodiceFiscale += "H"; break;
                    case "7": Mese = this.CodiceFiscale += "L"; break;
                    case "8": Mese = this.CodiceFiscale += "M"; break;
                    case "9": Mese = this.CodiceFiscale += "P"; break;
                    case "10": Mese = this.CodiceFiscale += "R"; break;
                    case "11": Mese = this.CodiceFiscale += "S"; break;
                    case "12": Mese = this.CodiceFiscale += "T"; break;
                }


                //


                if (Sesso == "M")
                {
                    GiornoDiNascita = GiornoDiNascita;
                    this.CodiceFiscale += GiornoDiNascita;
                }
                else if (Sesso == "F")
                {
                    GiornoDiNascita = GiornoDiNascita + 40;
                    this.CodiceFiscale += GiornoDiNascita;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Attenzione, i dati sono incorretti o mancanti!");
            }

            return this.CodiceFiscale;

        }

    }
}
/*
 for (int i = 0, imax = Nome.Length; i < imax; i++)
                {
                    string lettera = Nome.Substring(i, 1);
                    if (
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
                        CodiceFiscaleCognome.Add(consonante.ToUpper());
                    }
                }
                if (CodiceFiscaleCognome.Count < 3)
                {
                    for (int i = 0, imax = Nome.Length; i < imax; i++)
                    {
                        string lettera = Nome.Substring(i, 1);
                        if (
                            lettera == "a" || lettera == "e" || lettera == "i" || lettera == "o" || lettera == "u" ||
                            lettera == "à" || lettera == "è" || lettera == "ì" || lettera == "ò" || lettera == "ù" ||
                            lettera == "á" || lettera == "é" || lettera == "í" || lettera == "ó" || lettera == "ú")
                        {
                            string vocale = lettera;
                            CodiceFiscaleNome.Add(vocale.ToUpper());
                        }
                    }
                }
                for (int i = 0, imax = Nome.Length; i < imax; i++)
                {
                    string lettera = Nome.Substring(i, 1);
                    if (
                        lettera == "a" || lettera == "e" || lettera == "i" || lettera == "o" || lettera == "u" ||
                        lettera == "à" || lettera == "è" || lettera == "ì" || lettera == "ò" || lettera == "ù" ||
                        lettera == "á" || lettera == "é" || lettera == "í" || lettera == "ó" || lettera == "ú")
                    {
                        string vocale = lettera;
                    }
                    else
                    {
                        string consonante = lettera;
                        CodiceFiscaleNome.Add(consonante.ToUpper());
                    }
                }
                if (CodiceFiscaleNome.Count < 3)
                {
                    for (int i = 0, imax = Nome.Length; i < imax; i++)
                    {
                        string lettera = Nome.Substring(i, 1);
                        if (
                            lettera == "a" || lettera == "e" || lettera == "i" || lettera == "o" || lettera == "u" ||
                            lettera == "à" || lettera == "è" || lettera == "ì" || lettera == "ò" || lettera == "ù" ||
                            lettera == "á" || lettera == "é" || lettera == "í" || lettera == "ó" || lettera == "ú")
                        {
                            string vocale = lettera;
                            CodiceFiscaleNome.Add(vocale.ToUpper());
                        }
                    }
                }
                if (CodiceFiscaleNome.Count < 3)
                {
                    CodiceFiscaleNome.Add("X");
                }
                for (Int32 i = 0; i < 3; i++)
                {
                    this.CodiceFiscale += CodiceFiscaleNome[i];
                }

                // 

                if (Sesso == "M")
                {
                    GiornoDiNascita = GiornoDiNascita;
                    this.CodiceFiscale += GiornoDiNascita;
                }else if(Sesso == "F")
                {
                    GiornoDiNascita = GiornoDiNascita + 40;
                    this.CodiceFiscale += GiornoDiNascita;
                }

                //

                switch (MEseDiNascita)
                {
                    case "1": MEseDiNascita = this.CodiceFiscale += "A"; break;
                    case "2": MEseDiNascita = this.CodiceFiscale += "B"; break;
                    case "3": MEseDiNascita = this.CodiceFiscale += "C"; break;
                    case "4": MEseDiNascita = this.CodiceFiscale += "D"; break;
                    case "5": MEseDiNascita = this.CodiceFiscale += "E"; break;
                    case "6": MEseDiNascita = this.CodiceFiscale += "H"; break;
                    case "7": MEseDiNascita = this.CodiceFiscale += "L"; break;
                    case "8": MEseDiNascita = this.CodiceFiscale += "M"; break;
                    case "9": MEseDiNascita = this.CodiceFiscale += "P"; break;
                    case "10": MEseDiNascita = this.CodiceFiscale += "R"; break;
                    case "11": MEseDiNascita = this.CodiceFiscale += "S"; break;
                    case "12": MEseDiNascita = this.CodiceFiscale += "T"; break;
                }

                string anno = MEseDiNascita.ToString();
                anno = anno.Substring(2, 2);
                this.CodiceFiscale = anno;
 */
