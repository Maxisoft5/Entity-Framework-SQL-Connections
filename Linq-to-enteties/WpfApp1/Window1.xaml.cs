using LinqToEnteties.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        SqlConnectionStringBuilder builder;
        public Window1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ConnectedLayer conn = new ConnectedLayer();
            builder = new SqlConnectionStringBuilder(conn.connectionString);
            MainWindow main = new MainWindow();


            if(textBox.Text == builder.UserID && PasswordBox.Password == builder.Password)
            {
                this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Enter another login");
            }
            
        }
    }
}
