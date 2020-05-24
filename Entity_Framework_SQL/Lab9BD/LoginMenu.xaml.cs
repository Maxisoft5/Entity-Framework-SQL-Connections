using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab9BD
{
    /// <summary>
    /// Interaction logic for LoginMenu.xaml
    /// </summary>
    public partial class LoginMenu : Window
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public LoginMenu()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);

            MainWindow main = new MainWindow();
            if (textBox.Text == builder.UserID && textBox1.Text == builder.Password)
            {
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Enter another login");
            }
        }

    }
}
