using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace LibrariesClient
{
    class DBUtils
    {
        public MySqlConnection MySqlConnection;
        public MySqlDataAdapter adapter;
        public DataTable dataTable;
        public MySqlCommandBuilder commandBuilder;
        AddingService addingService;
        DeletingService deletingService;
        public string queryForShowingCurrentTable;

        public DBUtils()
        {
            addingService = new AddingService(this);
            deletingService = new DeletingService(this);
        }

        public void openConnection()
        {
            const string cs = @"server=localhost;userid=root;password=flomaster;database=libraries;CharSet=utf8;";
            MySqlConnection = new MySqlConnection(cs);
            MySqlConnection.Open();
        }

        public void closeConnection()
        {
            MySqlConnection.Close();
        }

        public void showTableFromDB(DataGridView destinationTable, string sourceTableName)
        {
            string stmt = string.Format("SELECT * FROM {0}", sourceTableName);

            switch (sourceTableName)
            {
                case "book":
                    stmt =
                        "SELECT b.id_book, l.name as Library, t.name as Topic, author, title, p.name as publisher, b.year, b.quantity " +
                        "FROM book as b JOIN library as l ON b.id_library=l.id " +
                        "JOIN topic as t ON b.id_topic = t.id JOIN publisher as p ON p.id = b.id_publisher";
                    break;
                case "reader":
                    stmt =
                        "SELECT r.id, r.name, r.email, r.phone_num, a.city, a.street, a.house, a.apartment FROM reader as r JOIN address as a ON r.id_address = a.id";
                    break;
                case "library":
                    stmt = "SELECT l.id, l.name, a.city, a.street, a.house FROM library as l JOIN address as a ON l.address_id = a.id";
                    break;
                case "subscription":
                    stmt = "SELECT s.id, l.name as library, b.title as book, r.name as reader, r.phone_num, s.issue_date, s.return_date, s.prepayment " +
                        "FROM subscription as s JOIN library as l ON l.id = s.id_library " +
                        "JOIN book as b ON b.id_book = s.id_book JOIN reader as r ON r.id = s.id_reader";
                    break;
            }
            queryForShowingCurrentTable = stmt;
            getDataFromDB(destinationTable, stmt);
        }

        public void getDataFromDB(DataGridView destinationTable, string stmt)
        {
            dataTable = new DataTable();
            adapter = new MySqlDataAdapter(stmt, MySqlConnection);
            adapter.Fill(dataTable);
            destinationTable.DataSource = dataTable;
        }

        public void addRowToTable(string tableName)
        {
            string query = getQueryByTableName(tableName);
            MySqlCommand command = new MySqlCommand(query, MySqlConnection);
            command.ExecuteNonQuery();
        }

        public void deleteRow(int id, string tableName)
        {
            deletingService.deleteRow(id, tableName);
        }

        public string getQueryByTableName(string tableName)
        {
            string query = "default";
            if(tableName == "address")
            {
                query = addingService.getStmtForInsertingIntoAddress();
            }
            else if(tableName == "topic")
            {
                query = addingService.getStmtForInsertingIntoTopic();
            }
            else if(tableName == "publisher")
            {
                query = addingService.getStmtForInsertingIntoPublisher();
            }
            else if(tableName == "library")
            {
                query = addingService.getStmtForInsertingIntoLibrary();
            }
            else if(tableName == "book")
            {
                query = addingService.getStmtForInsertingIntoBook();
            }

            return query;
        }
    }
}
