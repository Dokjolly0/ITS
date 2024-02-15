using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiegazione_Database
{
    internal class Log_in
    {
        internal class User
        {
            //Queste sono le proprieta
            public int Id { get; set; }
            public string Email { get; set; }
            public string PAssword { get; set; }

            //Questo è il costruttore
            public User() { }
        }
    }
}
