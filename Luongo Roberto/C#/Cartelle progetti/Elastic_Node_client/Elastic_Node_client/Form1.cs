using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using Elasticsearch.Net;
using Nest;
using Elastic_Node_client.Properties;
using System.Runtime;

namespace Elastic_Node_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //elastic key -> ei1Bcm80NEJrNFhNUWhkcmY5Y1A6WWMxQkxpSjdRSy0yMU9WeGxuNDhyZw==
            //https://mydeployment-20e937.es.us-central1.gcp.cloud.es.io
            //create elastic client
            var connectionSettings = 
                new ConnectionSettings(new Uri("https://mydeployment-20e937.es.us-central1.gcp.cloud.es.io"))
                    .DefaultIndex("persone");
            var client = new ElasticClient(connectionSettings);
            string apiKey = "ei1Bcm80NEJrNFhNUWhkcmY5Y1A6WWMxQkxpSjdRSy0yMU9WeGxuNDhyZw==";

        }
    }
}
