using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinCAT.Ads;


namespace Robot_Operatioin
{
    public partial class PlcDataReadWrite : Form
    {
        private TcAdsClient adsClient;
        private int varhandler;
        public PlcDataReadWrite()
        {
            InitializeComponent();
        }

        private void PlcDataReadWrite_Load(object sender, EventArgs e)
        {
            adsClient = new TcAdsClient();
            adsClient.Connect(851);
        }

        private void btnread_Click(object sender, EventArgs e)
        {

        }
    }
}
