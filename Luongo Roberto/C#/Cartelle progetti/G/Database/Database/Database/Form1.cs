using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Database
{
    public partial class Form1 : Form
    {
        Articolo articolo;
        public Form1()
        {
            InitializeComponent();
            articolo = new Articolo();
            BottoneGriglia.Click += visualizzaGriglia;
            BottoneLog.Click += visualizzaLog;
            Aggiungi.Click += AggiungiElemento;
            AggiungiUser.Click += AggiungiUser_Click;
            AggiungiGiacenza.Click += AggiungiGiacenzaFunction;
            DeleteButtonArticolo.Click += DeleteButtonArticoloF;
            DeleteUser.Click += DeleteUser_Click;
            ResetPassword.Click += ResetPassword_Click;
            Accedi.Click += Accedi_Click;
            Search.Click += Search_Click;
            AccediUtenteNoDateTime.Click += AccediUtenteNoDateTime_Click;
        }

        private void AccediUtenteNoDateTime_Click(object sender, EventArgs e)
        {
            SqlConnection mySqlConnectionLog = null;
            List<Log> listaLog = new List<Log>();

            //Creo l'oggetto che mi permette di estrarre i dati
            string stringaConnessioneLog = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
            mySqlConnectionLog = new SqlConnection(stringaConnessioneLog);
            mySqlConnectionLog.Open();
            SqlCommand mySqlCommandLog = new SqlCommand(stringaConnessioneLog);
            mySqlCommandLog.Connection = mySqlConnectionLog;
            mySqlCommandLog.CommandText = "select * from Log_in";
            IDataReader myReaderLog = mySqlCommandLog.ExecuteReader();
            while (myReaderLog.Read())
            {
                //Legge un record alla volta
                Log myUser = new Log();
                myUser.Id = Convert.ToInt32(myReaderLog["Id"]);
                myUser.Email = Convert.ToString(myReaderLog["Email"]);
                myUser.Password = Convert.ToString(myReaderLog["Password"]);
                myUser.Token = Convert.ToString(myReaderLog["Token"]);
                listaLog.Add(myUser);
            }
            //Per vedere i dati collego la lista alla griglia
            this.GrigliaLog.DataSource = listaLog;
        }
    

        private void Search_Click(object sender, EventArgs e)
        {
            //SELECT Id, Nome, Descrizione, Giacenza, AliquotaIva, Prezzo FROM     dbo.Articoli WHERE  (Descrizione LIKE '%%');
            string stringaConnessioneAccess = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
            using (SqlConnection connessioneAccedi = new SqlConnection(stringaConnessioneAccess))
            {
                connessioneAccedi.Open();
                string Search = "SELECT Id, Nome, Descrizione, Giacenza, AliquotaIva, Prezzo FROM dbo.Articoli WHERE (Descrizione LIKE @TestoRicerca);";
                using (SqlCommand RicercaDesc = new SqlCommand(Search, connessioneAccedi))
                {
                    RicercaDesc.Parameters.AddWithValue("@TestoRicerca", "%" + this.TestoRierca.Text + "%");
                    //RicercaDesc.Parameters.Add("@TestoRicerca", SqlDbType.NVarChar).Value = "%" + this.TestoRierca.Text + "%";

                    List<Articolo> listaArticoli = new List<Articolo>();


                    RicercaDesc.CommandText = Search;
                    IDataReader myReader = RicercaDesc.ExecuteReader();
                    while (myReader.Read())
                    {
                        //Legge un record alla volta
                        Articolo myArticolo = new Articolo();
                        myArticolo.Id = Convert.ToInt32(myReader["Id"]);
                        myArticolo.Nome = Convert.ToString(myReader["Nome"]);
                        myArticolo.Descrizione = Convert.ToString(myReader["Descrizione"]);
                        myArticolo.Giacenza = Convert.ToInt32(myReader["Giacenza"]);
                        myArticolo.AliquotaIva = Convert.ToInt32(myReader["AliquotaIva"]);
                        myArticolo.Prezzo = Convert.ToInt32(myReader["Prezzo"]);
                        listaArticoli.Add(myArticolo);
                    }
                    //Per vedere i dati collego la lista alla griglia
                    this.GrigliaSearch.DataSource = listaArticoli;
                }
            }
        }

        private void Accedi_Click(object sender, EventArgs e)
        {
            try
            {
                //Server=localhost\\SQLEXPRESS; -> che server vuoi usare
                //Database=Gestionale; -> che database voui usare
                //Trusted_Connection=true" -> Connessione vera
                string stringaConnessioneAccess = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";

                //Con questo comando evitiamo di dover richiudere la connessione ogi volta
                using (SqlConnection connessioneAccedi = new SqlConnection(stringaConnessioneAccess))
                {
                    //Apri la connessione
                    connessioneAccedi.Open();

                    //Comandi SQL

                    string verificaAccesso = "SELECT Email, Password FROM Log_in WHERE Email = @Email AND Password = @Password;";

                    using (SqlCommand VerificaAccesso = new SqlCommand(verificaAccesso, connessioneAccedi))
                    {
                        //Aggiungi il parametro Email al comando
                        VerificaAccesso.Parameters.Add("@Email", SqlDbType.NVarChar);
                        //Dai un valore al parametro SQL appena creato
                        VerificaAccesso.Parameters["@Email"].Value = this.Email.Text;

                        VerificaAccesso.Parameters.Add("@Password", SqlDbType.NVarChar);
                        VerificaAccesso.Parameters["@Password"].Value = this.Password.Text;

                        SqlDataReader LeggiDatiAccesso = VerificaAccesso.ExecuteReader();

                        if (LeggiDatiAccesso.Read())
                        {
                            LeggiDatiAccesso.Close();
                            MessageBox.Show("Eseguito con successo!");
                        }
                        else
                        {
                            MessageBox.Show("L'indirizzo email o la password non coincidono!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eccezione: " + ex.Message);
            }
        }

        private void ResetPassword_Click(object sender, EventArgs e)
        {
            //Se errore, togli commento
            //De rallenta attiva compiler
            //SqlConnection mySqlConnection = null;
            {
                try
                {
                    //Stringa connessione
                    string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";

                    //Qui creiamo un comando SQL che connette il file il database
                    using (SqlConnection connessione = new SqlConnection(stringaConnessione))
                    {
                        //Qui apriamo la connessione al db
                        connessione.Open();

                        //Qui creiamo i comando SQL
                        string stringaComando = "SELECT Email FROM Log_in WHERE Email = @Email;";
                        string stringaCambioPassword = "UPDATE Log_in SET Password = @NuovaPassword WHERE Email = @Email;";

                        using (SqlCommand checkEmail = new SqlCommand(stringaComando, connessione))
                        {
                            //Aggiungi i parametri
                            checkEmail.Parameters.Add("@Email", SqlDbType.NVarChar);
                            checkEmail.Parameters["@Email"].Value = this.RecuperoEmail.Text;

                            SqlDataReader lettoreMail = checkEmail.ExecuteReader();
                            //Esegue l'if  se trova nel db quella specifica email
                            if (lettoreMail.Read())
                            {
                                lettoreMail.Close();
                                //MessageBox.Show("Email letta");
                                if(NuovaPassword.Text == ConfermaPassword.Text)
                                {
                                    //MessageBox.Show("Password uguali");
                                    using (SqlCommand resetPassword = new SqlCommand(stringaCambioPassword, connessione))
                                    {
                                        resetPassword.Parameters.Add("@NuovaPassword", SqlDbType.NVarChar);
                                        resetPassword.Parameters["@NuovaPassword"].Value = this.NuovaPassword.Text;

                                        resetPassword.Parameters.Add("@Email", SqlDbType.NVarChar);
                                        resetPassword.Parameters["@Email"].Value = this.RecuperoEmail.Text;

                                        int righeAggiornate = resetPassword.ExecuteNonQuery();

                                        if (righeAggiornate > 0)
                                        {
                                            MessageBox.Show("La password è stata cambiata con successo!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("La password non è stata cambiata con successo");
                                        }
                                    }//Using resetPassword
                                }//If password == password
                                else
                                {
                                    MessageBox.Show("Le 2 password non coincidono!");
                                }
                            }//if read()
                            else
                            {
                                MessageBox.Show("Email errata, non presente nel database");
                            }
                        }//Using checkEmail
                    }//Using connection

                    {
                        SqlConnection mySqlConnectionLog = null;
                        List<Log> listaLog = new List<Log>();

                        //Creo l'oggetto che mi permette di estrarre i dati
                        string stringaConnessioneLog = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
                        mySqlConnectionLog = new SqlConnection(stringaConnessioneLog);
                        mySqlConnectionLog.Open();
                        SqlCommand mySqlCommandLog = new SqlCommand(stringaConnessioneLog);
                        mySqlCommandLog.Connection = mySqlConnectionLog;
                        mySqlCommandLog.CommandText = "select * from Log_in";
                        IDataReader myReaderLog = mySqlCommandLog.ExecuteReader();
                        while (myReaderLog.Read())
                        {
                            //Legge un record alla volta
                            Log myUser = new Log();
                            myUser.Id = Convert.ToInt32(myReaderLog["Id"]);
                            myUser.Email = Convert.ToString(myReaderLog["Email"]);
                            myUser.Password = Convert.ToString(myReaderLog["Password"]);
                            listaLog.Add(myUser);
                        }
                        //Per vedere i dati collego la lista alla griglia
                        this.GrigliaLog.DataSource = listaLog;
                    }//Mostra la tabella aggiornata

                }//Try
                catch (Exception ex)
                {
                    MessageBox.Show("Eccezione: " + ex.Message);
                }
            }
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            SqlConnection mySqlConnection = null;
            try
            {
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
                mySqlConnection = new SqlConnection(stringaConnessione);
                mySqlConnection.Open();

                string EliminaArticolo = "delete from Log_in where Id = @Id;";

                SqlCommand mySqlCommand = new SqlCommand(stringaConnessione);
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = EliminaArticolo;

                mySqlCommand.Parameters.Add("@Id", SqlDbType.Int);
                mySqlCommand.Parameters["@Id"].Value = this.IdDelateUser.Text;

                mySqlCommand.ExecuteNonQuery();

                {
                    SqlConnection mySqlConnectionLog = null;
                    List<Log> listaLog = new List<Log>();

                    //Creo l'oggetto che mi permette di estrarre i dati
                    string stringaConnessioneLog = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
                    mySqlConnectionLog = new SqlConnection(stringaConnessioneLog);
                    mySqlConnectionLog.Open();
                    SqlCommand mySqlCommandLog = new SqlCommand(stringaConnessioneLog);
                    mySqlCommandLog.Connection = mySqlConnectionLog;
                    mySqlCommandLog.CommandText = "select * from Log_in";
                    IDataReader myReaderLog = mySqlCommandLog.ExecuteReader();
                    while (myReaderLog.Read())
                    {
                        //Legge un record alla volta
                        Log myUser = new Log();
                        myUser.Id = Convert.ToInt32(myReaderLog["Id"]);
                        myUser.Email = Convert.ToString(myReaderLog["Email"]);
                        myUser.Password = Convert.ToString(myReaderLog["Password"]);
                        listaLog.Add(myUser);
                    }
                    //Per vedere i dati collego la lista alla griglia
                    this.GrigliaLog.DataSource = listaLog;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eccezione: " + ex.Message);
            }
        }

        private void DeleteButtonArticoloF(object sender, EventArgs e)
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
                mySqlCommand.Parameters["@Id"].Value = this.IdDelete.Text;

                mySqlCommand.ExecuteNonQuery();

                {
                    List<Articolo> listaArticoli = new List<Articolo>();


                    mySqlCommand.CommandText = "select * from Articoli";
                    IDataReader myReader = mySqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        //Legge un record alla volta
                        Articolo myArticolo = new Articolo();
                        myArticolo.Id = Convert.ToInt32(myReader["Id"]);
                        myArticolo.Nome = Convert.ToString(myReader["Nome"]);
                        myArticolo.Descrizione = Convert.ToString(myReader["Descrizione"]);
                        myArticolo.Giacenza = Convert.ToInt32(myReader["Giacenza"]);
                        myArticolo.AliquotaIva = Convert.ToInt32(myReader["AliquotaIva"]);
                        myArticolo.Prezzo = Convert.ToInt32(myReader["Prezzo"]);
                        listaArticoli.Add(myArticolo);
                    }
                    //Per vedere i dati collego la lista alla griglia
                    this.GrigliaDb.DataSource = listaArticoli;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Eccezione: " + ex.Message);
            }
        }

        private void AggiungiGiacenzaFunction(object sender, EventArgs e)
        {
            SqlConnection mySqlConnection = null;
            try
            {
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
                mySqlConnection = new SqlConnection(stringaConnessione);
                mySqlConnection.Open();

                string AggiornaGiacenza = "update Articoli set Giacenza = Giacenza + @AddGiacenza - @RemoveGiacenza where Id = @Id";

                SqlCommand mySqlCommand = new SqlCommand(stringaConnessione);
                mySqlCommand.Connection = mySqlConnection;

                SqlCommand UpdateGiacenza = new SqlCommand(string.Empty, mySqlConnection);
                UpdateGiacenza.CommandText = AggiornaGiacenza;

                UpdateGiacenza.Parameters.Add("@AddGiacenza", SqlDbType.NVarChar);
                UpdateGiacenza.Parameters["@AddGiacenza"].Value = this.AddQ.Text;

                UpdateGiacenza.Parameters.Add("@Id", SqlDbType.NVarChar);
                UpdateGiacenza.Parameters["@Id"].Value = this.IdQ.Text;

                UpdateGiacenza.Parameters.Add("@RemoveGiacenza", SqlDbType.NVarChar);
                UpdateGiacenza.Parameters["@RemoveGiacenza"].Value = this.RemoveQ.Text;

                UpdateGiacenza.ExecuteNonQuery();

                {
                    List<Articolo> listaArticoli = new List<Articolo>();


                    mySqlCommand.CommandText = "select * from Articoli";
                    IDataReader myReader = mySqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        //Legge un record alla volta
                        Articolo myArticolo = new Articolo();
                        myArticolo.Id = Convert.ToInt32(myReader["Id"]);
                        myArticolo.Nome = Convert.ToString(myReader["Nome"]);
                        myArticolo.Descrizione = Convert.ToString(myReader["Descrizione"]);
                        myArticolo.Giacenza = Convert.ToInt32(myReader["Giacenza"]);
                        myArticolo.AliquotaIva = Convert.ToInt32(myReader["AliquotaIva"]);
                        myArticolo.Prezzo = Convert.ToInt32(myReader["Prezzo"]);
                        listaArticoli.Add(myArticolo);
                    }
                    //Per vedere i dati collego la lista alla griglia
                    this.GrigliaDb.DataSource = listaArticoli;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Eccezione: " + ex.Message);
            }
        }

        private void AggiungiUser_Click(object sender, EventArgs e)
        {
            /*SqlConnection mySqlConnection = null;
            try
            {
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
                mySqlConnection = new SqlConnection(stringaConnessione);
                mySqlConnection.Open();
                SqlCommand mySqlCommand = new SqlCommand(stringaConnessione);
                mySqlCommand.Connection = mySqlConnection;

                mySqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar);
                mySqlCommand.Parameters["@Email"].Value = this.InputEmail.Text;

                mySqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar);
                mySqlCommand.Parameters["@Password"].Value = this.InputPassword.Text;

                mySqlCommand.CommandText = "INSERT INTO Log_in (Email, Password) VALUES(@Email, @Password)";

                mySqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Eccezzione: " + ex.Message);
            }*/
            SqlConnection mySqlConnection = null;

            try
            {
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
                mySqlConnection = new SqlConnection(stringaConnessione);
                mySqlConnection.Open();

                // Verifica se la mail è già presente nel database
                string verificaMailQuery = "SELECT COUNT(*) FROM Log_in WHERE Email = @Email";
                using (SqlCommand verificaMailCommand = new SqlCommand(verificaMailQuery, mySqlConnection))
                {
                    verificaMailCommand.Parameters.Add("@Email", SqlDbType.NVarChar);
                    verificaMailCommand.Parameters["@Email"].Value = this.InputEmail.Text;

                    int count = (int)verificaMailCommand.ExecuteScalar();

                    // Se la mail è già presente, mostra un messaggio e non procedere con l'inserimento
                    if (count > 0)
                    {
                        MessageBox.Show("Questa mail è già presente nel database. Inserimento non consentito.");
                    }
                    else
                    {
                        // La mail non è presente nel database, puoi procedere con l'inserimento.
                        SqlCommand inserimentoCommand = new SqlCommand(string.Empty, mySqlConnection);

                        inserimentoCommand.Parameters.Add("@Email", SqlDbType.NVarChar);
                        inserimentoCommand.Parameters["@Email"].Value = this.InputEmail.Text;

                        inserimentoCommand.Parameters.Add("@Password", SqlDbType.NVarChar);
                        inserimentoCommand.Parameters["@Password"].Value = this.InputPassword.Text;

                        inserimentoCommand.CommandText = "INSERT INTO Log_in (Email, Password) VALUES(@Email, @Password)";

                        inserimentoCommand.ExecuteNonQuery();

                        {
                            SqlConnection mySqlConnectionLog = null;
                            List<Log> listaLog = new List<Log>();

                            //Creo l'oggetto che mi permette di estrarre i dati
                            string stringaConnessioneLog = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
                            mySqlConnectionLog = new SqlConnection(stringaConnessioneLog);
                            mySqlConnectionLog.Open();
                            SqlCommand mySqlCommandLog = new SqlCommand(stringaConnessioneLog);
                            mySqlCommandLog.Connection = mySqlConnectionLog;
                            mySqlCommandLog.CommandText = "select * from Log_in";
                            IDataReader myReaderLog = mySqlCommandLog.ExecuteReader();
                            while (myReaderLog.Read())
                            {
                                //Legge un record alla volta
                                Log myUser = new Log();
                                myUser.Id = Convert.ToInt32(myReaderLog["Id"]);
                                myUser.Email = Convert.ToString(myReaderLog["Email"]);
                                myUser.Password = Convert.ToString(myReaderLog["Password"]);
                                listaLog.Add(myUser);
                            }
                            //Per vedere i dati collego la lista alla griglia
                            this.GrigliaLog.DataSource = listaLog;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eccezione: " + ex.Message);
            }
            finally
            {
                // Assicurati di chiudere la connessione quando hai finito
                if (mySqlConnection != null && mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
        }

        private void AggiungiElemento(object sender, EventArgs e)
        {
            SqlConnection mySqlConnection = null;
            try
            {
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
                mySqlConnection = new SqlConnection(stringaConnessione);
                mySqlConnection.Open();
                SqlCommand mySqlCommand = new SqlCommand(stringaConnessione);
                mySqlCommand.Connection = mySqlConnection;

                //Con le prossime 10 righe impediamo di aggiungere linquaggio SQL dentro i campi input

                if (InputNome.Text == "" || InputDesc.Text == "" || InputGiacenza.Text == "" || InputAli.Text == "" || InputPrezzo.Text == "")
                {
                    MessageBox.Show("Inserisci tutti i campi del prodotto");
                    return;
                }

                mySqlCommand.Parameters.Add("@Nome", SqlDbType.NVarChar);
                mySqlCommand.Parameters ["@Nome"].Value = this.InputNome.Text;

                mySqlCommand.Parameters.Add("@Descrizione", SqlDbType.NVarChar);
                mySqlCommand.Parameters["@Descrizione"].Value = this.InputDesc.Text;

                mySqlCommand.Parameters.Add("@Giacenza", SqlDbType.NVarChar);
                mySqlCommand.Parameters["@Giacenza"].Value = this.InputGiacenza.Text;

                mySqlCommand.Parameters.Add("@AliquotaIva", SqlDbType.NVarChar);
                mySqlCommand.Parameters["@AliquotaIva"].Value = this.InputAli.Text;

                mySqlCommand.Parameters.Add("@Prezzo", SqlDbType.NVarChar);
                mySqlCommand.Parameters["@Prezzo"].Value = this.InputPrezzo.Text;

                mySqlCommand.CommandText = "INSERT INTO Articoli (Nome, Descrizione, Giacenza, " +
                    "AliquotaIva, Prezzo) VALUES(@Nome, @Descrizione, @Giacenza, @AliquotaIva, @Prezzo)";

                mySqlCommand.ExecuteNonQuery();

                {
                    List<Articolo> listaArticoli = new List<Articolo>();


                    mySqlCommand.CommandText = "select * from Articoli";
                    IDataReader myReader = mySqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        //Legge un record alla volta
                        Articolo myArticolo = new Articolo();
                        myArticolo.Id = Convert.ToInt32(myReader["Id"]);
                        myArticolo.Nome = Convert.ToString(myReader["Nome"]);
                        myArticolo.Descrizione = Convert.ToString(myReader["Descrizione"]);
                        myArticolo.Giacenza = Convert.ToInt32(myReader["Giacenza"]);
                        myArticolo.AliquotaIva = Convert.ToInt32(myReader["AliquotaIva"]);
                        myArticolo.Prezzo = Convert.ToInt32(myReader["Prezzo"]);
                        listaArticoli.Add(myArticolo);
                    }
                    //Per vedere i dati collego la lista alla griglia
                    this.GrigliaDb.DataSource = listaArticoli;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore eccezzione:" + ex.Message);
            }
        }

        private void visualizzaLog(object sender, EventArgs e)
        {
            SqlConnection mySqlConnectionLog = null;
            List<Log> listaLog = new List<Log>();

            //Creo l'oggetto che mi permette di estrarre i dati
            string stringaConnessioneLog = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
            mySqlConnectionLog = new SqlConnection(stringaConnessioneLog);
            mySqlConnectionLog.Open();
            SqlCommand mySqlCommandLog = new SqlCommand(stringaConnessioneLog);
            mySqlCommandLog.Connection = mySqlConnectionLog;
            mySqlCommandLog.CommandText = "select * from Log_in";
            IDataReader myReaderLog = mySqlCommandLog.ExecuteReader();
            while (myReaderLog.Read())
            {
                //Legge un record alla volta
                Log myUser = new Log();
                myUser.Id = Convert.ToInt32(myReaderLog["Id"]);
                myUser.Email = Convert.ToString(myReaderLog["Email"]);
                myUser.Password = Convert.ToString(myReaderLog["Password"]);
                myUser.DurataToken = Convert.ToDateTime(myReaderLog["DataOraCreazioneToken"]);
                myUser.Token = Convert.ToString(myReaderLog["Token"]);
                listaLog.Add(myUser);
            }
            //Per vedere i dati collego la lista alla griglia
            this.GrigliaLog.DataSource = listaLog;
        }

        private void visualizzaGriglia(object sender, EventArgs e)
        {/*
            SqlConnection mySqlConnection = null;
            List<Articolo> listaArticoli = new List<Articolo>();

            try 
            {
                //Per connettermi al Database mi serve una stringa di connessione
                string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
                mySqlConnection = new SqlConnection(stringaConnessione);
                mySqlConnection.Open();
                //MessageBox.Show("Operazione riuscita");


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
                //Per vedere i dati collego la lista alla griglia
                this.GrigliaDb.DataSource = listaArticoli;
            }
            catch (Exception)
            {
                MessageBox.Show("Impossibile eseguire l'operazione");
            }
            finally 
            { 
                mySqlConnection.Close();
            }*/

            //Per connettermi al Database mi serve una stringa di connessione
            string stringaConnessione = "Server=localhost\\SQLEXPRESS; Database=Gestionale; Trusted_Connection=true";
            MySqlConnection = new SqlConnection(stringaConnessione);
            mySqlConnection.Open();
            //MessageBox.Show("Operazione riuscita");


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
            //Per vedere i dati collego la lista alla griglia
            this.GrigliaDb.DataSource = listaArticoli;
        }
            catch (Exception)
            {
                MessageBox.Show("Impossibile eseguire l'operazione");
            }
            finally 
            { 
                mySqlConnection.Close();
            }
*/
        }
    }
}
