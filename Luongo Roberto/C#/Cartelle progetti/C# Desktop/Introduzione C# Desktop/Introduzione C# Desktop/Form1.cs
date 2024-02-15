using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Introduzione_C__Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Il codice va inserito qui
            this.Piu.Click += addizzione;
            this.Divisione.Click += divisione;
            this.Clear.Click += clear;
        }

        private void clear(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                n1string = this.BoxNumero1.Text;
                n2string = this.BoxNumero2.Text;
                risultatostring = this.BoxRisultato.Text;

                n1 = Convert.ToDouble(n1string);
                n2 = Convert.ToDouble(n2string);

                BoxNumero1.Clear();
                BoxNumero2.Clear();
            }
            catch (Exception)
            {

            }
        }

        string n1string, n2string, risultatostring;
        double n1, n2, risultato;

        private void divisione(object sender, EventArgs e)
        {
            if(n2 == 0)
            {
                MessageBox.Show("è impossibile dividere un numero per 0!");
                return;
            }

            //throw new NotImplementedException();
            n1string = this.BoxNumero1.Text;
            n2string = this.BoxNumero2.Text;
            risultatostring = this.BoxRisultato.Text;

            n1 = Convert.ToDouble(n1string);
            n2 = Convert.ToDouble(n2string);

            risultato = (n1 / n2);
            this.BoxRisultato.Text = risultato.ToString();
        }

        private void addizzione(object sender, EventArgs e)
        {
            try
            {
                //Questa è un eccezzione e la metti in commento
                //row new NotImplementedException();
                if (BoxNumero1.Text == "" || BoxNumero2.Text == "" )
                {
                    MessageBox.Show("Attenzione, devi inserire un numero");
                    return;
                }

                //MessageBox.Show("Alert");
                n1string = this.BoxNumero1.Text;
                n2string = this.BoxNumero2.Text;
                risultatostring = this.BoxRisultato.Text;

                n1 = Convert.ToDouble(n1string);
                n2 = Convert.ToDouble(n2string);

                risultato = (n1 + n2);
                this.BoxRisultato.Text = risultato.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Attenzione, puoi inserire solo numeri!");
            }
        }
    }
}
