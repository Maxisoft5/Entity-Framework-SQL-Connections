using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using NLog;

namespace ClassLibrary3
{
    public class ConnectedLayer
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private SqlCommand oSqlCom;
        private SqlDataAdapter oSqlDtAdptr;
        private DataSet ds;
        Logger logger;
        SqlConnectionStringBuilder sb;

        //Constructor 1 : Accepts Sql server instance name, 
        // and the database name
        public ConnectedLayer()
        {
            sb = new SqlConnectionStringBuilder(connectionString);
            ds = new DataSet();
            var oSqlCon = new SqlConnection(connectionString);
            Logger logger = LogManager.GetCurrentClassLogger();

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Add(

                   new ConnectionStringSettings("ConnectionStr", "SomeConnectionString")
                   );
            config.Save();
            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;

            if (section.SectionInformation.IsProtected)
            {
                section.SectionInformation.UnprotectSection();
            }
            else
            {
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            }
            logger.Trace("Connection: " + sb.ConnectionString);
            logger.Trace("InitialCatalog: " + sb.InitialCatalog);
            logger.Trace("UserId: " + sb.UserID);
            logger.Trace("DataSource: " + sb.DataSource);
            logger.Trace("DataSource: " + sb.IntegratedSecurity);
            config.Save();


        }

        public DataSet Read(string command)
        {
            logger = LogManager.GetCurrentClassLogger();
            var oSqlCon = new SqlConnection(connectionString);
            sb = new SqlConnectionStringBuilder(connectionString);

            oSqlCon.Open();

            oSqlDtAdptr = new SqlDataAdapter(command, oSqlCon);

            ds = new DataSet();
            oSqlDtAdptr.Fill(ds);

            logger.Trace("UserId: "+sb.UserID);
            logger.Trace("UserCommand: " + command);
            logger.Trace("User's DataSet: " + ds);

            oSqlCon.Close();
            return ds;

        }
        public int InsertUpdateDelete(string SqlCommandAsString)
        {
            logger = LogManager.GetCurrentClassLogger();
            sb = new SqlConnectionStringBuilder(connectionString);

            var oSqlCon = new SqlConnection(connectionString);
            try
            {
                // check whether the connection is not open  
                if (oSqlCon.State != ConnectionState.Open)
                {
                    oSqlCon.Open();
                }
                using (oSqlCom = new SqlCommand())
                {
                    // set the connection for the commnad  
                    oSqlCom.Connection = oSqlCon;
                    // assign the insert query as a text to the sql command  
                    oSqlCom.CommandText = SqlCommandAsString;
                    // this will return no of rows affected, by executing the query  
                    return oSqlCom.ExecuteNonQuery();
                }
            }
            catch (Exception Ex)
            {

                logger.Trace("Connection: " + sb.ConnectionString);
                logger.Trace("InitialCatalog: " + sb.InitialCatalog);
                logger.Trace("UserId: " + sb.UserID);
                logger.Trace("UserCommand: " + oSqlCom.CommandText);
                logger.Trace("User's DataSet: " + ds);
                throw Ex;
            }
            finally
            {
                if (oSqlCon.State == ConnectionState.Open)
                {
                    oSqlCon.Close();
                }
            }
        }
        //***********************************
        public DataTable FillDataSet(string SqlSelectCommandAsString, DataTable table)
        {
            logger = LogManager.GetCurrentClassLogger();
            var oSqlCon = new SqlConnection(connectionString);
            try
            {
                // check whether the connection is not open  
                if (oSqlCon.State != ConnectionState.Open)
                {
                    oSqlCon.Open();
                }
                using (oSqlCom = new SqlCommand())
                {
                    // set the connection for the commnad  
                    oSqlCom.Connection = oSqlCon;
                    // assign the insert query as a text to the sql command  
                    oSqlCom.CommandText = SqlSelectCommandAsString;
                    using (oSqlDtAdptr = new SqlDataAdapter())
                    {
                        oSqlDtAdptr.SelectCommand = oSqlCom;
                        oSqlDtAdptr.Fill(table);
                        return table;
                    }
                }
            }
            catch (Exception Ex)
            {
                logger.Trace("Connection: " + sb.ConnectionString);
                logger.Trace("InitialCatalog: " + sb.InitialCatalog);
                logger.Trace("UserId: " + sb.UserID);
                logger.Trace("UserCommand: " + oSqlCom.CommandText);
                logger.Trace("User's DataSet: " + ds);
                throw Ex;
            }
            finally
            {
                if (oSqlCon.State == ConnectionState.Open)
                {
                    oSqlCon.Close();
                }
            }
        }
        public void PrintDataset(DataSet dt)
        {
            logger = LogManager.GetCurrentClassLogger();
            var oSqlCon = new SqlConnection(connectionString);
            try
            {
                DataTableReader dtReader = dt.CreateDataReader();

                while (dtReader.Read())
                {
                    for (int i = 0; i < dtReader.FieldCount; i++)
                        Console.Write("{0}\t", dtReader.GetValue(i).ToString().Trim());
                    Console.WriteLine();
                }
                dtReader.Close();
            }

            catch (Exception Ex)
            {
                logger.Trace("Connection: " + sb.ConnectionString);
                logger.Trace("InitialCatalog: " + sb.InitialCatalog);
                logger.Trace("UserId: " + sb.UserID);
                logger.Trace("UserCommand: " + oSqlCom.CommandText);
                logger.Trace("User's DataSet: " + ds);
                throw Ex;
            }
            finally
            {
                if (oSqlCon.State == ConnectionState.Open)
                {
                    oSqlCon.Close();
                }
            }
        }
    }
}


