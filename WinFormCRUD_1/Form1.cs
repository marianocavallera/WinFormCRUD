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
    }
}
