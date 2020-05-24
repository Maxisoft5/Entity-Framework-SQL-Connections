using Entity_Framework_Form_7.Models;
using MVC001.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity_Framework_Form_7
{
    public partial class MainForm : Form
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        Logger logger = LogManager.GetCurrentClassLogger();
        ConnectedLayer connlay;
        TicketContext db;
        DataSet ds;
        SqlDataAdapter adapter;
        public MainForm()
        {
            InitializeComponent();
            db = new TicketContext();

        }

        private void Read_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Select * From {comboBox1.SelectedItem}";
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);

                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                // делаем недоступным столбец id для изменения
                dataGridView1.Columns["Id"].ReadOnly = true;
            }

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TicketForm tkForm = new TicketForm();
            DialogResult result = tkForm.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            else if ( result == DialogResult.OK)
            {


                Waybill route = new Waybill();
                route.DispatchCity = tkForm.From.Text;
                route.ArrivalCity = tkForm.To.Text;
                route.Departure = tkForm.dateTimePicker1.Value;
                route.Arrival = tkForm.dateTimePicker2.Value;

                db.Waybills.Add(route);
                db.SaveChanges();

                Airplane airplane = new Airplane();
                airplane.Airplane_class = tkForm.comboBox2.SelectedItem.ToString();
                airplane.Airplane_type = tkForm.comboBox3.SelectedItem.ToString();
                db.Airplanes.Add(airplane);


                Ticket ticket = new Ticket();

                ticket.RouteID = route.Id;
                ticket.Route = route;
                ticket.Price = tkForm.comboBox1.SelectedIndex;
                ticket.NumberOfPassenger = (int)tkForm.numericUpDown1.Value;
                ticket.Row = (int)tkForm.numericUpDown2.Value;
                ticket.Seat = (int)tkForm.numericUpDown3.Value;




                db.Tickets.Add(ticket);
                db.SaveChanges();

                MessageBox.Show("Новый объект добавлен");
                return;
            }
        }

        private void updateTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Ticket ticket = db.Tickets.Find(id);
                Waybill route1 = db.Waybills.Find(id);

                TicketForm tkForm = new TicketForm();

                tkForm.From.Text = route1.DispatchCity;
                tkForm.To.Text = route1.ArrivalCity;
                tkForm.CountryTo.Text = route1.DispatchCity;
                tkForm.CountyFrom.Text = route1.ArrivalCity;
                tkForm.comboBox1.SelectedItem = ticket.Price;
                tkForm.numericUpDown1.Value = ticket.NumberOfPassenger;
                tkForm.numericUpDown2.Value = ticket.Row;
                tkForm.numericUpDown2.Value = ticket.Seat;

                DialogResult result = tkForm.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                ticket.Price = (int)tkForm.comboBox1.SelectedItem;
                ticket.NumberOfPassenger = (int)tkForm.numericUpDown1.Value;
                ticket.Row = (int)tkForm.numericUpDown2.Value;
                ticket.Seat = (int)tkForm.numericUpDown3.Value;
                route1.DispatchCity = tkForm.From.Text;
                route1.ArrivalCity = tkForm.To.Text;
                route1.DispatchCity = tkForm.CountryTo.Text;
                route1.ArrivalCity = tkForm.CountyFrom.Text;

                db.SaveChanges();
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");

            }
        }

        private void deleteTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Ticket ticket = db.Tickets.Find(id);
                Waybill route = db.Waybills.Find(id);
                db.Tickets.Remove(ticket);
                db.Waybills.Remove(route);
                db.SaveChanges();

                MessageBox.Show("Объект удален");
            }
        }

        private void readRouteTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TicketContext db = new TicketContext())
            {
                var tickets = db.Tickets.Include(p => p.Route).ToList();
                dataGridView1.DataSource = tickets;

            }
        }

        private void routeTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TicketContext db = new TicketContext())
            {
                var p = db.Tickets.FirstOrDefault();
                db.Entry(p).Reference("Airplane").Load();
                Console.WriteLine($"{p.Price} - {p.Airplane.Airplane_class}");

            }
        }

        private void ticketrouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TicketContext db = new TicketContext())
            {
                var players = db.Tickets.ToList();

                dataGridView1.DataSource = players;


                }
            }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

        private void k1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var user = db.Users.Include("Customer").ToList();
            dataGridView1.DataSource = user;
              
        }

        private void deleteTicket2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ticket ticket = db.Tickets.First(t => t.Price == 400);
            db.Tickets.Remove(ticket);
        }
    }
    }

