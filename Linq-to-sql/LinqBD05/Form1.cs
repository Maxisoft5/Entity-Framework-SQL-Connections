using ClassLibrary1;
using LinqBD05.Context;
using LinqBD05.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LinqBD05
{
    public partial class Form1 : Form
    {
        DbDataContext<Airplane> dc;
        DataContext db;
        ConnectedLayer connlayer;
        public string str1;
        public string str2;
        public Form1()
        {
            InitializeComponent();



        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connlayer = new ConnectedLayer();
            dc = new DbDataContext<Airplane>(connlayer.connectionString);
            Airplane airplane = new Airplane();

            var query = from u in dc.GetTable<Airplane>()
                        where u.Id > 5
                        select u;

            dataGridView1.DataSource = query.ToList();
            dc.SubmitChanges();

        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connlayer = new ConnectedLayer();
            dc = new DbDataContext<Airplane>(connlayer.connectionString);
            Airplane airplane = new Airplane { Type_Airplane = $"{textBox1.Text}", Class_Airplane = $"{textBox2.Text}" };
            dc.Insert(ref airplane);

        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connlayer = new ConnectedLayer();
            dc = new DbDataContext<Airplane>(connlayer.connectionString);

            Airplane airplane = new Airplane { Id = (int)dataGridView1.CurrentCell.Value };
            dc.Delete(airplane.Id);
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataCenter.Str1 = textBox1.Text;
            DataCenter.Str2 = textBox2.Text;
            dc = new DbDataContext<Airplane>(connlayer.connectionString);

            Airplane airplane = new Airplane { Id = (int)dataGridView1.CurrentCell.Value };

            dc.Update(airplane.Id);
           

        }


        private void procedureToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            dc = new DbDataContext<Airplane>(connlayer.connectionString);

            int id1 = (int)dataGridView1.CurrentCell.Value;

            var air = dc.GetTable<Airplane>();
            int _id = dc.GetAgeRange(ref id1);

            var query = from i in air
                        where i.Id == _id
                        select i;

            foreach (Airplane airplane in query)
                dataGridView1.DataSource = query;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
