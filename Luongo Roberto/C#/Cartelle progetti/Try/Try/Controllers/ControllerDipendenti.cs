using Microsoft.AspNetCore.Mvc;
using Verifica_C_.Classi;
using System.Data;
using System.Data.SqlClient;
using Webapi_Intro.Classi;
using Try.Classi;

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
        [Route("CercaDipendente")]
        [HttpGet]

        public RispostaDipendente restituisceDipendente(Int32 DipendenteID)
        {
            SqlConnection mySqlConnection = null;
            Dipendenti myDipendente = new Dipendenti();
            RispostaDipendente myRispostaDipendente = new RispostaDipendente();

            try
            {
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=gestioneAzienda; Trusted_Connection=true";
                mySqlConnection = new SqlConnection(stringaConnessione);
                mySqlConnection.Open();

                SqlCommand mySqlCommand = new SqlCommand();
                mySqlCommand.Connection = mySqlConnection;

                mySqlCommand.Parameters.Add("@DipendenteID", SqlDbType.Int);
                mySqlCommand.Parameters["@DipendenteID"].Value = DipendenteID;

                mySqlCommand.CommandText = "SELECT * FROM TDipendenti WHERE DipendenteID=@DipendenteID";

                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                if (mySqlDataReader.Read())
                {
                    myDipendente.Id = Convert.ToInt32(mySqlDataReader["DipendenteID"]);
                    myDipendente.Cognome = Convert.ToString(mySqlDataReader["Cognome"]);
                    myDipendente.Nome = Convert.ToString(mySqlDataReader["Nome"]);
                    myDipendente.DataDiNascita = Convert.ToDateTime(mySqlDataReader["DataNascita"]);
                    myDipendente.Sesso = Convert.ToString(mySqlDataReader["Sesso"]);
                    myDipendente.Comune = Convert.ToString(mySqlDataReader["ComuneNascita"]);
                    myDipendente.Provincia = Convert.ToString(mySqlDataReader["ProvinciaNascita"]);
                    myDipendente.Email = Convert.ToString(mySqlDataReader["Email"]);

                    myRispostaDipendente.dipendente = myDipendente;
                    myRispostaDipendente.Messaggio = "Utente trovato";
                }
                else
                {
                    myRispostaDipendente.Messaggio = "Utente non trovato";
                }
                mySqlDataReader.Close();
            }
            catch (Exception exc)
            {

            }
            finally
            {
                if (mySqlConnection != null)
                {
                    mySqlConnection.Close();
                }

            }
            return myRispostaDipendente;
        }

        [Route("AggiungiDipendente")]
        [HttpPost]

        public string Inserisci(Dipendenti dipendente)
        {
            SqlConnection con = null;
            string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=gestioneAzienda; Trusted_Connection=true";
            con = new SqlConnection(stringaConnessione);
            try
            {
                con = new SqlConnection(stringaConnessione);
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.Parameters.AddWithValue("@Cognome", dipendente.Cognome);
                cmd.Parameters.AddWithValue("@Nome", dipendente.Nome);
                cmd.Parameters.AddWithValue("@DataNascita", dipendente.DataDiNascita);
                cmd.Parameters.AddWithValue("@Sesso", dipendente.Sesso);
                cmd.Parameters.AddWithValue("@ComuneNascita", dipendente.Comune);
                cmd.Parameters.AddWithValue("@ProvinciaNascita", dipendente.Provincia);
                cmd.Parameters.AddWithValue("@Email", dipendente.Email);
                cmd.CommandText = "INSERT INTO Tdipendenti (Cognome,Nome,DataNascita,Sesso,ComuneNascita,ProvinciaNascita,Email) VALUES (@Cognome, @Nome, @DataNascita, @Sesso, @ComuneNascita, @ProvinciaNascita, @Email)";

                cmd.ExecuteNonQuery();

                //if(a > 0)
                //{
                //    return "Ok";
                //}
                //else
                //{
                //    return "KO";
                //}
            }
            catch (Exception ee)
            {
                return "Operazione non riuscita";
            }
            finally
            {
                con.Close();
            }
            return "Utente inserito";
        }

        [Route("EliminaDipendente")]
        [HttpDelete]
        public string Elimina(Dipendenti Id)
        {
            SqlConnection con = null;
            try
            {
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=gestioneAzienda; Trusted_Connection=true";
                con = new SqlConnection(stringaConnessione);
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.Parameters.AddWithValue("@id", Id.Id);
                cmd.CommandText = "DELETE FROM Tdipendenti WHERE DipendenteID = @id";

                cmd.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                return "Errore";
            }
            finally
            {
                con.Close();
            }
            return "Eliminato";
        }

        [Route("AggiornaMail")]
        [HttpPut]
        public string AggiornaGiacenza(int id, string mail)
        {
            SqlConnection con = null;
            Dipendenti a = new Dipendenti();
            try
            {
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=gestioneAzienda; Trusted_Connection=true";
                con = new SqlConnection(stringaConnessione);
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.CommandText = "SELECT COUNT(*) from Tdipendenti WHERE DipendenteID = @id";

                int appo = (int)cmd.ExecuteScalar();

                if (appo != 0)
                {
                    cmd.CommandText = "UPDATE TDipendenti SET Email = @mail WHERE DipendenteID = @id";
                    cmd.ExecuteNonQuery();
                    return "Email aggiornata";
                }
                else
                {
                    return "Utente non trovato";
                }
            }
            catch (Exception ee)
            {
                //MessageBox.Show("Eccezione: " + ee);
                return "Errore";
            }
            finally
            {
                con.Close();
            }
        }

        [Route("CodiceFiscale")]
        [HttpGet]
        public String CodiceFiscale(int id)
        {
            SqlConnection con = null;
            string risposta = "";
            try
            {
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=gestioneAzienda; Trusted_Connection=true";
                con = new SqlConnection(stringaConnessione);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = "select * from Tdipendenti WHERE @id=DipendenteID";
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Dipendenti nuovoDipendente = new Dipendenti();
                    nuovoDipendente.Id = Convert.ToInt32(reader["DipendenteID"]);
                    nuovoDipendente.Cognome = Convert.ToString(reader["Cognome"]);
                    nuovoDipendente.Nome = Convert.ToString(reader["Nome"]);
                    nuovoDipendente.DataDiNascita = Convert.ToDateTime(reader["DataNascita"]);
                    nuovoDipendente.Sesso = Convert.ToString(reader["Sesso"]);
                    nuovoDipendente.Comune = Convert.ToString(reader["ComuneNascita"]);
                    nuovoDipendente.Provincia = Convert.ToString(reader["ProvinciaNascita"]);
                    nuovoDipendente.Email = Convert.ToString(reader["Email"]);
                    con.Close();
                    con.Open();
                    cmd.Parameters.AddWithValue("@com", nuovoDipendente.Comune);
                    cmd.CommandText = "SELECT * FROM TComuni WHERE Comune = @com";
                    reader.Close();
                    reader = cmd.ExecuteReader();

                    string cod = "";
                    if (reader.Read())
                    {
                        cod = Convert.ToString(reader["CodiceCatastale"]);
                    }

                    string codicef = "";
                    bool cnome = false;
                    codicef += CognomeNome(nuovoDipendente.Cognome, cnome);
                    cnome = true;
                    codicef += CognomeNome(nuovoDipendente.Nome, cnome);
                    string appo2 = nuovoDipendente.DataDiNascita.ToString();
                    string data = appo2.Substring(0, 10);
                    codicef += Data(data, nuovoDipendente.Sesso);
                    risposta = "Il tuo codice fiscale è: " + codicef + "" + cod;

                }
                else
                {
                    return "Errore";
                }
            }
            catch (Exception ee)
            {
                //risp = "errore";
                return ee.ToString();
                //MessageBox.Show("Eccezione: " + ee.Message);  -> in caso di errore utilizzeremo un altro metodo
            }
            finally
            {
                con.Close();
            }
            return risposta;
        }

        public static string CognomeNome(string cogn, bool cicco)
        {
            string cod = "";
            cogn = cogn.ToLower();

            for (int i = 0; i < cogn.Length; i++) //inserisco solo le consonanti dopo aver confrontato ogni singola lettera del cognome
            {
                char let = cogn[i];  //scorro ogni singolo carattere del cognome
                if ((let != 'a') && (let != 'e') && (let != 'i') && (let != 'o') && (let != 'u'))
                {
                    cod += let;
                }
            }

            if (cod.Length > 3)
            {
                if (cicco)
                {
                    string tmp = "";
                    tmp += cod[0];
                    tmp += cod[2];
                    tmp += cod[3];
                    cod = tmp;
                }
                else
                {
                    string appo = "";
                    appo += cod[0];
                    appo += cod[1];
                    appo += cod[2];
                    cod = appo;
                }
            }

            if (cod.Length < 3)  //se la lunghezza è inferiore a 3 (minimo) allora aggiungo anche le vocali
            {
                for (int i = 0; i < cogn.Length; i++)
                {
                    char let = cogn[i];
                    if ((let == 'a') || (let == 'e') || (let == 'i') || (let == 'o') || (let == 'u'))
                    {
                        cod += let;
                    }
                }
            }

            if (cod.Length < 3)//se la lunghezza è di nuovo inferiore a 3 (minimo) allora aggiungo anche le x
            {
                int manc = 3 - cod.Length;
                for (int i = 0; i < manc; i++)
                {
                    cod += "x";
                }
            }

            string codicefinale = cod.Substring(0, 3).ToUpper();

            return codicefinale;
        }

        public static string Data(string data, string sesso)
        {
            string dataf = data.Substring(8, 2);


            switch (data.Substring(3, 2))
            {
                case "01":
                    dataf += "A";
                    break;
                case "02":
                    dataf += "B";
                    break;
                case "03":
                    dataf += "C";
                    break;
                case "04":
                    dataf += "D";
                    break;
                case "05":
                    dataf += "E";
                    break;
                case "06":
                    dataf += "H";
                    break;
                case "07":
                    dataf += "L";
                    break;
                case "08":
                    dataf += "M";
                    break;
                case "09":
                    dataf += "P";
                    break;
                case "10":
                    dataf += "R";
                    break;
                case "11":
                    dataf += "S";
                    break;
                case "12":
                    dataf += "T";
                    break;
            }

            int appo2 = Convert.ToInt32(data.Substring(0, 2));
            if (sesso.Equals("F")) //se l'utente è una donna aggiungo 40 al giorno
            {
                appo2 += 40;
            }
            dataf += Convert.ToString(appo2);
            return dataf;
        }
    }
}