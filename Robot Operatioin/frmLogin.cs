using System;
using System.Data;
using System.Windows.Forms;
using CYGNII_Operations_management.BusinessLogic;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Robot_Operatioin
{
    public partial class frmLogin : Form
    {

        DataAccessLayer dal = new DataAccessLayer();
        public static frmProduction FormHome = new frmProduction();
        public static string loginUserName, loginUserID, loginUserPassword, LoginAuthorisation; // create shared variable to access all forms
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        public frmLogin()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

      


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from login where BINARY user_id='" + txtusername.Text + "' and BINARY password='" + txtpassword.Text + "'", con);
                DataTable dt = new DataTable();
                con.Open();
                MySqlDataAdapter dr = new MySqlDataAdapter(cmd);
                dr.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //Assign value to static varibale
                    loginUserID = dt.Rows[0][0].ToString();
                    loginUserName = dt.Rows[0][1].ToString();
                    loginUserPassword = dt.Rows[0][2].ToString();
                    LoginAuthorisation = dt.Rows[0][3].ToString();
                    txtusername.Clear();
                    txtpassword.Clear();


                    this.Hide();
                    frmProduction production = new frmProduction();
                    production.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please Fill Correct details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    txtusername.Text = "";
                    txtpassword.Text = "";
                    txtusername.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnOk frmLogin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
