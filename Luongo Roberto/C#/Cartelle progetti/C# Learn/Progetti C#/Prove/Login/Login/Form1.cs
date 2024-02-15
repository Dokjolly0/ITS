using System.Data.SqlClient;
using System.Data;
using Login.Classi;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Log_in.Click += Log_in_Function;
        }

        private void Log_in_Function(object? sender, EventArgs e)
        {
            string conn = "Server=localhost\\SQLEXPRESS; Database=Dati_Utente; Trusted_Connection=true";
            SqlConnection connessione = new SqlConnection(conn);
            try
            {
                connessione.Open();
                string select = "SELECT Email, Password FROM Log_in Where (Email = @Email AND Password = @Password)";
                SqlCommand cmd = new SqlCommand(select, connessione);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                cmd.Parameters["@Email"].Value = Email.Text;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar);
                cmd.Parameters["@Password"].Value = Password.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                //int query = cmd.ExecuteNonQuery();

                if(reader.HasRows)
                {
                    MessageBox.Show("Sei entrato");
                }
                else
                {
                    MessageBox.Show("Email o Password errati");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connessione.Close();
            }
        }
    }
}
