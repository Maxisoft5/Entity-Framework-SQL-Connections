using Lab9BD.EF;
using Lab9BD.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab9BD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public MainWindow()
        {
            InitializeComponent();
            logger = LogManager.GetCurrentClassLogger();
            logger.Trace("MainWindows has started");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (TicketContext db = new TicketContext())
            {
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@price", 1);
                var tickets = db.Database.SqlQuery<Ticket>("SELECT * FROM SelectThisAirplane (@price)", param);
                dataGrid.ItemsSource = tickets.ToList();
                logger.Info(tickets);
                logger.Info(dataGrid.ItemsSource);
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (TicketContext db = new TicketContext())
            {
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@id", 1);
                var tickets = db.Database.SqlQuery<Ticket>("SELECT * FROM GetAllowances (@id)", param);
                DataTable dataTable = new DataTable();
                dataGrid.ItemsSource = tickets.ToList();
                logger.Info(tickets);
                logger.Info(dataGrid.ItemsSource);
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            using (TicketContext db = new TicketContext())
            {
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@Arrival", "Kiev");
                var tickets = db.Database.SqlQuery<Ticket>("SelectDaparture @Arrival", param);
                dataGrid.ItemsSource = tickets.ToList();
                logger.Info(tickets);
                logger.Info(dataGrid.ItemsSource);
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            using (TicketContext db = new TicketContext())
            {
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@Arrival", "Kiev");
                var tickets = db.Database.SqlQuery<Ticket>("SelectDaparture @Arrival", param);
                dataGrid.ItemsSource = tickets.ToList();
                logger.Info(tickets);
                logger.Info(dataGrid.ItemsSource);
            }
        }
        private void procedure_Click(object sender, RoutedEventArgs e)
        {
            var oSqlCon = new SqlConnection(connectionString);
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Add(

                   new ConnectionStringSettings("ConnectionStr", "SomeConnectionString")
                   );

            config.Save();
            string command = "exec SelectDaparture 'Kiev'";
            SqlDataAdapter oSqlDtAdptr = new SqlDataAdapter(command, oSqlCon);
            DataTable dataTable = new DataTable();
            oSqlDtAdptr.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;

        }
    }
}
