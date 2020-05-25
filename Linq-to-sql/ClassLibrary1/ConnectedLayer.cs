using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ConnectedLayer
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private SqlCommand oSqlCom;
        private SqlDataAdapter oSqlDtAdptr;

        public string str1 { get; set; }
        public string str2 { get; set; }

        public DataTable datatable1;
        public DataTable datatable2;

        private DataSet ds;
        private DataTable dt;
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

        public DataSet Read(string command, string command2, string _tableName, string _tableName2)
        {

            Logger logger = LogManager.GetCurrentClassLogger();

            ds = new DataSet();

            datatable1 = new DataTable(_tableName);
            datatable2 = new DataTable(_tableName2);


            using (SqlConnection oSqlCon = new SqlConnection(connectionString))
            {

                oSqlCon.Open();

                SqlCommand cmd = new SqlCommand(command, oSqlCon);
                SqlCommand cmd2 = new SqlCommand(command2, oSqlCon);


                logger.Trace(
               "Connection to" + Environment.NewLine +
                   "Data Source: " + oSqlCon.DataSource + Environment.NewLine +
                   "Database: " + oSqlCon.Database + Environment.NewLine +
                   "State: " + oSqlCon.State +
                   "User: " + builder.UserID +
                   "Catalog: " + builder.InitialCatalog +
                   "Server: " + builder.DataSource +
                   ""
                   );


                SqlDataReader tableReader = cmd.ExecuteReader();
                datatable1.Load(tableReader);
                tableReader.Close();

                SqlDataReader tableReader2 = cmd2.ExecuteReader();
                datatable2.Load(tableReader2);
                tableReader2.Close();

            }

            datatable2.PrimaryKey = new DataColumn[] { datatable2.Columns[0] };


            ds.Tables.AddRange(new DataTable[] { datatable1, datatable2 });

            var FK_countries = new ForeignKeyConstraint(datatable2.Columns["id_Страны"], datatable1.Columns["id_Страны"]);


            datatable1.Constraints.Add(FK_countries);


            logger.Info("таблица1: " + datatable1);

            logger.Trace("Прочитано таблицы " + datatable1);


            return ds;

        }
    }
}
