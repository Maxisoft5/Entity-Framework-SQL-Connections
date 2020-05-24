using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkBD7
{
    class ConnectedLayer
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        Logger logger = LogManager.GetCurrentClassLogger();
        SqlConnectionStringBuilder builder;

        public ConnectedLayer()
        {


            builder = new SqlConnectionStringBuilder(connectionString);
            //ds = new DataSet();
            var oSqlCon = new SqlConnection(connectionString);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                logger.Trace(
                "Connection to" + Environment.NewLine +
                "Data Source: " + oSqlCon.DataSource + Environment.NewLine +
                "Database: " + oSqlCon.Database + Environment.NewLine +
                "State: " + oSqlCon.State +
                "User: " + builder.UserID +
                "Catalog: " + builder.InitialCatalog +
                "Server: " + builder.DataSource
              );



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

                config.Save();

            }

        }
        public DataSet Read(string command)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            var oSqlCon = new SqlConnection(connectionString);
            builder = new SqlConnectionStringBuilder(connectionString);

            oSqlCon.Open();

            SqlDataAdapter oSqlDtAdptr = new SqlDataAdapter(command, oSqlCon);

            DataSet ds = new DataSet();
            oSqlDtAdptr.Fill(ds);

            logger.Trace("UserId: " + builder.UserID);
            logger.Trace("UserCommand: " + command);
            logger.Trace("User's DataSet: " + ds);

            oSqlCon.Close();
            return ds;

        }

    }
}
