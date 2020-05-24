using MVC001.Models;
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

namespace EntityFrameworkBD7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        Logger logger = LogManager.GetCurrentClassLogger();
        ConnectedLayer connlay;
        public MainWindow()
        {

            logger.Trace("Windows is loaded");
            using (TicketContext db = new TicketContext())
            {
                InitializeComponent();
                Route route1 = new Route { Id = 1, DispatchCountry = "Ukraine", ArrivalCountry = "France", DispatchCity = "Kiev", ArrivalCity = "Paris", Arrival = DateTime.Now, Departure = DateTime.Now };

                Route route2 = new Route { Id = 2, DispatchCountry = "Ukraine", ArrivalCountry = "Germany", DispatchCity = "Kiev", ArrivalCity = "Berlin", Arrival = DateTime.Now, Departure = DateTime.Now };

                db.Routes.AddRange(new List<Route> { route1, route2 });
                db.SaveChanges();

                Ticket ticket1 = new Ticket {Id =1, FromTownDate = DateTime.Now, ToTownDate = DateTime.Now, Price = 500, NumberOfPassenger = 3, Row = 1, Seat = 1 };
                Ticket ticket2 = new Ticket {Id =2,  FromTownDate = DateTime.Now, ToTownDate = DateTime.Now, Price = 400, NumberOfPassenger = 3, Row = 1, Seat = 1 };
                db.Tickets.AddRange(new List<Ticket> { ticket1, ticket2 });

                db.SaveChanges();

                Customer customer1 = new Customer { ID = 1, FullName = "Степанов Александр Адреевич", BankCard = 34561234098548393, DateValidicity = DateTime.Now, CVV = 322 };

                logger.Trace(db.SaveChanges().ToString());
                dataGrid.ItemsSource = db.Tickets.ToList();
            }



        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            connlay = new ConnectedLayer();
            logger.Trace($" Command: Select * From {comboBox.SelectedIndex} ");
            var oSqlCon = new SqlConnection(connectionString);
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

            string command = $"Select * From {comboBox.SelectedIndex}";

            dataGrid.ItemsSource = connlay.Read(command).Tables;

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}

