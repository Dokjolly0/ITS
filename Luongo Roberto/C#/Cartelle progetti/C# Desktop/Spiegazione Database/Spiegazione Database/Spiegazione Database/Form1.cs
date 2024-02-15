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

namespace Spiegazione_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Accedi.Click += Accedi_Click;
            CReaAccount.Click += CreaAccountClick;
        }

        private void CreaAccountClick(object sender, EventArgs e)
        {
            try
            {
                string ComandoCreaAccount = "INSERT INTO Log_in (Email, Password) VALUES (@Email, @Password)";
                string stringaConnessioneCreate = "Server=localhost\\SQLEXPRESS; Database=Dati_Utente; Trusted_Connection=true";

                using (SqlConnection ConnessioneCreate = new SqlConnection(stringaConnessioneCreate))
                {
                    ConnessioneCreate.Open();
                    using (SqlCommand CreaAccountCommand = new SqlCommand(ComandoCreaAccount, ConnessioneCreate))
                    {
                        if (CreaPassword.Text == ConfermaCreaPassword.Text)
                        {
                            if(CreaPassword.Text.Length > 8 && CreaPassword.Text.Length < 17)
                            {
                                if(CreaEmail.TextLength > 8 )
                                {
                                    CreaAccountCommand.Parameters.Add("@Email", SqlDbType.NVarChar);
                                    CreaAccountCommand.Parameters["@Email"].Value = this.CreaEmail.Text;

                                    CreaAccountCommand.Parameters.Add("@Password", SqlDbType.NVarChar);
                                    CreaAccountCommand.Parameters["@Password"].Value = this.CreaPassword.Text;

                                    SqlDataReader AggiungiEmail = CreaAccountCommand.ExecuteReader();
                                    if (AggiungiEmail.Read())
                                    {
                                        AggiungiEmail.Close();
                                        MessageBox.Show("Account Creato con successo!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("I dati inseriti sono incorretti!");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("La password deve avere piu di 8 caratteri e massimo 16 caratteri!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Le 2 password non coincidono!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eccezzione: " + ex.Message);
            }
        }

        private void Accedi_Click(object sender, EventArgs e)
        {
            try
            {
                //Server=localhost\\SQLEXPRESS; -> che server vuoi usare
                //Database=Gestionale; -> che database voui usare
                //Trusted_Connection=true" -> Connessione vera
                string stringaConnessioneAccess = "Server=localhost\\SQLEXPRESS; Database=Dati_Utente; Trusted_Connection=true";

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
    }
}
