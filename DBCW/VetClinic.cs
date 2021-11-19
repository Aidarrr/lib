using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DBCW
{
    public class Methods
    {
        public MySqlConnection MySqlConnection;
        public MySqlDataAdapter mAdapter;
        public DataTable dataTable;
        public MySqlCommandBuilder commandBuilder;
        public string stm;
        public List<string> colName = new List<string>();
        public List<string> selectList = new List<string>();

        public void Connect()
        {
            const string cs = @"server=localhost;userid=root;password=1;database=mydb;CharSet=utf8;";
            MySqlConnection = new MySqlConnection(cs);
            MySqlConnection.Open();
        }

        public Methods()
        {
            Connect();
        }

        public void OutPutTable(DataGridView dataGridView1)
        {
            dataTable = new DataTable();
            mAdapter = new MySqlDataAdapter(stm, MySqlConnection);
            mAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        public void Show(DataGridView dataGridView1, string tableName, CheckBox checkBox)
        {
            stm = string.Format("SELECT * FROM {0}", tableName);
            if (!checkBox.Checked)
                switch (tableName)
                {
                    case "Pets":
                        stm =
                            "SELECT idPets, namePet, kind, breed, age, firstName_Client FROM Pets p LEFT JOIN Clients c ON p.idClients = c.idClients";
                        break;
                    case "Medicament":
                        stm =
                            "SELECT idMedicament, code AS codeMed, m.Name AS medicament, expirationDate, form, price, d.Name AS disease FROM medicament m LEFT JOIN disease d ON m.idDisease = d.idDisease";
                        break;
                    case "journalPay":
                        stm =
                            "SELECT idjournalPay, codeCheck, sum, datePay, firstName_Emp AS Employees, firstName_Client AS Clients, Name AS Medicament FROM journalpay j LEFT JOIN employees e ON j.idEmployees = e.idEmployees LEFT JOIN clients c ON j.idClients = c.idClients LEFT JOIN medicament m ON j.idMedicament = m.idMedicament";
                        break;
                    case "journalTherapy":
                        stm =
                            "SELECT idjournalTherapy, namePet, Name AS disease, firstName_Emp AS employees  FROM journaltherapy j LEFT JOIN employees e ON j.idEmployees = e.idEmployees LEFT JOIN Pets p ON j.idPets = p.idPets LEFT JOIN disease d ON j.idDisease = d.idDisease";
                        break;
                }
            OutPutTable(dataGridView1);
            MySqlConnection.Close();
        }

        public void Update(DataGridView dataGridView1)
        {
            try
            {
                commandBuilder = new MySqlCommandBuilder(mAdapter);
                mAdapter.Update(dataTable);
                OutPutTable(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenView(DataGridView dataGridView1, string nameView)
        {
            try
            {
                stm = String.Format("SELECT * FROM {0}", nameView);
                OutPutTable(dataGridView1);
                dataGridView1.ReadOnly = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Find(DataGridView dataGridView1, string tableName, string word, CheckBox checkBox)
        {
            Connect();
            if (word == null || word == "")
                Show(dataGridView1, tableName, checkBox);
            else
                stm = string.Format("select * from {0} where {1}='{2}'", tableName, dataGridView1.Columns[1].Name, word);
            OutPutTable(dataGridView1);
            MySqlConnection.Close();
        }

        public void ReportAboutPrice(DataGridView dataGridView1, int filter)
        {
            try
            {
                stm = String.Format("SELECT c.idClients, firstName_Client, Name_Client, sum(sum) AS price FROM journalPay j LEFT JOIN Clients c ON j.idClients = c.idClients GROUP BY firstName_Client HAVING price >={0}", filter);
                OutPutTable(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReportAboutPets(DataGridView dataGridView1, string filter)
        {
            try
            {
                stm = String.Format("SELECT c.idClients, firstName_Client, Name_Client, namePet, kind FROM Pets p LEFT JOIN Clients c ON p.idClients = c.idClients GROUP BY firstName_Client HAVING kind = '{0}'", filter);
                OutPutTable(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ReportEmployees(DataGridView dataGridView1, int filter)
        {
            try
            {
                stm = String.Format("SELECT e.idEmployees, firstName_Emp, Name_Emp, post, sum(sum) AS price FROM journalPay j LEFT JOIN Employees e ON j.idEmployees = e.idEmployees GROUP BY idEmployees HAVING sum(sum) >={0}", filter);
                OutPutTable(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
