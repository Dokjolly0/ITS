using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.calcolo.Click += CalcoloCodiceFiscale;
        }
        private void CalcoloCodiceFiscale(object sender, EventArgs e)
        {
            List<Dipendente> mylist = new List<Dipendente>();
            Dipendente mylist1;
            string cf = "";
            
            mylist1 = new Dipendente
            {
                Nome = "Alex",
                Cognome = "Violatto",
                Sesso = "M",
                GiornoDiNascita = 14,
                MEseDiNascita = "9",
                AnnoDiNascita = 2003,
                ComuneDiNascita = "Camposampiero",
                CodiceFiscale = "",
            };
            cf= mylist1.FunzionaCalcolo();
            mylist1.CodiceFiscale=cf;
            Dipendente mylist2;
            mylist2 = new Dipendente
            {
                Nome = "Matteo",
                Cognome = "Zanellato",
                Sesso = "M",
                GiornoDiNascita = 18,
                MEseDiNascita = "2",
                AnnoDiNascita = 1996,
                ComuneDiNascita = "Camposampiero",
                CodiceFiscale = "",
            };
            cf = mylist2.FunzionaCalcolo();
            mylist2.CodiceFiscale = cf;
            Dipendente mylist3;
            mylist3 = new Dipendente
            {
                Nome = "Gesu",
                Cognome = "Senzacognome",
                Sesso = "M",
                GiornoDiNascita = 13,
                MEseDiNascita = "1",
                AnnoDiNascita = 2000,
                ComuneDiNascita = "Camposampiero",
                CodiceFiscale = "",
            };
            cf = mylist3.FunzionaCalcolo();
            mylist3.CodiceFiscale = cf;
            mylist.Add(mylist1);
            mylist.Add(mylist2);
            mylist.Add(mylist3);
            this.Visualizza.DataSource = mylist;
        }
        
    }
}
