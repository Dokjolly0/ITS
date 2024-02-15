using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MySqlConnector;
using System.Data;
using System.Data.SqlClient;
using Webapi_Intro.Classi;

namespace Webapi_Intro.Controllers
{
    [Route("articoli")]
    [ApiController]
    public class ControllerArticoli : ControllerBase
    {
        //Qua dentro dobbiamo programmare le chiamate
        //Come prima chiamata faremo una chiamata get che restituisce tutti gli articoli
        //Qui creiamo una nuova chiamata Json
        [Route("listaArticoli")]
        [HttpGet]
        public List<Articolo> getListArticolo()
        {
            SqlConnection mySqlConnection = null;
            List<Articolo> listaArticoli = new List<Articolo>();

            //Per connettermi al Database mi serve una stringa di connessione
            string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
            mySqlConnection = new SqlConnection(stringaConnessione);
            mySqlConnection.Open();

            //Creo l'oggetto che mi permette di estrarre i dati
            SqlCommand mySqlCommand = new SqlCommand(stringaConnessione);
            mySqlCommand.Connection = mySqlConnection;
            mySqlCommand.CommandText = "select * from Articoli";
            IDataReader myReader = mySqlCommand.ExecuteReader();
            while (myReader.Read())
            {
                Articolo myArticolo = new Articolo();
                myArticolo.Id = Convert.ToInt32(myReader["Id"]);
                myArticolo.Nome = Convert.ToString(myReader["Nome"]);
                myArticolo.Descrizione = Convert.ToString(myReader["Descrizione"]);
                myArticolo.Giacenza = Convert.ToInt32(myReader["Giacenza"]);
                myArticolo.AliquotaIva = Convert.ToInt32(myReader["AliquotaIva"]);
                myArticolo.Prezzo = Convert.ToInt32(myReader["Prezzo"]);
                listaArticoli.Add(myArticolo);
            }
            mySqlConnection.Close();
            return listaArticoli;
        }
        [Route("articoliG0")]
        [HttpGet]
        public List<Articolo> getListArticoloG0()
        {
            SqlConnection mySqlConnection = null;
            List<Articolo> listaArticoliG0 = new List<Articolo>();

            //Per connettermi al Database mi serve una stringa di connessione
            string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
            mySqlConnection = new SqlConnection(stringaConnessione);
            mySqlConnection.Open();
            //MessageBox.Show("Operazione riuscita");


            //Creo l'oggetto che mi permette di estrarre i dati
            SqlCommand mySqlCommand = new SqlCommand(stringaConnessione);
            mySqlCommand.Connection = mySqlConnection;
            mySqlCommand.CommandText = "select * from Articoli WHERE Giacenza = 0";
            IDataReader myReader = mySqlCommand.ExecuteReader();
            while (myReader.Read())
            {
                Articolo myArticolo = new Articolo();
                myArticolo.Id = Convert.ToInt32(myReader["Id"]);
                myArticolo.Nome = Convert.ToString(myReader["Nome"]);
                myArticolo.Descrizione = Convert.ToString(myReader["Descrizione"]);
                myArticolo.Giacenza = Convert.ToInt32(myReader["Giacenza"]);
                myArticolo.AliquotaIva = Convert.ToInt32(myReader["AliquotaIva"]);
                myArticolo.Prezzo = Convert.ToInt32(myReader["Prezzo"]);
                listaArticoliG0.Add(myArticolo);
            }
            mySqlConnection.Close();
            return listaArticoliG0;
        }

        [Route("CercaArticolo")]
        [HttpGet]
        public Articolo TrovaArticolo(Int32 IdUser)
        {
            SqlConnection mySqlConnection = null;
            Articolo myArticolo = new Articolo();

            string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
            mySqlConnection = new SqlConnection(stringaConnessione);
            mySqlConnection.Open();

            SqlCommand mySqlCommand = new SqlCommand(stringaConnessione);
            mySqlCommand.Connection = mySqlConnection;
            mySqlCommand.Parameters.AddWithValue("@Id", value: IdUser);
            mySqlCommand.CommandText = "select * from Articoli WHERE Id = @Id";
            SqlDataReader myReader = mySqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                myArticolo.Id = Convert.ToInt32(myReader["Id"]);
                myArticolo.Nome = Convert.ToString(myReader["Nome"]);
                myArticolo.Descrizione = Convert.ToString(myReader["Descrizione"]);
                myArticolo.Giacenza = Convert.ToInt32(myReader["Giacenza"]);
                myArticolo.AliquotaIva = Convert.ToInt32(myReader["AliquotaIva"]);
                myArticolo.Prezzo = Convert.ToInt32(myReader["Prezzo"]);
            }
            mySqlConnection.Close();
            return myArticolo;
        }

        [Route("CercaDescrizione")]
        [HttpGet]
        public List<Articolo> CercaDescrizione(string CercaDescrizione)
        {
            SqlConnection mySqlConnection = null;
            List<Articolo> listaRicerca = new List<Articolo>();

            //Per connettermi al Database mi serve una stringa di connessione
            string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
            mySqlConnection = new SqlConnection(stringaConnessione);
            mySqlConnection.Open();
            //MessageBox.Show("Operazione riuscita");


            //Creo l'oggetto che mi permette di estrarre i dati
            SqlCommand mySqlCommand = new SqlCommand(stringaConnessione);
            mySqlCommand.Connection = mySqlConnection;
            mySqlCommand.Parameters.AddWithValue("@CercaDescrizione", value: "%" + CercaDescrizione + "%");
            mySqlCommand.CommandText = "SELECT Id, Nome, Descrizione, Giacenza, AliquotaIva, Prezzo FROM dbo.Articoli WHERE  (Descrizione LIKE @CercaDescrizione) OR (Nome LIKE @CercaDescrizione);";
            IDataReader myReader = mySqlCommand.ExecuteReader();
            while (myReader.Read())
            {
                Articolo myArticolo = new Articolo();
                myArticolo.Id = Convert.ToInt32(myReader["Id"]);
                myArticolo.Nome = Convert.ToString(myReader["Nome"]);
                myArticolo.Descrizione = Convert.ToString(myReader["Descrizione"]);
                myArticolo.Giacenza = Convert.ToInt32(myReader["Giacenza"]);
                myArticolo.AliquotaIva = Convert.ToInt32(myReader["AliquotaIva"]);
                myArticolo.Prezzo = Convert.ToInt32(myReader["Prezzo"]);
                listaRicerca.Add(myArticolo);
            }
            mySqlConnection.Close();
            return listaRicerca;
        }

        [Route("AggiungiArticolo")]
        [HttpPost]

        public String postInserisciArticolo(Articolo myArticolo)
        {
            try
            {
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
                SqlConnection mySqlConnection = new SqlConnection(stringaConnessione);
                mySqlConnection.Open();

                SqlCommand mySqlCommand = new SqlCommand(stringaConnessione);
                mySqlCommand.Connection = mySqlConnection;

                //Con le prossime 10 righe impediamo di aggiungere linquaggio SQL dentro i campi input

                mySqlCommand.Parameters.Add("@Nome", SqlDbType.NVarChar);
                mySqlCommand.Parameters["@Nome"].Value = myArticolo.Nome;

                mySqlCommand.Parameters.Add("@Descrizione", SqlDbType.NVarChar);
                mySqlCommand.Parameters["@Descrizione"].Value = myArticolo.Descrizione;

                mySqlCommand.Parameters.Add("@Giacenza", SqlDbType.NVarChar);
                mySqlCommand.Parameters["@Giacenza"].Value = myArticolo.Giacenza;

                mySqlCommand.Parameters.Add("@AliquotaIva", SqlDbType.NVarChar);
                mySqlCommand.Parameters["@AliquotaIva"].Value = myArticolo.AliquotaIva;

                mySqlCommand.Parameters.Add("@Prezzo", SqlDbType.NVarChar);
                mySqlCommand.Parameters["@Prezzo"].Value = myArticolo.Prezzo;

                mySqlCommand.CommandText = "INSERT INTO Articoli (Nome, Descrizione, Giacenza, " +
                    "AliquotaIva, Prezzo) VALUES(@Nome, @Descrizione, @Giacenza, @AliquotaIva, @Prezzo)";

                mySqlCommand.ExecuteNonQuery();

                List<Articolo> listaArticoli = new List<Articolo>();


                mySqlCommand.CommandText = "select * from Articoli";
                IDataReader myReader = mySqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //Legge un record alla volta
                    myArticolo.Id = Convert.ToInt32(myReader["Id"]);
                    myArticolo.Nome = Convert.ToString(myReader["Nome"]);
                    myArticolo.Descrizione = Convert.ToString(myReader["Descrizione"]);
                    myArticolo.Giacenza = Convert.ToInt32(myReader["Giacenza"]);
                    myArticolo.AliquotaIva = Convert.ToInt32(myReader["AliquotaIva"]);
                    myArticolo.Prezzo = Convert.ToInt32(myReader["Prezzo"]);
                    listaArticoli.Add(myArticolo);
                }
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("Elimina articolo")]
        [HttpDelete]
        public string delateButtonArticolo(Int32 Id)
        {
            SqlConnection mySqlConnection = null;
            try
            {
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
                mySqlConnection = new SqlConnection(stringaConnessione);
                mySqlConnection.Open();

                string EliminaArticolo = "delete from Articoli where Id = @Id";

                SqlCommand mySqlCommand = new SqlCommand(stringaConnessione);
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = EliminaArticolo;

                mySqlCommand.Parameters.Add("@Id", SqlDbType.Int);
                mySqlCommand.Parameters["@Id"].Value = Id;

                mySqlCommand.ExecuteNonQuery();

                return "Ok";
            }
            catch (Exception ex)
            {
                return "Eccezione: " + ex.Message;
            }
        }

        [Route("Aggiorna articolo")]
        [HttpPut]
        public string UpdateArticolo(String id, Int32 giacenza, string tipo)
        {
            try
            {
                SqlConnection mySqlConnection = null;
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
                mySqlConnection = new SqlConnection(stringaConnessione);
                mySqlConnection.Open();

                string AggiornaGiacenza = "update Articoli set Giacenza = Giacenza + @Giacenza where Id = @Id";
                string AggiornaVendita = "update Articoli set Giacenza = Giacenza - @Giacenza where Id = @Id";
                string VerificaDisponibilita = "SELECT COUNT(*) FROM Articoli WHERE Id = @Id;";
                string ArticoliRimanenti = "SELECT Giacenza FROM Articoli WHERE Id = @Id;";

                SqlCommand UpdateGiacenza = new SqlCommand();
                UpdateGiacenza.Connection = mySqlConnection;

                UpdateGiacenza.Parameters.Add("@Giacenza", SqlDbType.NVarChar);
                UpdateGiacenza.Parameters["@Giacenza"].Value = giacenza;

                UpdateGiacenza.Parameters.Add("@Id", SqlDbType.NVarChar);
                UpdateGiacenza.Parameters["@Id"].Value = id;

                UpdateGiacenza.Parameters.Add("@tipo", SqlDbType.NVarChar);
                UpdateGiacenza.Parameters["@tipo"].Value = tipo;

                UpdateGiacenza.CommandText = VerificaDisponibilita;
                int n = (int)UpdateGiacenza.ExecuteScalar();

                if (n > 0) 
                {
                    if (tipo == "acquisto")
                    {
                        UpdateGiacenza.CommandText = AggiornaGiacenza;
                        UpdateGiacenza.ExecuteNonQuery();
                    }
                    else if (tipo == "vendita")
                    {
                        UpdateGiacenza.CommandText = ArticoliRimanenti;
                        int countVendita = (int)UpdateGiacenza.ExecuteScalar();
                        if (countVendita >= giacenza)
                        {
                            UpdateGiacenza.CommandText = AggiornaVendita;
                            UpdateGiacenza.ExecuteNonQuery();
                        }
                        else
                        {
                            return "In magazzino non ci sono abbastanza articoli";
                        }
                    }
                }
                else
                {
                    return "Id non trovato";
                }
              
                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        //Il codice prima riguarda la lezione precedente
        //Crea una chiamata post che restituisca la lista degli articoli solo se inserisci un token inserito nel Databse
        [Route("Lista articoli token")]
        [HttpPost]
        //Crei la funzione e ci passi come parametro la classe RichiestaArticoli e ci assegni la variabile RequestArticoli
        public RispostaArticoli getListArticoliToken(RichiestaArticoli RequestArticoli)
        {
            //Crei una lista che conterrà tutti gli articoli che andrai a generare
            List<Articolo> listaArticoli = new List<Articolo>();
            string Messaggio = "";
            //Stringa connessione
            string conn = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
            //Crei la connessione (short form)
            SqlConnection ConnessioneDB = new SqlConnection(conn);
            try
            {
                //Apri la connessione
                ConnessioneDB.Open();

                //Crei il comando sql
                SqlCommand tokenArticoli = new SqlCommand();
                //assegni la connessione creata prima al comando sql
                tokenArticoli.Connection = ConnessioneDB;

                //aggiungi il parametro dalla variabile RequestArticoli creata prima
                tokenArticoli.Parameters.Add("@Token", SqlDbType.NVarChar);
                tokenArticoli.Parameters["@Token"].Value = RequestArticoli.Token;

                //Assegni la query sql al comando appena creato
                tokenArticoli.CommandText = "SELECT Token FROM Log_in WHERE Token = @Token;";
                //crei un dataReader e lo assegni al comando sql facendo eseguire il reader
                SqlDataReader VerificaTokenArticoli = tokenArticoli.ExecuteReader();

                //Se la query ha modificato righe 
                if (VerificaTokenArticoli.HasRows)
                {
                    //Connessione chiusa
                    VerificaTokenArticoli.Close();
                    //Messaggio OK
                    Messaggio = "OK";
                }
                else
                {
                    //Messaggio KO
                    Messaggio = "KO";
                }
            }
            catch (Exception ex)
            {
                //Messaggio = Eccezione
                Messaggio = ex.ToString();
            }
            finally
            {
                //Se la connessione NON è nulla
                if (ConnessioneDB != null)
                {
                    //Connessione chiusa
                    ConnessioneDB.Close();
                }
            }
            //Se il messaggio è uguale a OK
            if (Messaggio == "OK")
            {
                //Crei una sql connection e la assegni al valore null
                SqlConnection mySqlConnection = null;

                //Stringa di connessione
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
                //Crei una nuova connessione
                mySqlConnection = new SqlConnection(stringaConnessione);
                //Apri la connessione
                mySqlConnection.Open();

                //Questo è un copia/incolla del codice scritto sopra
                //Creo l'oggetto che mi permette di estrarre i dati
                SqlCommand mySqlCommand = new SqlCommand(stringaConnessione);
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = "select * from Articoli";
                IDataReader myReader = mySqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Articolo myArticolo = new Articolo();
                    myArticolo.Id = Convert.ToInt32(myReader["Id"]);
                    myArticolo.Nome = Convert.ToString(myReader["Nome"]);
                    myArticolo.Descrizione = Convert.ToString(myReader["Descrizione"]);
                    myArticolo.Giacenza = Convert.ToInt32(myReader["Giacenza"]);
                    myArticolo.AliquotaIva = Convert.ToInt32(myReader["AliquotaIva"]);
                    myArticolo.Prezzo = Convert.ToInt32(myReader["Prezzo"]);
                    listaArticoli.Add(myArticolo);
                }
                //Chiudi la connessione
                mySqlConnection.Close();
            }
            //Crei un oggetto, lo assegni a un nuovo oggetto passandogli i parametri Messaggio e ListaArticoli che abbiamo creato prima
            RispostaArticoli risposta = new RispostaArticoli(Messaggio, listaArticoli);
            //Ritorni l'oggetto appena creato
            return risposta;
        }
    }
}
