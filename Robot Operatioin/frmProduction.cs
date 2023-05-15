using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Robot_Operatioin.BusinessLogic;

namespace Robot_Operatioin
{
    public partial class frmProduction : Form
    {


        //hp
        Thread t;      // create new thread
        ThreadStart ts;     // thread start
        bool sendMail = false;

        
        string con_status = "";

        DeltaCommu PlcComm = new DeltaCommu();
        ushort[] result1 = { };
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

        //private PlcComm = null;
        //private ExceptionCode errorState = ExceptionCode.ExceptionNo;

        public frmProduction()
        {
            InitializeComponent();
        }
        public static string loginUserName, loginUserID, loginUserPassword, LoginAuthorisation; // create shared variable to access all forms
        public static string settingDate, settingTime;

        private void PRODUCTION_Load(object sender, EventArgs e)
        {

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


        //#region ------------Connect To PC---PLC using cpu type----------------

        //public void connectToPlc()
        //{
        //    try
        //    {
        //        CPU_Type cpu = CPU_Type.S71200;  // Plc Model Name
        //        //string ip = "200.200.200.200";   // Plc IP Address
        //        string ip = IPAdrs;   // Plc IP Address
        //        short rack = short.Parse("0");   // Plc Rack No
        //        short slot = short.Parse("1");   // Plc Track No


        //        plc = new PLC(cpu, ip, rack, slot);
        //        errorState = plc.Open();           // connect to Plc

        //        if (errorState != ExceptionCode.ExceptionNo)
        //        {
        //            txtPcPlcCommunication.BackColor = Color.Red;
        //            delay(1);
        //            connectToPlc();             // It will Contineu execute until connection not established
        //        }
        //        else
        //        {
        //            txtPcPlcCommunication.BackColor = Color.Green;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "connectToPlcError, frmAuto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        connectToPlc();
        //    }
        //}
        //#endregion



        #region ------------Connect To PC---PLC----------------

        public string connectToPlc(string IP)
        {
            string rslt = "";
            try
            {
                rslt = PlcComm.Connect(IP);

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
        #endregion  



    }
}
