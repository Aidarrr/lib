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

namespace testMySqlWinForms
{
    public partial class Form1 : Form
    {
        MySqlConnection MySqlConnection;
        public MySqlDataAdapter adapter;
        public DataTable dataTable;
        public MySqlCommandBuilder commandBuilder;

        public void Connect()
        {
            const string cs = @"server=localhost;userid=root;password=flomaster;database=people;CharSet=utf8;";
            MySqlConnection = new MySqlConnection(cs);
            MySqlConnection.Open();
        }

        public void closeConnection()
        {
            MySqlConnection.Close();
        }

        public Form1()
        {
            InitializeComponent();
            Connect();
        }

        public void showWholeTable(DataGridView dataGridView1, string tableName)
        {
            string stmt = string.Format("SELECT * FROM {0}", tableName);
            getDataFromDB(dataGridView1, stmt);
            
        }

        public void getDataFromDB(DataGridView dataGridView1, string stmt)
        {
            dataTable = new DataTable();
            adapter = new MySqlDataAdapter(stmt, MySqlConnection);
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showWholeTable(dataGridView1, "men");
            closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            commandBuilder = new MySqlCommandBuilder(adapter);
            adapter.Update(dataTable);
            
        }
    }
}
