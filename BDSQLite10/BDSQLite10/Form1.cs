using BDSQLite10.EF;
using Lab9BD.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDSQLite10
{
    public partial class Form1 : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        TicketContext db;
        private String dbFileName;
        private SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        public Ticket Ticket { get; private set; }
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            db = new TicketContext();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket()
            {
                Id = 1,
                Arrival = textBox1.Text,
                Departure = textBox2.Text,
                Price = Convert.ToInt32(textBox3.Text)
            };
                db.Tickets.Add(ticket);
                db.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ticket ticket = db.Tickets.Where(t => t.Price == Convert.ToInt32(textBox3.Text)).ToList().First();
            db.Tickets.Remove(ticket);
            db.SaveChanges();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Ticket ticket = db.Tickets.Where(t => t.Id == Convert.ToInt32(textBox1.Text)).ToList().First();
            ticket.Price = Convert.ToInt32(textBox2.Text);
            ticket.Arrival = textBox3.Text;
            ticket.Departure = textBox4.Text;
            db.Entry(ticket).State = EntityState.Modified;
            db.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
    }
