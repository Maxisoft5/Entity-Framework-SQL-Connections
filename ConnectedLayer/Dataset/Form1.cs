using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary3;
using System.Data.SqlClient;
using NLog;

namespace Dataset
{
    public partial class Form1 : Form
    {
        ConnectedLayer layer;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;

        }

        private void Insert(object sender, EventArgs e)
        {
            layer = new ConnectedLayer();
            string comm = $"Insert into dbo.Самолёт Values ('{textBox1.Text}','{textBox2.Text}')";
            layer.InsertUpdateDelete(comm);

        }

        private void Refreshing(object sender, EventArgs e)
        {
            // Обновление формы
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
        }

        private void Delete(object sender, EventArgs e)
        {
            layer = new ConnectedLayer();
            string comm = $"Delete From dbo.Самолёт where [Тип самолёта] = '{dataGridView1.CurrentCell.Value.ToString()}';";
            layer.InsertUpdateDelete(comm);

        }

        private void Update(object sender, EventArgs e)
        {
            layer = new ConnectedLayer();
            string comm = $"Update dbo.Самолёт SET [Тип самолёта] = '{textBox1.Text}' WHERE [Тип самолёта] = '{dataGridView1.CurrentCell.Value.ToString()}';";
            layer.InsertUpdateDelete(comm);

        }

        private void Reading(object sender, EventArgs e)
        {
            // Чтение таблицы
            layer = new ConnectedLayer();
            string commandsel = "Select [Тип самолёта],[Класс самолёта] from dbo.Самолёт";
            dataGridView1.DataSource = layer.Read(commandsel).Tables[0];
        }
    }
     
}
