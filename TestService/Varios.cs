using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestService.WebServiceCajaSol;

namespace TestService
{
    public partial class Varios : Form
    {
        public Varios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebServiInficajaSOAPPortTypeClient webServiInficaja = new WebServiInficajaSOAPPortTypeClient();

            txtResult.Text = "";

            //PROC_RegistrationData_ValidRequest req = new PROC_RegistrationData_ValidRequest();

            String llave = "39qa2o8QHKE/A4ffYHk3DuFAOyoJUbC17yFQgMo4M50AzuZwyn0xu1HvD8UQ8YwR+ZUEmlKRd5aDk1zzl7AdwsodFVvLQ";


            var resAsync = webServiInficaja.PROC_RegistrationData_ValidAsync(llave,"","","", "MONICA", "DE LA CRUZ FLORES", "noeheri@gmail.comt", "", "3411195926");
            resAsync.Wait();
            //resAsync.Result

            var results = resAsync.Result;
            if (results.PROC_RegistrationData_ValidResponse1.Length > 0)
                txtResult.Text = resAsync.Result.PROC_RegistrationData_ValidResponse1[0].sRD_Status;
        }
    }
}
