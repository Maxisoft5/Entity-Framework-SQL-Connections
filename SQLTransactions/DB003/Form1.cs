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

namespace DB003
{
    public partial class Form1 : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        string strcom = "Select Фио,Гражданство,Дата_Рождения,Пол,Таможенные_формальности from dbo.Клиент";

        public Form1()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            var connection = new SqlConnection(connectionString);

            try
            {
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

                connection.Open();
                adapter = new SqlDataAdapter(strcom, connection);

                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                // делаем недоступным столбец id для изменения
                dataGridView1.Columns["Id"].ReadOnly = true;
            }
            catch
            {
                NLog.Logger logger = LogManager.GetCurrentClassLogger();
                logger.Trace("trace message");
                logger.Debug("debug message");
                logger.Info("info message");
                logger.Warn("warn message");
                logger.Error("error message");
                logger.Fatal("fatal message");

            }
            finally
            {
                connection.Close();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            string Fio = dataGridView1.CurrentCell.Value.ToString();
            byte fromalities = 0;

            if (checkBox1.Checked)
            {
                fromalities = 1;
            }
            else
            {
                fromalities = 0;
            }

            string sqlExpression = "modife";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                // параметр для ввода имени
                SqlParameter nadbavkaparam = new SqlParameter
                {
                    ParameterName = "@Nadbavka",
                    Value = fromalities
                };
                // добавляем параметр
                command.Parameters.Add(nadbavkaparam);
                // параметр для ввода возраста
                SqlParameter fioparam = new SqlParameter
                {
                    ParameterName = "@FIO",
                    Value = Fio
                };
                command.Parameters.Add(fioparam);

                var result = command.ExecuteScalar();

                // если нам не надо возвращать id
                //var result = command.ExecuteNonQuery();

                if (fromalities == 1)
                {
                    MessageBox.Show($"{fioparam.Value} now has had nadbavku");
                }
                else
                {
                    MessageBox.Show($"{fioparam.Value} now hasn't had nadbavku");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fio = string.Empty;
            string grazdanstvo = string.Empty;
            DateTime dataofbirth = new DateTime();
            string gender = string.Empty;
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                SqlCommand command = conn.CreateCommand();



                command.Transaction = transaction;

                try
                {
                    // Включение команд в транзакцию

                    command.CommandText = "INSERT INTO Клиент(Фио, Гражданство, Дата_Рождения, Пол) " +
                       "VALUES('Гринюк Максим Александровичч', 'Украинец','1999-10-05','Муржской')";
                    command.ExecuteNonQuery();
                    command.CommandText = "Update Клиент SET Гражданство = 'Belarus' WHERE Гражданство = 'Украинец'";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    MessageBox.Show("Data was added");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    // При возникновении любой ошибки выполняется откат транзакции.
                    transaction.Rollback();

                }

                finally
                {
                    conn.Close();
                }



            }


        }
    }
}

