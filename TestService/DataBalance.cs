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
using System.Windows.Forms.VisualStyles;
using TestService.WebServiceCajaSol;


namespace TestService
{
    public partial class DataBalance : Form
    {
        //String WebServiceURL = "http://cajatonaya2019.sytes.net:81/WEBSERVIINFICAJA23_WEB/awws/WebServiInficaja.awws";

        public DataBalance()
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

            txtResult.Text = "";
            
            int cliente;
            string llave;

            if(!Int32.TryParse(txtCliente.Text, out cliente))
            {
                MessageBox.Show("Debe ingresar un Cliente válido!");
                txtCliente.Focus();
                return;
            }

            if (txtLlave.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Debe ingresar una LlaveConexion válida!");
                txtLlave.Focus();
                return;
            }

            llave = txtLlave.Text.Trim();

            using(WebServiInficajaSOAPPortTypeClient webServiInficaja = new WebServiInficajaSOAPPortTypeClient())
            {
                var resAsync = webServiInficaja.PROC_DataBalanceAsync(cliente,"",0,0,0,llave);
                resAsync.Wait();

                PROC_DataBalanceResponse resp = resAsync.Result;

                //resp.ToString();

                string result = "";

                if (resp != null)
                {
                    result += "nDbCuenta: " + resp.PROC_DataBalanceResponse1[0].nDbCuenta.ToString();
                    result += Environment.NewLine + "sDbNombreCuenta: " + resp.PROC_DataBalanceResponse1[0].sDbNombreCuenta;
                    
                }

                txtResult.Text = result;

                //txtResult.Text = resp.PROC_DataBalanceResponse1[0].sDbNombreCuenta;
            }

        }

    }
}
