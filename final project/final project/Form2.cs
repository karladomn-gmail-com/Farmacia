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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            string connect = "datasource=localhost;port=3306;username=root;password=;database=imss";
            string query = "INSERT INTO login(`id`,`user`,`password`) VALUES (NULL,' karla',SHA1 ('textBox2.Text '))";
            MySqlConnection databaseConnection = new MySqlConnection(connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (textBox1.Text == "")
                {
                    MessageBox.Show("No ingresaste una clave");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("No ingresaste un usuario ");
                }

                else
                {
                    MessageBox.Show("Exito al registrar usuario");
                }
             
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

