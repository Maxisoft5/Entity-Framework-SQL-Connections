using LinqToEnteties.EF;
using LinqToEnteties.Models;
using NLog;
using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TicketContext db;
        Logger logger = LogManager.GetCurrentClassLogger();
        public MainWindow()
        {
            InitializeComponent();
            db = new TicketContext();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var select = db.Cruises.Select(p => new
            {
                TownFrom = p.FromTown,
                TownTo = p.FromTown
            });

            logger.Info("Linq select end work");
            dataGrid.ItemsSource = select.ToList();

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

            var select = db.Cruises.Join(db.Tickets,
           p => p.ID, 
            c => c.ID, 
           (p, c) => new
           {
               Arrive = p.DateArrive,
               IDTicket = c.ID,
               Departure = p.DateDeparture
           });
            logger.Info("Linq join end work");
            dataGrid.ItemsSource = select.ToList();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var select = db.Tickets.OrderBy(p => p.Row);
            logger.Info("Linq order by end work");
            dataGrid.ItemsSource = select.ToList();

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            var groups = from p in db.Tickets
                         group p by p.Row into g
                         select new { Name = g.Key, Count = g.Count() };
            logger.Info("Linq group by end work");
            dataGrid.ItemsSource = groups.ToList();

        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            int number2 = db.Cruises.Count(p => p.ToTown == "Kiev");
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            var selector1 = db.Tickets.Where(p => p.Price < 400); 
            var selector2 = db.Tickets.Where(p => p.ID > 3); 
            var tickets = selector1.Except(selector2); 
            logger.Info("Linq exception end work");
            dataGrid.ItemsSource = tickets.ToList();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            var tickets = db.Tickets.Where(p => p.Price < 300)
                .Union(db.Tickets.Where(p => p.ID < 2));
            logger.Info("Linq union end work");
            dataGrid.ItemsSource = tickets.ToList();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            var tickets = db.Tickets.Where(p => p.Price < 400)
                  .Intersect(db.Tickets.Where(p => p.ID > 2));
            logger.Info("Linq intersect end work");
            dataGrid.ItemsSource = tickets.ToList();
        }
    }

}
