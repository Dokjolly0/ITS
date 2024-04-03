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

namespace Elastic_Node_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //create elastic client
            var connectionSettings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("my_index");
        }
    }
}
