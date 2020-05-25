using DAL;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase04
{
    public partial class Form1 : Form
    {
        ConnectedLayer connlayer = new ConnectedLayer();


        public Form1()
        {
            InitializeComponent();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string table1 = "Рейс";
            string table2 = "Страны";


            connlayer = new ConnectedLayer();
            string flightscmd = "SELECT id_Рейса,id_Страны,[Дата и время вылета],[Дата и время прибытия],[Город вылета],[Город прибытия] From Рейс";
            string countriescmd = "SELECT id_Страны,[Страна вылета],[Страна назначения],[Разные страны],[Входит ли в ООН] From Страны";
            connlayer.Read(flightscmd,countriescmd,table1,table2);

            dataGridView1.DataSource = connlayer.datatable1;
            dataGridView2.DataSource = connlayer.datatable2;
            

        }

    }
}
