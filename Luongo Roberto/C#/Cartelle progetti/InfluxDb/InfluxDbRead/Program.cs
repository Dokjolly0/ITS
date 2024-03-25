using InfluxDB3.Client;
using System;
using System.Threading.Tasks;

namespace InfluxDbRead
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //YourOrganise -> Initialise client -> Copy hostUrl
                var hostUrl = "https://eu-central-1-1.aws.cloud2.influxdata.com";
                // authToken write the token copied
                var authToken =
                    "z0cj0akYOwMgxXEBgza61TLe_80tHZ-WNDcoWYJaGb0gvLFsAMckWrNJHmBRGmBFxHjbxg_o0gwnHI5RSiW2vg== ";
                InfluxDBClient client = new InfluxDBClient(hostUrl, authToken);
                Console.WriteLine("InfluxDbClient inizializzato");

                //Declare the name of the bucket
                string bucket = "new_bucket";
                string sqlString = "SELECT * FROM  Velocità WHERE time >= now() - interval '1 hour'";
                await foreach (var row in  client.Query(sqlString, database:bucket))
                {
                    string riga = row[0].ToString();
                    Console.WriteLine(riga);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
