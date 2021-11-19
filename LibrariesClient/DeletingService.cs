using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesClient
{
    class DeletingService
    {
        DBUtils dBUtils;

        public DeletingService(DBUtils dBUtils)
        {
            this.dBUtils = dBUtils;
        }

        public void deleteRow(int id, string tableName)
        {
            string query = String.Format("DELETE FROM {0} WHERE id={1}", tableName, id);
            if(tableName == "book")
                query = String.Format("DELETE FROM {0} WHERE id_book={1}", tableName, id);

            MySqlCommand command = new MySqlCommand(query, dBUtils.MySqlConnection);
            command.ExecuteNonQuery();
        }
    }
}
