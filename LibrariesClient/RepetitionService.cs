using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesClient
{
    class RepetitionService
    {
        DBUtils dBUtils;
        public RepetitionService(DBUtils dBUtils)
        {
            this.dBUtils = dBUtils;
        }

        public int isAddressPresent(string city, string street, string house)
        {
            int id;
            MySqlCommand command = 
                new MySqlCommand(String.Format("SELECT * FROM address WHERE city = '{0}' AND street = '{1}' " +
                "AND house = '{2}'", city, street, house), dBUtils.MySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            bool isPresent = reader.Read();

            if (isPresent)
            {
                id = (int)reader[0];
            }
            else
            {
                id = -1;
            }
            
            reader.Close();

            return id;
        }

        public int getIdOfTopic(string name)
        {
            int id;
            MySqlCommand command =
                new MySqlCommand(String.Format("SELECT * FROM topic WHERE name = '{0}'", name), dBUtils.MySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            bool isPresent = reader.Read();

            if (isPresent)
            {
                id = (int)reader[0];
            }
            else
            {
                id = -1;
            }

            reader.Close();

            return id;
        }

        public int getIdOfLibrary(string name)
        {
            int id;
            MySqlCommand command =
                new MySqlCommand(String.Format("SELECT * FROM library WHERE name = '{0}'", name), dBUtils.MySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            bool isPresent = reader.Read();

            if (isPresent)
            {
                id = (int)reader[0];
            }
            else
            {
                id = -1;
            }

            reader.Close();

            return id;
        }

        public int getIdOfPublisher(string name)
        {
            int id;
            MySqlCommand command =
                new MySqlCommand(String.Format("SELECT * FROM publisher WHERE name = '{0}'", name), dBUtils.MySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            bool isPresent = reader.Read();

            if (isPresent)
            {
                id = (int)reader[0];
            }
            else
            {
                id = -1;
            }

            reader.Close();

            return id;
        }
    }
}
