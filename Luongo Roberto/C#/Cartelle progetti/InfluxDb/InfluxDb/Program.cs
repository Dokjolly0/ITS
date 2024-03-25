using InfluxDB3.Client;
using InfluxDB3.Client.Write;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InfluxDb
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Install influxdb3 on explorer solution, right click on Solution
            //Manage packages NuGet, Go to browse, search influxdb3 and install
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

                //Array with multi data
                var points = new[]
                {
                    //Single data
                    PointData.Measurement("Velocità")
                        .SetTag("Pilota", "Leclerk")
                        .SetField("kmh", 220.5),

                    //Single data
                    PointData.Measurement("Velocità")
                    .SetTag("Pilota", "Verstappen")
                    .SetField("kmh", 230.5),

                    //Single data
                    PointData.Measurement("Velocità")
                        .SetTag("Pilota", "Leclerk")
                        .SetField("kmh", 220.5),

                    //Single data
                    PointData.Measurement("Velocità")
                        .SetTag("Pilota", "Saintz")
                        .SetField("kmh", 220.5),

                    PointData.Measurement("Velocità")
                        .SetTag("Pilota", "Leclerk")
                        .SetField("kmh", 250.5),

                    //Single data
                    PointData.Measurement("Velocità")
                        .SetTag("Pilota", "Hamilton")
                        .SetField("kmh", 240.5),

                    //Single data
                    PointData.Measurement("Velocità")
                        .SetTag("Pilota", "Leclerk")
                        .SetField("kmh", 260.5),
                };

                //Uploat 1 to 1 to the Db
                foreach (var point in points)
                {
                    //Update to the db the record and the bucketName
                    await client.WritePointAsync(point, bucket);
                    Console.WriteLine("Scrittura del tempo del pilota");
                    //Wait 3 second for watch the result
                    Thread.Sleep(3000);
                }

                Console.WriteLine("Ho finito di scrivere i dati");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}
