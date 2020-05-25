using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqBD05
{
    public partial class Login : Form
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connectionString);
            Form1 form1 = new Form1();
            NLog.Logger logger = LogManager.GetCurrentClassLogger();
       


            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                try
                {
                    sb.UserID = textBox1.Text;
                    sb.Password = textBox2.Text;
                    conn.StateChange += connection_StateChange;
                    conn.Open();
                    MessageBox.Show("Logined");
                    conn.Close();
                    MessageBox.Show("Connection closed");
                    this.Hide();
                    form1.ShowDialog();
                }
                catch
                {
                    logger.Trace("UserId" + sb.UserID);
                    logger.Debug("Passsword" + sb.Password);
                    logger.Info("DataSource" + sb.DataSource);
                    logger.Info("DataSource" + sb.InitialCatalog);

                }
                finally
                {
                    conn.Close();
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
