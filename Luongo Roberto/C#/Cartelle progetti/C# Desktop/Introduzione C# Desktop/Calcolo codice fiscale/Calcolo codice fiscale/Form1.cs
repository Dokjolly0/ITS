using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calcolo_codice_fiscale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CalcoloCodiceFiscale.Click += Calcolo;
        }

        private void Calcolo(object sender, EventArgs e)
        {
            try
            {
                CodiceFiscale.Clear();
                List<string> listaCognome = new List<string>();
                string cognome = Cognome.Text.ToLower();

                {
                    for (int i = 0, imax = cognome.Length; i < imax; i++)
                    {
                        string lettera = cognome.Substring(i, 1);
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
                            listaCognome.Add(consonante.ToUpper());
                        }
                    }
                    if (listaCognome.Count < 3)
                    {
                        for (int i = 0, imax = cognome.Length; i < imax; i++)
                        {
                            string lettera = cognome.Substring(i, 1);
                            if (
                                lettera == "a" || lettera == "e" || lettera == "i" || lettera == "o" || lettera == "u" ||
                                lettera == "à" || lettera == "è" || lettera == "ì" || lettera == "ò" || lettera == "ù" ||
                                lettera == "á" || lettera == "é" || lettera == "í" || lettera == "ó" || lettera == "ú")
                            {
                                string vocale = lettera;
                                listaCognome.Add(vocale.ToUpper());
                            }
                        }
                    }
                    if (listaCognome.Count < 3)
                    {
                        listaCognome.Add("X");
                    }
                    for (Int32 i = 0; i < 3; i++)
                    {
                        this.CodiceFiscale.Text += listaCognome[i];
                    }


                    List<string> listaNome = new List<string>();
                    string nome = Nome.Text.ToLower();

                    for (int i = 0, imax = nome.Length; i < imax; i++)
                    {
                        string lettera = nome.Substring(i, 1);
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
                            listaNome.Add(consonante.ToUpper());
                        }
                    }
                    if (listaNome.Count < 3)
                    {
                        for (int i = 0, imax = nome.Length; i < imax; i++)
                        {
                            string lettera = nome.Substring(i, 1);
                            if (
                                lettera == "a" || lettera == "e" || lettera == "i" || lettera == "o" || lettera == "u" ||
                                lettera == "à" || lettera == "è" || lettera == "ì" || lettera == "ò" || lettera == "ù" ||
                                lettera == "á" || lettera == "é" || lettera == "í" || lettera == "ó" || lettera == "ú")
                            {
                                string vocale = lettera;
                                listaNome.Add(vocale.ToUpper());
                            }
                        }
                    }
                    if (listaNome.Count < 3)
                    {
                        listaNome.Add("X");
                    }
                    for (Int32 i = 0; i < 3; i++)
                    {
                        this.CodiceFiscale.Text += listaNome[i];
                    }
                    int annoDiNascita = DatadiNascita.Value.Year;
                    string anno = annoDiNascita.ToString();
                    anno = anno.Substring(2, 2);
                    this.CodiceFiscale.Text += anno;

                    int meseDiNascita = DatadiNascita.Value.Month;
                    int numeriMese;
                    string letteraMese;
                    switch (meseDiNascita)
                    {
                        case 1: letteraMese = "A"; this.CodiceFiscale.Text += letteraMese; ; break;
                        case 2: letteraMese = "B"; this.CodiceFiscale.Text += letteraMese; break;
                        case 3: letteraMese = "C"; this.CodiceFiscale.Text += letteraMese; break;
                        case 4: letteraMese = "D"; this.CodiceFiscale.Text += letteraMese; break;
                        case 5: letteraMese = "E"; this.CodiceFiscale.Text += letteraMese; break;
                        case 6: letteraMese = "H"; this.CodiceFiscale.Text += letteraMese; break;
                        case 7: letteraMese = "L"; this.CodiceFiscale.Text += letteraMese; break;
                        case 8: letteraMese = "M"; this.CodiceFiscale.Text += letteraMese; break;
                        case 9: letteraMese = "P"; this.CodiceFiscale.Text += letteraMese; break;
                        case 10: letteraMese = "R"; this.CodiceFiscale.Text += letteraMese; break;
                        case 11: letteraMese = "S"; this.CodiceFiscale.Text += letteraMese; break;
                        case 12: letteraMese = "T"; this.CodiceFiscale.Text += letteraMese; break;
                    }

                    int giornoDINascita = DatadiNascita.Value.Day;
                    string sesso = Sesso.Text.ToUpper();
                    string M = "M";
                    string F = "F";
                    if (sesso == M)
                    {
                        this.CodiceFiscale.Text += giornoDINascita;
                    }
                    else if (sesso == F)
                    {
                        this.CodiceFiscale.Text += giornoDINascita + 40;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Attenzione, i dati sono incorretti o mancanti!");
            }     
        }

    }
}
    
    

