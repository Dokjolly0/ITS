using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classi2
{
    internal class articolo
    {
        public int ArticoloID {  get; set; }
        public string ArticoloName { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public int Giaceza { get; set; }
        public int AliquotaIva { get; set; }
        public articolo()
        {
            
        }
    }
}
