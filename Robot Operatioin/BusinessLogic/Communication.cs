using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO.Ports;

namespace Robot_Operatioin.BusinessLogic
{
    class Communication
    {
        public static string MBComm;
        public static SqlConnection conn;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static SqlDataAdapter da;
        public static string[] SerialConfigData = new string[5];

        public static int plccomm = 0;
        public Communication()
        {
            databaseConnection();
            getSerialConfigData();
        }
        private void databaseConnection()
        {
            try
            {
                string server = "localhost";
                string database = "huf";
                string username = "root";
                string password = "saadmin";
                conn = new SqlConnection();
                if (conn != null)
                {
                    conn.Close();
                    conn.ConnectionString = string.Format("server={0}; database={1}; username={2}; password={3}; pooling=false", server, database, username, password);
                    conn.Open();

                }
            }
            catch (Exception ex)
            {
                plccomm = 0;
            }

            finally
            {
                conn.Close();
            }
        }

        public void getSerialConfigData()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Open();
                    cmd = new SqlCommand("select * from communication;", conn);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SerialConfigData[0] = dr["plcport"].ToString();
                            SerialConfigData[1] = dr["plcbaud"].ToString();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                plccomm = 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public int PortInit(SerialPort sp) // Intialisation Function for Com port Settings
        {
            // #################################################################################################
            // ##### FUNCTION : Initialises COM Port Settings
            // ##### ARGUMENT : Serialport 
            // ##### RETURN   : Nothing
            // #################################################################################################
            if (sp.IsOpen)
            {
                sp.Close();
            }

            sp.PortName = SerialConfigData[0].ToString();
            sp.BaudRate = Convert.ToInt32(SerialConfigData[1].ToString());

            sp.DataBits = 8;
            sp.Parity = Parity.Even;
            sp.StopBits = StopBits.One;

            sp.WriteTimeout = 500;
            sp.ReadTimeout = 500;
            try
            {
                sp.Open();

                plccomm = 1;

                return 1;
            }
            catch (Exception ExPortOpen)
            {
                plccomm = 0;
                return 0;
            }
        }

        public void PortClose(SerialPort sp)
        {
            // #################################################################################################
            // ##### FUNCTION : Closes COM Port 
            // ##### ARGUMENT : Serialport 
            // ##### RETURN   : Nothing
            // #################################################################################################
            sp.Close();
            plccomm = 0;
        }

    }
}
