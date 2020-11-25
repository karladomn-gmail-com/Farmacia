using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace final_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ingresar()
        {
            string connect = "datasource=localhost;port=3306;username=root;password=;database=imss";
            string query = "select * from login where USER  = '" + textBox1.Text + "' AND PASSWORD = '" + textBox2.Text + "'";
            MySqlConnection databaseConnection = new MySqlConnection(connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Exito al ingresar");
                    Form2 registro = new Form2();
                    registro.Show();
                }
                else
                {
                    MessageBox.Show("Datos invalidos");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ingresar();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}


