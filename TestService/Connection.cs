using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestService.WebServiceCajaSol;


namespace TestService
{
    public partial class Connection : Form
    {
        //String WebServiceURL = "http://cajatonaya2019.sytes.net:81/WEBSERVIINFICAJA23_WEB/awws/WebServiInficaja.awws";

        public Connection()
        {
            InitializeComponent();
        }

        private void TestService_Load(object sender, EventArgs e)
        {
            

            //String config = ConfigurationSettings.AppSettings["system.serviceModel"].ToString();

            //MessageBox.Show("loaded");

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            WebServiInficajaSOAPPortTypeClient webServiInficaja = new WebServiInficajaSOAPPortTypeClient();

            txtResult.Text = "";

            var resAsync = webServiInficaja.PROC_ConnectionAsync("Test");
            resAsync.Wait();

            txtResult.Text = resAsync.Result.PROC_ConnectionResult;

            //MessageBox.Show(resAsync.Result.PROC_ConnectionResult);

        }
    }
}
