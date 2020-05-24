using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Entity_Framework_Form_7
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectedLayer conn = new ConnectedLayer();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(conn.connectionString);

            MainForm main = new MainForm();
            if (loginBox.Text == builder.UserID && passwordBox.Text == builder.Password)
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
