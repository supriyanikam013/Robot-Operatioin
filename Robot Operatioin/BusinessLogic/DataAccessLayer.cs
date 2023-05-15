/// Created Date : 15- April- 2023*/
/// Created By : Supriya choudhary
/// Modified By :
/// Ver 1.1
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
namespace CYGNII_Operations_management.BusinessLogic
{
    public class DataAccessLayer
    {
        #region Class Level Va SqlConnection Conn;
        SqlConnection Conn;
        SqlCommand SqlCmd;
        SqlDataAdapter DatAdptr;
        SqlDataReader DtRdr;
        DataTable dt;
        private SqlDataAdapter dr;
        string str = "";

        #endregion
        /// <summary>
        /// open database connection
        /// </summary>
        /// <returns></returns>
        #region Openconnection Method
        public string OpenConnection()
        {
            if (Conn == null)
            {
               // SqlConnection conDal = new SqlConnection(ConfigurationManager.ConnectionStrings["connDal"].ConnectionString);
                Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            }

            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
            SqlCmd = new SqlCommand();
            SqlCmd.CommandTimeout = 120;
            SqlCmd.Connection = Conn;
            return ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }
        #endregion


        #region CloseConnection and Dispose Connection Method
        public void CloseConnection()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            DisposeConnection();
        }
        #endregion


        #region DisposeConnection Method
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        public void DisposeConnection()
        {
            if (Conn != null)
            {
                Conn.Dispose();
                Conn = null;
            }
        }
        #endregion

        #region ExecuteSql Method

        public int ExecuteSql(string strsql)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = strsql;
            int intresult;
            intresult = SqlCmd.ExecuteNonQuery();
            CloseConnection();
            return intresult;
        }
        #endregion

        public string chkAlreadyExist(string command)
        {
            // chkAlreadyExist function return string as Record already exist or not if not then return OK 

            try
            {
                if (Conn.State != ConnectionState.Open)// check connection open
                {
                    Conn.Open();
                }
                SqlCmd = new SqlCommand(command, Conn);
                dt = new DataTable();
                DatAdptr = new SqlDataAdapter(SqlCmd);
                DatAdptr.Fill(dt);                            // fill datatable

                // if datatable has no row means no Recoed Avaialable retrun OK Status
                if (dt.Rows.Count <= 0)
                {
                    str = "OK";
                }
                else  // if datatable has row means Recoed Avaialable retrun Record already exist Status
                {
                    str = "Record already exist ";
                }

                if (Conn.State != ConnectionState.Closed)// check connection close
                {
                    Conn.Close();
                }

                return str;

            }
            catch (Exception ex)
            {
                if (Conn.State != ConnectionState.Closed)// If error then close connection
                {
                    Conn.Close();
                }

                return ex.Message; // if error found then return error meaasge as status 
            }


        }


        #region ------------  Auto Page Operation -----------------

        public DataSet getDataSet(string connStr)
        {
            DataSet ds = new DataSet();

            try
            {
                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter(connStr, Conn);
                da.Fill(ds, "tbl0");
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }

            return ds;
        }

        public DataTable getDatatable_WithSrNo(ref string result, string connStr)
        {
            DataTable dt = new DataTable();

            try
            {

                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }
                dt.Columns.Add("Sr_No", typeof(System.Int32));
                dt.Columns["Sr_No"].AutoIncrement = true;
                dt.Columns["Sr_No"].AutoIncrementSeed = 1;
                dt.Columns["Sr_No"].AutoIncrementStep = 1;
                SqlDataAdapter da = new SqlDataAdapter(connStr, Conn);
                da.Fill(dt);

                result = "OK";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }

            return dt;
        }

        public DataTable getDatatable(ref string result, string connStr)
        {
            DataTable dt = new DataTable();

            try
            {

                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter(connStr, Conn);
                da.Fill(dt);

                result = "OK";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }

            return dt;
        }

        public string update_crnt_stn(string table_name, string date, string time, string primaryBcd, string Bcd1, string Bcd2, string bcd3, string cyc_status)
        {
            try
            {
                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }

                SqlCmd = new SqlCommand("update " + table_name + " set Date_='" + date + "',Time_='" + time + "',BCD_1='" + Bcd1 + "',BCD_2='" + Bcd2 + "',BCD_3='" + bcd3 + "',Stat='" + cyc_status + "' where Primary_Barcode='" + primaryBcd + "'", Conn);
                var xx = SqlCmd.ExecuteNonQuery();
                if (xx == 0)
                {
                    str = "NOK";
                }
                else
                {
                    str = "OK";
                }


                return str;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public string force_update_crnt_stn(string table_name, string date, string time, string primaryBcd, string Bcd1, string Bcd2, string bcd3)
        {
            try
            {
                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }

                SqlCmd = new SqlCommand("update " + table_name + " set Date_='" + date + "',Time_='" + time + "',BCD_1='" + Bcd1 + "',BCD_2='" + Bcd2 + "',BCD_3='" + bcd3 + "' where Primary_Barcode='" + primaryBcd + "'", Conn);
                SqlCmd.ExecuteNonQuery();

                return str = "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public string insert_Into_Sta1ToStn9(string date, string time, string primaryBcd, string Bcd1, string Bcd2, string bcd3, string cyc_status)
        {
            try
            {
                //DateTime A = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss.ffffff"));

                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }
                ////get max ID from station 1
                SqlCmd = new SqlCommand("select max(ID + 1) from st_1data", Conn);
                int ID = Convert.ToInt32(SqlCmd.ExecuteScalar()); // add max ID + 1 to create new ID

                //TimeSpan c = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss.ffffff")) - A;

                SqlCmd = new SqlCommand("sp_inset_bcd_stn1_to_9", Conn);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlCmd.Parameters.AddWithValue("IDD", ID);
                SqlCmd.Parameters.AddWithValue("Primary_Barcode", primaryBcd);
                SqlCmd.Parameters.AddWithValue("BCD_1", Bcd1);
                SqlCmd.Parameters.AddWithValue("BCD_2", Bcd2);
                SqlCmd.Parameters.AddWithValue("BCD_3", bcd3);
                SqlCmd.Parameters.AddWithValue("Stat", cyc_status);
               
                // Check Store Procedure Execute Sucessfully Or Not OUT value call  
                SqlCmd.Parameters.Add(new SqlParameter("chk_sp_execute_sucess", SqlDbType.VarChar));
                SqlCmd.Parameters["chk_sp_execute_sucess"].Direction = ParameterDirection.Output;

                SqlCmd.ExecuteNonQuery();

                string Chk_SP_Execute_Sucess = (string)SqlCmd.Parameters["chk_sp_execute_sucess"].Value;

                #region ------------ Insert Command-------------------------------------

                //////get max ID from station 1
                //cmd = new MySqlCommand("select max(ID + 1) from st_1data", con);
                //int ID = Convert.ToInt32(cmd.ExecuteScalar()); // add max ID + 1 to create new ID

                //cmd = new MySqlCommand("insert into st_1data(id,Date_,Time_,Primary_Barcode,BCD_1,BCD_2,BCD_3,Stat) values('" + ID + "','" + date + "','" + time + "','" + primaryBcd + "','" + Bcd1 + "','" + Bcd2 + "','" + bcd3 + "','" + cyc_status + "'); "
                //                       + "insert into st_2data (id,Primary_Barcode) values ('" + ID + "','" + primaryBcd + "'); "
                //                       + "insert into st_3data (id,Primary_Barcode) values ('" + ID + "','" + primaryBcd + "'); "
                //                       + "insert into st_4data (id,Primary_Barcode) values ('" + ID + "','" + primaryBcd + "'); "
                //                       + "insert into st_5data (id,Primary_Barcode) values ('" + ID + "','" + primaryBcd + "'); "
                //                       + "insert into st_6data (id,Primary_Barcode) values ('" + ID + "','" + primaryBcd + "'); "
                //                       + "insert into st_7data (id,Primary_Barcode) values ('" + ID + "','" + primaryBcd + "'); "
                //                       + "insert into st_8data (id,Primary_Barcode) values ('" + ID + "','" + primaryBcd + "'); "
                //                       + "insert into st_9data (id,Primary_Barcode) values ('" + ID + "','" + primaryBcd + "'); ", con);

                //cmd.ExecuteNonQuery();
                #endregion


                //TimeSpan B = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss.ffffff")) - A; 

                if (Chk_SP_Execute_Sucess == "Sucessfully") // IF Store Procedure Execute Sucess the return Sucessfully
                {
                    return str = "OK";  // return "Record Saved Sucessfully" as status 
                }
                else // IF Store Procedure Execute Error the return Error
                {
                    return str = "NOK";
                }

            }

            catch (Exception ex)
            {
                return ex.Message; // if error found then return error meaasge as status 
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();    // close connection
                }
            }

        }

       

      

        public string getPlcStaionAddress(string[] plcStaionName)
        {
            string[] plcStaionAddress;

            try
            {

                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }

                for (int i = 0; i < plcStaionName.Length; i++)
                {
                    SqlCmd = new SqlCommand("select ");
                }

                return str;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        public DataTable getPrev_stn_status(string Curnt_Stn_Name, string Previs_stn_Name, string Model_Name)
        {
            DateTime A = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss.ffffff"));
            try
            {
                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }

                //cmd = new MySqlCommand("select Stat from " + Staion_Name + " where Primary_Barcode='" + Primary_Barcode + "' ", con);

                //SqlCmd = new SqlCommand("select Curnt_stn.Stat as Curnt_stat,previous_stn.Stat as previous_stat from " + Curnt_Stn_Name + " as Curnt_stn inner join "
                //                        + " " + Previs_stn_Name + " as previous_stn on Curnt_stn.Primary_Barcode = previous_stn.Primary_Barcode where Curnt_stn.Primary_Barcode ='" + Primary_Barcode + "'", Conn);

                dt = new DataTable();
                dr = new SqlDataAdapter(SqlCmd);
                dr.Fill(dt);

                TimeSpan B = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss.ffffff")) - A;  // 00:00:00.2657690}  00:00:00.0781070}
                return dt;

            }
            //catch (Exception)
            //{
            //    //return "DB_Error-"+ ex.Message;
            //}

            finally
            {
                if (Conn.State != ConnectionState.Closed)
                {
                    Conn.Close();
                }
            }
        }

        

        #endregion

        #region GetDataTable Method

        public DataTable GetDataTable(string strsql)
        {
            OpenConnection();
            DatAdptr = new SqlDataAdapter(strsql, Conn);
            DataTable dtTble = new DataTable();
            DatAdptr.Fill(dtTble);
            DatAdptr.Dispose();
            CloseConnection();

            return dtTble;
        }
        #endregion


        #region GetDataSet Method

        public DataSet GetDataSet(string strsql)
        {
            OpenConnection();
            DatAdptr = new SqlDataAdapter(strsql, Conn);
            DataSet dtSet = new DataSet();
            DatAdptr.Fill(dtSet);
            DatAdptr.Dispose();
            CloseConnection(); 
            return dtSet;
        }
        #endregion

        #region GetDataSet using Stored Procedure Method

        public DataSet GetDataSetExecuteProcedure(string ProcName, SqlParameter[] SqlParams)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlCmd.Parameters.Clear();
            foreach (SqlParameter thisParam in SqlParams)
            {
                SqlCmd.Parameters.Add((SqlParameter)thisParam);
            }
            DataSet ds = new DataSet();

            SqlDataAdapter sd = new SqlDataAdapter();
            sd.SelectCommand = SqlCmd;
            sd.Fill(ds);
            return ds;
        }
        #endregion


        #region  Execute Stored Procedure Return DataTable
        public DataTable ExecuteStoredProcedureDataTable(string ProcName, SqlParameter[] SqlParams)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlCmd.Parameters.Clear();
            foreach (SqlParameter thisParam in SqlParams)
            {
                SqlCmd.Parameters.Add((SqlParameter)thisParam);
            }
            SqlDataAdapter sd = new SqlDataAdapter(SqlCmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            CloseConnection();
            return dt;
        }
        #endregion

        #region  Execute Stored Procedure Return DataTable
        internal DataTable ExecuteStoredProcedureDataTableCommonGrid(string ProcName)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlDataAdapter sd = new SqlDataAdapter(SqlCmd.CommandText, Conn);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            CloseConnection();
            return dt;
        }
        #endregion

        #region GetDataReader Using Command Method

        public SqlDataReader GetDataReader(string strsql)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = strsql;
            DtRdr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
            return DtRdr;
        }
        #endregion

        #region IsExist Method

        public Boolean IsExist(string strsql)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = strsql;
            int intresult;
            intresult = (int)SqlCmd.ExecuteScalar();
            CloseConnection();
            if (intresult > 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        #endregion

        #region ExecuteScalar Method
        public string ExecuteScalar(string strsql)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = strsql;
            string strresult;
            strresult = Convert.ToString(SqlCmd.ExecuteScalar());
            CloseConnection();
            DisposeConnection();
            return strresult;
        }
        #endregion

        #region Execute Stored Procedure

        public string ExecuteStoredProcedure(string ProcName, SqlParameter[] SqlParams)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlCmd.Parameters.Clear();
            foreach (SqlParameter thisParam in SqlParams)
            {
                SqlCmd.Parameters.Add((SqlParameter)thisParam);
            }
            // SqlCmd.ExecuteReader();
            SqlCmd.ExecuteNonQuery();
  
            // string  intresult = (int)SqlCmd.Parameters["@returnval"].Value;
            string intresult = SqlCmd.Parameters["ReturnVal"].Value.ToString();
            // @ReturnVal could be any name

          
            CloseConnection();
            //var result = returnParameter.Value;
            return intresult;
        }


        #endregion

        #region  Return int value ExecuteStoreProcedure
        #endregion

        #region Execute Stored Procedure Return Integer

        public int ExecuteStoredProcedureRetnInt(string ProcName, SqlParameter[] SqlParams)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlCmd.Parameters.Clear();
            foreach (SqlParameter thisParam in SqlParams)
            {
                SqlCmd.Parameters.Add((SqlParameter)thisParam);
            }
            SqlCmd.Parameters["@ReturnVal"].Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();

              int returnvalue = Convert.ToInt32(SqlCmd.Parameters["@ReturnVal"].Value.ToString());
            CloseConnection();
            return returnvalue;
        }
        #endregion

        #region Execute DataReader using Stored Procedure

        public SqlDataReader ExecuteDataReaderStoredProcedure(string ProcName, SqlParameter[] SqlParams)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlCmd.Parameters.Clear();
            foreach (SqlParameter thisParam in SqlParams)
            {
                SqlCmd.Parameters.Add((SqlParameter)thisParam);
            }
            DtRdr = SqlCmd.ExecuteReader(CommandBehavior.CloseConnection);
            return DtRdr;

        }

        #endregion

    }
}