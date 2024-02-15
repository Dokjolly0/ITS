using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Le_classi
{
    internal class Articolo
    {
        //Qui si vanno a specificare tutte le proprietà di questa classe
        public Int32 ArticoloId { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public double PrezzoNoIva { get; set; }
        public Int32 GiacenzaMagazzino { get; set; }
        public double Iva { get; set; }

        //Inseriamo il costruttore della classe
        public Articolo() { }
    }

}
