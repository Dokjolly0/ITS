using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Webapi_Intro.Classi;

namespace Webapi_Intro.Controllers
{
    [Route("Login")]
    [ApiController]
    public class Controller_Token : ControllerBase
    {
        [Route("Esegui login")]
        [HttpPost]
        //RichiestaLogin è una classe che contiene Mail/Password
        //Dalla classe richiestaLogin creiamo una variabile da usare in seguito per prendere in input Mail e Password
        public RispostaLogin EseguiLogin(RichiestaLogin richiestaLogin)
        {
            //Inizializzi questa variabile che poi sarà il messaggio di riuscita/non riuscita della query
            string Messaggio = "";
            //Istanzia un oggetto vuoto che poi imposterai come risultato della funzione
            RispostaLogin risposta = new RispostaLogin();

            //Stringa connessione Database
            string conn = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
            //Crea connessione database
            SqlConnection ConnessioneDB = new SqlConnection(conn);
            try
            {
                //Apri connessione DB
                ConnessioneDB.Open();

                //Inizializzi un nuovo comando sql
                SqlCommand EseguiLogin = new SqlCommand();
                //Passi la connessione appena creata prima al comando sql
                EseguiLogin.Connection = ConnessioneDB;

                //Aggiungi i vari parametri al comando (Dalla classe richiesta login dove deve esserci Mail e Password)
                EseguiLogin.Parameters.Add("@Email", SqlDbType.NVarChar);
                EseguiLogin.Parameters["@Email"].Value = richiestaLogin.Email;

                EseguiLogin.Parameters.Add("@Password", SqlDbType.NVarChar);
                EseguiLogin.Parameters["@Password"].Value = richiestaLogin.Password;

                //Verifica che Mail/Password siano corretti
                EseguiLogin.CommandText = "SELECT Email, Password FROM Log_in WHERE Email = @Email AND Password = @Password;";
                //Crei un nuovo reader che legge i dati, lo assegni al comando sql creato prima e gli dici di eseguire il lettore
                SqlDataReader LeggiDatiAccesso = EseguiLogin.ExecuteReader();

                //Se il reader ha modificato righe allora restituisce true, altrimenti false
                if(LeggiDatiAccesso.HasRows)
                {
                    //Assegni alla variabile creata prima OK
                    Messaggio = "OK";
                }
                else
                {
                    //Assegni alla variabile creata prima OK
                    Messaggio = "KO";
                }
                //Chiudi il reader creato prima
                LeggiDatiAccesso.Close();
            }
            catch (Exception ex)
            {
                //Assegni alla variabile creata prima l'eccezione verificata
                Messaggio = ex.Message;
            }
            finally
            {
                //Se la connessione NON è nulla
                if(ConnessioneDB != null)
                {
                    //Chiudi connessione
                    ConnessioneDB.Close();
                }
            }

            //Questa parte si fa solo se Mail/Password sono corretti, ovvero quando il messaggio è OK
            if (Messaggio == "OK")
            {
                //Genera token
                System.Guid Token = System.Guid.NewGuid();
                //Assegni all'oggetto creato a inizio codice il token appena generato
                risposta.Token = Token.ToString();
                try
                {
                    //???????????
                    if (ConnessioneDB != null)
                    {
                        //Riapri la connessione
                        ConnessioneDB.Open();
                        //Crei un nuovo sql command e gli assegni la connessione
                        SqlCommand UpdateToken = new SqlCommand();
                        UpdateToken.Connection = ConnessioneDB;

                        //Aggiungi al nuovo comando i parametri
                        //Email dalla classe richiestaLogin, ovvero quella di prima
                        UpdateToken.Parameters.Add("@Email", SqlDbType.NVarChar);
                        UpdateToken.Parameters["@Email"].Value = richiestaLogin.Email;

                        //Token lo prendi dalla variabile creata prima quando abbiamo verificato che i dati coincidevano
                        UpdateToken.Parameters.Add("@Token", SqlDbType.NVarChar);
                        UpdateToken.Parameters["@Token"].Value = Token.ToString();

                        //DataOraCreazioneToken lo prendi dall'orario attuale di quando crei il token
                        UpdateToken.Parameters.Add("@DataOraCreazioneToken", SqlDbType.NVarChar);
                        UpdateToken.Parameters["@DataOraCreazioneToken"].Value = DateTime.Now;

                        //Stringa per aggiornare il token e DataOraCreazioneToken nel database
                        string SqlUpdateToken = "UPDATE Log_in SET Token = @Token, DataOraCreazioneToken = @DataOraCreazioneToken WHERE Email = @Email;";
                        //aggiungi la query sql creata al comando sql
                        UpdateToken.CommandText = SqlUpdateToken;
                        //Esegui il comando sql
                        UpdateToken.ExecuteNonQuery();
                    }
                    //Classe RispostaLogin parametro Messaggio gli assegni la variabile messaggio + token creato
                    risposta.Messaggio = Messaggio + "Token Creato";
                }
                catch (Exception ex)
                {
                    //Token non creato
                    Messaggio += "Token Non Creato";
                }
                finally
                {
                    //Connessione chiusa (stesso if di prima)
                    if(ConnessioneDB != null)
                    {
                        ConnessioneDB.Close();
                    }
                }
            }
            //Se il messaggio è uguale a KO
            else if (Messaggio == "KO")
            {
                //Utente non valido
                Messaggio = "utente non trovato";
            }
            //Classe RispostaLogin parametro Messaggio gli assegni la variabile messaggio
            risposta.Messaggio = Messaggio;
            //Ritorni l'oggetto risposta (Che contiene il messaggio e il token)
            return risposta;
        }
    }
}
