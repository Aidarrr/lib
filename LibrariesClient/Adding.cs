using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesClient
{
    class Adding
    {
        DBUtils dBUtils;

        public Adding(DBUtils dBUtils)
        {
            this.dBUtils = dBUtils;
        }

        public void addRow(Table table, string tableName)
        {
            Dictionary<string, string> fieldsForInsertStmt = table.getNewRowDataFromUser();
            if (!InputFormGeneralData.isValidInput)
                return;
            if (!isFieldsValid(fieldsForInsertStmt))
                return;

            changeStringValuesToValidFormat(fieldsForInsertStmt, table);
            string insertQuery = getInsertQuery(fieldsForInsertStmt, tableName);
            executeInsertQuery(insertQuery);
        }

        private bool isFieldsValid(Dictionary<string, string> fieldsForInsertStmt)
        {
            foreach (var field in fieldsForInsertStmt)
            {
                if (field.Value == "" || field.Value == null)
                    return false;
            }

            return true;
        }

        private void changeStringValuesToValidFormat(Dictionary<string, string> fieldsForInsertStmt, Table table)
        {
            List<string> keys = new List<string>(fieldsForInsertStmt.Keys);

            foreach (var key in keys)
            {
                if (!isValueNumber(fieldsForInsertStmt[key]))
                {
                    fieldsForInsertStmt[key] = "'" + fieldsForInsertStmt[key] + "'";
                }
            }
        }

        private bool isValueNumber(string value)
        {
            int n;
            bool isNumeric = int.TryParse(value, out n);
            return isNumeric;
        }

        private string getInsertQuery(Dictionary<string, string> fieldsForInsertStmt, string tableName)
        {
            string insertQuery = "INSERT INTO " + tableName;

            string columnNames = " (";
            string values = " VALUES (";

            foreach (var field in fieldsForInsertStmt)
            {
                columnNames += field.Key + ",";
                values += field.Value + ",";
            }

            columnNames = columnNames.Substring(0, columnNames.Length - 1) + ")";
            values = values.Substring(0, values.Length - 1) + ")";

            insertQuery += columnNames + values;
            return insertQuery;
        }

        private void executeInsertQuery(string insertQuery)
        {
            MySqlCommand command = new MySqlCommand(insertQuery, dBUtils.MySqlConnection);
            command.ExecuteNonQuery();
        }
    }
}
