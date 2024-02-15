using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Verifica_C_.Classi;

namespace Verifica_C_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerDipendenti : ControllerBase
    {
        [HttpGet]
        [Route("ListaDipendenti")]
        public IActionResult listaDipendenti()
        {
            try
            {
                SqlConnection mySqlConnection = null;
                List<Dipendenti> listaDipendenti = new List<Dipendenti>();

                // Per connettermi al Database mi serve una stringa di connessione
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=gestioneAzienda; Trusted_Connection=true";
                mySqlConnection = new SqlConnection(stringaConnessione);
                mySqlConnection.Open();

                // Creo l'oggetto che mi permette di estrarre i dati

                SqlCommand mySqlCommand = new SqlCommand();
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = "SELECT * from Tdipendenti";
                SqlDataReader myReader = mySqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Dipendenti myArticolo = new Dipendenti();
                    myArticolo.Id = Convert.ToInt32(myReader["DipendenteID"]);
                    myArticolo.Cognome = Convert.ToString(myReader["Cognome"]);
                    myArticolo.Nome = Convert.ToString(myReader["Nome"]);
                    myArticolo.DataDiNascita = Convert.ToDateTime(myReader["DataDiNascita"]);
                    myArticolo.Comune = Convert.ToString(myReader["Comune"]);
                    myArticolo.Provincia = Convert.ToString(myReader["Provincia"]);
                    listaDipendenti.Add(myArticolo);
                }

                mySqlConnection.Close();
                return Ok(listaDipendenti);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

