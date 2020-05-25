using LinqBD05.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Build.Utilities;
using NLog;
using Logger = NLog.Logger;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using ClassLibrary1;

namespace LinqBD05.Context
{

    public class DbDataContext<T> : DataContext where T : class
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        Logger logger = LogManager.GetCurrentClassLogger();
        DataContext dc;
        SqlConnectionStringBuilder builder;
        ConnectedLayer connectedLayer;

        public DbDataContext(string str)
        : base(str)
        {

            builder = new SqlConnectionStringBuilder(connectionString);

            var oSqlCon = new SqlConnection(connectionString);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                logger.Trace(
             "Connection to" + Environment.NewLine +
             "Data Source: " + oSqlCon.DataSource + Environment.NewLine +
             "Database: " + oSqlCon.Database + Environment.NewLine +
             "State: " + oSqlCon.State +
             "User: " + builder.UserID +
             "Password:" + builder.Password +
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
        public void Insert(ref T readed)
        {
            var oSqlCon = new SqlConnection(connectionString);
            try
            {
                dc = new DataContext(connectionString);
                dc.GetTable<T>().InsertOnSubmit(readed);
                dc.SubmitChanges();
            }
            catch
            {
                logger.Trace(
             "Connection to" + Environment.NewLine +
             "Data Source: " + oSqlCon.DataSource + Environment.NewLine +
             "Database: " + oSqlCon.Database + Environment.NewLine +
             "State: " + oSqlCon.State +
             "User: " + builder.UserID +
             "Password:" + builder.Password +
             "Catalog: " + builder.InitialCatalog +
             "Server: " + builder.DataSource);
            }
        }
        public void Delete(int readed)
        {
            var oSqlCon = new SqlConnection(connectionString);
            try
            {
                dc = new DataContext(connectionString);
                var air = dc.GetTable<Airplane>();

                var query = from u in dc.GetTable<Airplane>()
                            where u.Id == readed
                            select u;

                dc.GetTable<Airplane>().DeleteOnSubmit(query.First());
                dc.SubmitChanges();
            }
            catch
            {

                logger.Trace(
             "Connection to" + Environment.NewLine +
             "Data Source: " + oSqlCon.DataSource + Environment.NewLine +
             "Database: " + oSqlCon.Database + Environment.NewLine +
             "State: " + oSqlCon.State +
             "User: " + builder.UserID +
             "Password:" + builder.Password +
             "Catalog: " + builder.InitialCatalog +
             "Server: " + builder.DataSource);
            }
        }
        public void Update(int readed)
        {
            var oSqlCon = new SqlConnection(connectionString);
            try
            {
                connectedLayer = new ConnectedLayer();
                dc = new DataContext(connectionString);
                var query = from u in dc.GetTable<Airplane>()
                            where u.Id == readed
                            select u;
                //   dc.GetTable<T>().InsertOnSubmit(readed);

                foreach (Airplane airplane in query)
                {
                    airplane.Type_Airplane = DataCenter.Str1;
                    airplane.Class_Airplane = DataCenter.Str2;
                }
                dc.SubmitChanges();
            }
            catch
            {
                logger.Trace(
             "Connection to" + Environment.NewLine +
             "Data Source: " + oSqlCon.DataSource + Environment.NewLine +
             "Database: " + oSqlCon.Database + Environment.NewLine +
             "State: " + oSqlCon.State +
             "User: " + builder.UserID +
             "Password:" + builder.Password +
             "Catalog: " + builder.InitialCatalog +
             "Server: " + builder.DataSource);
            }
        }


        public Table<Airplane> airplanes { get { return this.GetTable<Airplane>(); } }

        [Function(Name = "SelectId2")]
        [return: Parameter(DbType = "Int")]
        public int GetAgeRange([Parameter(Name = "id", DbType = "Int")] ref int id)

        {
            var oSqlCon = new SqlConnection(connectionString);
            try
            {
                IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), id);

                id = ((int)(result.GetParameterValue(0)));
            }
            catch
            {
                logger.Trace(
              "Connection to" + Environment.NewLine +
              "Data Source: " + oSqlCon.DataSource + Environment.NewLine +
              "Database: " + oSqlCon.Database + Environment.NewLine +
              "State: " + oSqlCon.State +
              "User: " + builder.UserID +
              "Password:" + builder.Password +
              "Catalog: " + builder.InitialCatalog +
              "Server: " + builder.DataSource);
            }
                return id;

        }
    }
}