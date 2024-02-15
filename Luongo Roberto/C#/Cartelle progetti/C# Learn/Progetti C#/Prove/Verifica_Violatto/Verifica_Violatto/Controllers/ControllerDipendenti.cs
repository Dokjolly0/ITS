using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Verifica_C_.Classi;
using System.Data;

namespace Verifica_C_.Controllers
{
    [Route("dipendenti")]
    [ApiController]
    public class ControllerDipendenti : ControllerBase
    {
        [Route("ListaDipendenti")]
        [HttpGet]
        public List<Dipendenti> listaDipendenti()
        {
            string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=gestioneAzienda; Trusted_Connection=true";
            SqlConnection? conn = null;
            List<Dipendenti> listaDipendenti = new List<Dipendenti>();
            try
            {
                conn = new SqlConnection(stringaConnessione);
                //Per connettermi al Database mi serve una stringa di connessione
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from Tdipendenti";
                SqlDataReader lettore = cmd.ExecuteReader();

                while (lettore.Read())
                {
                    Dipendenti newDipendente = new Dipendenti();
                    newDipendente.Id = Convert.ToInt32(lettore["DipendenteID"]);
                    newDipendente.Cognome = Convert.ToString(lettore["Cognome"]);
                    newDipendente.Nome = Convert.ToString(lettore["Nome"]);
                    newDipendente.DataDiNascita = Convert.ToDateTime(lettore["DataNascita"]);
                    newDipendente.Sesso = Convert.ToString(lettore["Sesso"]);
                    newDipendente.Comune = Convert.ToString(lettore["ComuneNascita"]);
                    newDipendente.Provincia = Convert.ToString(lettore["ProvinciaNascita"]);
                    newDipendente.Email = Convert.ToString(lettore["Email"]);
                    listaDipendenti.Add(newDipendente);
                }
                conn.Close();

            }
            catch (Exception ex)
            {
            }
            return listaDipendenti;
        }
    }
}

