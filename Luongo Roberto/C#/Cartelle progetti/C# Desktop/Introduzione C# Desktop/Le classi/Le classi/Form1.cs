using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Le_classi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.bottoneIstanza.Click += BottoneIstanza_Click;        
        }

        private void BottoneIstanza_Click(object sender, EventArgs e)
        {
            Articolo myAritcolo;
            myAritcolo = new Articolo();
            myAritcolo.ArticoloId = 1;
            myAritcolo.Nome = "Pane";
            myAritcolo.Descrizione = "Pane al latte";
            myAritcolo.Prezzo = 1.2;
            myAritcolo.Iva = 0.24;
            myAritcolo.PrezzoNoIva = 0.96;
            myAritcolo.GiacenzaMagazzino = 20;

            List<string> lista = new List<string>();
            lista.Add(myAritcolo.Nome = "");

        }
    }
}
