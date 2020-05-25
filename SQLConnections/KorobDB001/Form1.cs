using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;


namespace KorobDB001
{
    public partial class Form1 : Form
    {

        public Form1()  
        {
            InitializeComponent();
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {

            NLog.Logger logger = LogManager.GetCurrentClassLogger();
            logger.Trace("trace message");
            logger.Debug("debug message");
            logger.Info("info message");
            logger.Warn("warn message");
            logger.Error("error message");
            logger.Fatal("fatal message");
            
            string conStr = @"Data Source=COMPUTER2\MSSQLSERVER02;
                              Initial Catalog=Agency;   
                              Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(conStr))
            {

                try
                {
                    conn.StateChange += connection_StateChange;
                    conn.Open();
                    MessageBox.Show("Connection Open");
                    conn.Close();
                    MessageBox.Show("Connection closed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        static void connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            SqlConnection connection = sender as SqlConnection;



            MessageBox.Show                 //вывод информации о соединении и его состоянии
                (
                "Connection to" + Environment.NewLine +
                "Data Source: " + connection.DataSource + Environment.NewLine +
                "Database: " + connection.Database + Environment.NewLine +
                "State: " + connection.State
                );
        }

      
    }
}
