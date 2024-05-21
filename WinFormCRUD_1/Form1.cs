using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormCRUD_1.Config;

namespace WinFormCRUD_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Index();
        }
        ///
        public DataTable Index()
        {
            //ConnectionDB.ConnectionSQL();
            DataTable dt = new DataTable();
            string sqlSelect = "select * from Personas";
            SqlCommand sqlCmdSelect = new SqlCommand(sqlSelect, ConnectionDB.ConnectionSQL());

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmdSelect);
            adapter.Fill(dt);

            return dt;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlInsert = "insert into Personas (name, dni, dateBird, direction) values (@name, @dni, @dateBird, @direction)";

                SqlCommand sqlCmdInsert = new SqlCommand(sqlInsert, ConnectionDB.ConnectionSQL());

                sqlCmdInsert.Parameters.AddWithValue("@name", textBoxName.Text);
                sqlCmdInsert.Parameters.AddWithValue("@dni", Convert.ToInt32(textBoxDNI.Text));
                sqlCmdInsert.Parameters.AddWithValue("@dateBird", Convert.ToDateTime(dateTimeBirdPicker.Text));
                sqlCmdInsert.Parameters.AddWithValue("@direction", textBoxDirection.Text);

                sqlCmdInsert.ExecuteNonQuery();

                MessageBox.Show("Persona agregada");

                dataGridView1.DataSource = Index();
            }

            catch (SqlException ex) {

                if (ex.Number == 2627) // Código de error para clave duplicada en SQL Server
                {
                    MessageBox.Show("Error: Ya existe una persona registrada con el mismo DNI");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message);
                }
            } 
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            string sqlUpdate = "UPDATE Personas SET name=@name, dateBird=@dateBird, direction=@direction WHERE dni = @dni;";

            SqlCommand sqlCmdUpdate = new SqlCommand(sqlUpdate, ConnectionDB.ConnectionSQL());

            sqlCmdUpdate.Parameters.AddWithValue("@name", textBoxName.Text);
            sqlCmdUpdate.Parameters.AddWithValue("@dni", Convert.ToInt32(textBoxDNI.Text));
            sqlCmdUpdate.Parameters.AddWithValue("@dateBird", Convert.ToDateTime(dateTimeBirdPicker.Text));
            sqlCmdUpdate.Parameters.AddWithValue("@direction", textBoxDirection.Text);

            sqlCmdUpdate.ExecuteNonQuery();

            MessageBox.Show("Persona actualizada");

            dataGridView1.DataSource = Index();
        }


    }
}
