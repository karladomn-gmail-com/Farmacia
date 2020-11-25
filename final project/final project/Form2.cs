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
            string connection = "datasource=localhost;port=33068;username=Dnlpq66;password=irhN3e0c1Tzu;database=farmacia";
            string query = "SELECT * FROM md";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                conectionDatabase.Open();
                reader = databaseCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        //Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " "+reader.GetString(3));
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);

                    }
                }
                else
                {
                    Console.WriteLine("Base de datos vacía!!");
                }
                conectionDatabase.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
    private void GuardarUsuario()
    {
        string connection = "datasource=localhost;port=33068;username=Dnlpq66;password=irhN3e0c1Tzu;database=farmacia";
        string query = "INSERT INTO md(`ID`, `codigo`, `nombre`, `precio`,`estado`) VALUES (NULL, '" + textBox1.Text + "', '" + textBox3.Text + "', '" + textBox2.Text + "','" + textBox5.Text + "')";
        MySqlConnection conectionDatabase = new MySqlConnection(connection);
        MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
        databaseCommand.CommandTimeout = 60;

        try
        {
            conectionDatabase.Open();
            MySqlDataReader reader1 = databaseCommand.ExecuteReader();
            MessageBox.Show("Dato guardado con éxito.");
            conectionDatabase.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void ActualizarUsuario()
    {
        string connection = "datasource=localhost;port=33068;username=Dnlpq66;password=irhN3e0c1Tzu;database=farmacia";
        string query = "UPDATE `md` SET  `codigo`='" + textBox1.Text + "', `nombre`='" + textBox3.Text + "', `precio`='" + textBox2.Text + "',`estado`='" + textBox5.Text + "' WHERE ID = '" + textBox4.Text + "' ";
        MySqlConnection conectionDatabase = new MySqlConnection(connection);
        MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
        databaseCommand.CommandTimeout = 60;

        try
        {
            conectionDatabase.Open();
            MySqlDataReader reader1 = databaseCommand.ExecuteReader();
            MessageBox.Show("Lograste Actualizar el dato");
            conectionDatabase.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void BuscarUsuario()
    {
        string connection = "datasource=localhost;port=33068;username=Dnlpq66;password=irhN3e0c1Tzu;database=farmacia";
        string query = "SELECT * FROM md WHERE ID ='" + textBox4.Text + "' ";
        MySqlConnection conectionDatabase = new MySqlConnection(connection);
        MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
        databaseCommand.CommandTimeout = 60;
        MySqlDataReader reader;
        try
        {
            conectionDatabase.Open();
            reader = databaseCommand.ExecuteReader();
            if (reader.HasRows)
            {
                listView1.Items.Clear();
                while (reader.Read())
                {
                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4) };

                    textBox1.Text = row[1];
                    textBox2.Text = row[3];
                    textBox3.Text = row[2];
                    textBox5.Text = row[4];
                }
            }
            else
            {
                Console.WriteLine("No se encontraron datos");
            }
        }

        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void DeleteUsuario()
    {
        string connection = "datasource=localhost;port=33068;username=Dnlpq66;password=irhN3e0c1Tzu;database=farmacia";
        string query = "DELETE FROM `md` WHERE ID = '" + textBox4.Text + "' ";
        MySqlConnection mySqlConnection = new MySqlConnection(connection);
        MySqlConnection conectionDatabase = mySqlConnection;
        MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
        databaseCommand.CommandTimeout = 60;

        try
        {
            conectionDatabase.Open();
            MySqlDataReader reader1 = databaseCommand.ExecuteReader();
            MessageBox.Show("Lograste Eliminar el dato");
            conectionDatabase.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void MostrarUsuario()
    {
        string Connect = "datasource=localhost;port=33068;username=Dnlpq66;password=irhN3e0c1Tzu;database=farmacia";
        string query = "SELECT * FROM md";
        MySqlConnection databaseConnection = new MySqlConnection(Connect);
        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
        commandDatabase.CommandTimeout = 60;
        MySqlDataReader reader;

        try
        {
            databaseConnection.Open();
            reader = commandDatabase.ExecuteReader();
            if (reader.HasRows)
            {
                listView1.Items.Clear();
                while (reader.Read())
                {
                    string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4) };
                    var ListViewItems = new ListViewItem(row);
                    listView1.Items.Add(ListViewItems);
                }

            }
            else
            {
                Console.WriteLine("No se encontro nada");
            }
            databaseConnection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }
    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {// Guardar Dato
        if (textBox1.Text == "")
        {
            MessageBox.Show("Falta el Código");
        }
        else if (textBox3.Text == "")
        {
            MessageBox.Show("No ingresaste nombre del medicamento");
        }
        else if (textBox2.Text == "")
        {
            MessageBox.Show("No ingresaste la cantidad");
        }
        else if (textBox5.Text == "")
        {
            MessageBox.Show("Falta incluir el Estado");
        }

        else
        {
            ActualizarUsuario();
            MostrarUsuario();
            DeleteUsuario();
            GuardarUsuario();
            textBox1.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";


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
            string connect = "datasource=localhost;port=3306;username=root;password=;database=imss";
            string query = "INSERT INTO login(`id`,`user`,`password`) VALUES (NULL,'" + textBox1.Text + "','" + textBox2.Text + "')";
            MySqlConnection databaseConnection = new MySqlConnection(connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();
                MessageBox.Show("Exito al registrar usuario");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
