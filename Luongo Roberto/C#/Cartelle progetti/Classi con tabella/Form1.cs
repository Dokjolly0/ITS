namespace Classi2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button1.Click += Button1_Click;
            this.button2.Click += Button2_Click;
        }
        private void Button2_Click(object? sender, EventArgs e)
        {
            List<articolo> mylist = new List<articolo>();
            articolo mylist1;
            mylist1 = new articolo
            {
                ArticoloID = 1,
                ArticoloName = "pane",
                Descrizione = "pane al latte",
                Prezzo = 4.5,
                Giaceza = 20,
                AliquotaIva = 4,
            };
            articolo mylist2;
            mylist2 = new articolo
            {
                ArticoloID = 2,
                ArticoloName = "latte",
                Descrizione = "latte intero",
                Prezzo = 2,
                Giaceza = 40,
                AliquotaIva = 4,
            };
            articolo mylist3;
            mylist3 = new articolo
            {
                ArticoloID = 3,
                ArticoloName = "carta",
                Descrizione = "carta igenica",
                Prezzo = 4,
                Giaceza = 50,
                AliquotaIva = 4,

            };
            mylist.Add(mylist1);
            mylist.Add(mylist2);
            mylist.Add(mylist3);
            this.dgwArticoli.DataSource = mylist;
            double somma = 0;
            double sommaiva = 0;
            foreach (articolo a in mylist)
            {
                somma += a.Prezzo * a.Giaceza;
                sommaiva += (a.Prezzo * a.Giaceza) + (a.Prezzo * a.Giaceza * (Convert.ToDouble(a.AliquotaIva) / 100));
            }
            mostraPrezzo.Text = somma + "\t" + sommaiva;
        }
        private void Button1_Click(object? sender, EventArgs e)
        {
            articolo myarticolo;
            myarticolo = new articolo
            {
                ArticoloID = 1,
                ArticoloName = "pane",
                Descrizione = "pane al latte",
                Prezzo = 4.5,
                Giaceza = 20,
                AliquotaIva = 4
            };
        }
    }
}