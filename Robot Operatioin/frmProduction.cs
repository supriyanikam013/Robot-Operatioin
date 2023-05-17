using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Robot_Operatioin.BusinessLogic;
using static CYGNII_Operations_management.BusinessLogic.ApplicationLogic;
using TwinCAT.Ads;


namespace Robot_Operatioin
{
    public partial class frmProduction : Form
    {
        private TcAdsClient adsClient;
        private int varhandle;

        //hp
        Thread t;      // create new thread
        ThreadStart ts;     // thread start
        bool sendMail = false;

        
        string con_status = "";

        DeltaCommu PlcComm = new DeltaCommu();
        ushort[] result1 = { };
        string IP = "0.0.0.0";  // use IPAdress to connect to plc 
        ushort[] result2 = { };
        static string Del_NOK_data_Days = "";
        static string Report_send_to = "";
        static string A_shit_Report_Time = "";
        static string B_shit_Report_Time = "";
        static string C_shit_Report_Time = "";
        static string Line_Name = "";
        //hp
        string connstr = "";
        string queryStr = "";

        Color selectColor = Color.White;
        Color bypassColor = Color.Gray;
        Color passColor = Color.LimeGreen;
        Color failColor = Color.Crimson;
        Color notcheckedColor = Color.Khaki;
        private PLC plc = null;

       // private PlcComm = null;
        private ExceptionCode errorState = ExceptionCode.ExceptionNo;

        public frmProduction()
        {
            InitializeComponent();
        }
        public static string loginUserName, loginUserID, loginUserPassword, LoginAuthorisation; // create shared variable to access all forms
        public static string settingDate, settingTime;

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
                settingDate = lblDate.Text;
                settingTime = lblTime.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "timer1_Tick,frmHome", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void PRODUCTION_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1_Tick(null, null);
            timer1.Start();
            lblTime.Focus();
             connectToPlc(IP);
            //ConnectToPlc();
            lblUnm.Text = frmLogin.loginUserName;
            lblAuth.Text = frmLogin.LoginAuthorisation;
            lblCommunicationStatus.BackColor = Color.Red;
            try
            {

                adsClient.Connect(851);
                varhandle = adsClient.CreateVariableHandle("MAIN.text");
                lblCommunicationStatus.BackColor = Color.Green;
                MessageBox.Show(" PLC is connected ! ");
            }
            catch (Exception err)
            {
                MessageBox.Show($"Error: {err.Message}");
            }
            #region-------- send pc datetime info to plc on every time  when form load  to set both  pc and plc time same------------


            //DataType Datatyp = DataType.DataBlock;
            //int dbb = 1;
            //int startByteAdrr = 30;
            //string[] StringDatetime = { DateTime.Now.Year.ToString(),
            //                            DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(),
            //                            week[DateTime.Now.DayOfWeek.ToString()].ToString(), DateTime.Now.Hour.ToString(),
            //                            DateTime.Now.Minute.ToString() , DateTime.Now.Second.ToString()};

            //byte[] retByte = finalByteArry(StringDatetime);  // convert string array data to byte array data using finalByteArry function


            //x = plc.Write(Datatyp, dbb, startByteAdrr, retByte);  // send pc datetime to plc



            #endregion
        }

        private string connectToPlc(string IP)
        {
            string rslt = "";
            try
            {
                rslt = PlcComm.Connect(IP);
                // connect to Plc

                if (errorState != ExceptionCode.ExceptionNo)
                {
                    lblCommunicationStatus.BackColor = Color.Red;
                    //delay(1);
                    //connectToPlc();             // It will Contineu execute until connection not established
                }
                else
                {
                    lblCommunicationStatus.BackColor = Color.Green;
                }
                return rslt;
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message + " * Error In Function connectToPlc ,frmAuto * ";
                LogFileWrite("connectToPlc,frmAuto : " + ex.Message);
                //MessageBox.Show(ex.Message, "connectToPlc, frmAuto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // connectToPlc(IP);
                return rslt;
            }
        }

        public static void LogFileWrite(string message)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                string logFilePath = "E:\\LogError\\";

                logFilePath = logFilePath + "ProgramLog" + "-" + DateTime.Today.ToString("yyyy_MM_dd") + "." + "txt";

                if (logFilePath.Equals(""))
                {
                    return;
                }

                #region create logfile dictonary if does not exist

                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);

                if (!logDirInfo.Exists)
                {
                    logDirInfo.Create();
                }

                #endregion

                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                }

                streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(message);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
        }


        #region ------------Connect To PC---PLC using cpu type----------------

        //public void ConnectToPlc()
        //{
        //    try
        //    {
        //        CPU_Type cpu = CPU_Type.S7400;  // Plc Model Name
        //        //string ip = "200.200.200.200";   // Plc IP Address
        //        string ip = IP;   // Plc IP Address
        //        short rack = short.Parse("0");   // Plc Rack No
        //        short slot = short.Parse("1");   // Plc Track No


        //        plc = new PLC(cpu, ip, rack, slot);
        //        errorState = plc.Open();           // connect to Plc

        //        if (errorState != ExceptionCode.ExceptionNo)
        //        {
        //            lblPcPLCComm.BackColor = Color.Red;
        //            delay(1);
        //            ConnectToPlc();             // It will Contineu execute until connection not established
        //        }
        //        else
        //        {
        //            lblPcPLCComm.BackColor = Color.Green;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "connectToPlcError, frmAuto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        ConnectToPlc();
        //    }
        //}
        #endregion

        #region -----------------Delay Function-------------------------

        public void delay(int tim)   // to use when control goes faster without executing some statments
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (sw.ElapsedMilliseconds < tim)
                {
                    Application.DoEvents();
                }
                sw.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "delay frmAuto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion


      



    }
}
