using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestService.WebServiInficaja;

namespace TestService
{
    public partial class TestService : Form
    {
        public TestService()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            WebServiInficajaSOAPPortTypeClient webServi = new WebServiInficajaSOAPPortTypeClient();

            var res = webServi.PROC_ConnectionAsync("Test");
            res.Wait();

            MessageBox.Show("RESULT:" + res.Result.PROC_ConnectionResult);

            //webServi.

        }
    }
}
