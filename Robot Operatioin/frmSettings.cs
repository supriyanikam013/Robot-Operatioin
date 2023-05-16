using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Robot_Operatioin
{
    public partial class frmSettings : Form
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        public frmSettings()
        {
            InitializeComponent();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPcPlcIpAddress.Text != "")
                {
                    //MySqlCommand cmd = new MySqlCommand("insert into communication (IPAddress,InBarcodeScanerComPort,InBarcodeScanerBaudRate,OutBarcodeScanerComPort,OutBarcodeScanerBaudPort)values('" + txtPcPlcIpAddress.Text + "','" + cmbInBarcodeScanerComPort.SelectedItem.ToString() + "','" + cmbInBarcodeScanerBaudRate.SelectedItem.ToString() + "','" + cmbOutBarcodeScanerComPort.SelectedItem.ToString() + "','" + cmbOutBarcodeScanerBaudRate.SelectedItem.ToString() + "')", con);
                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();
                    //MessageBox.Show("Record Saved Sucessfully ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MySqlCommand cmd = new MySqlCommand("update tblCommunication set IPAddress ='"+ txtPcPlcIpAddress .Text+ "' ", con);
                     con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Update Sucessfully ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPcPlcIpAddress.Focus();
                }
                else
                {
                    MessageBox.Show("Please Fill All Details ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPcPlcIpAddress.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSaveCommunication_Click, frmSettings", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                con.Close();
            }
        }
    }
}
