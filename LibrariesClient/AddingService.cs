using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace LibrariesClient
{
    class AddingService
    {
        private DBUtils dBUtils;
        RepetitionService repetitionService;

        public AddingService(DBUtils dBUtils)
        {
            this.dBUtils = dBUtils;
            repetitionService = new RepetitionService(dBUtils);
        }

        public string getStmtForInsertingIntoAddress()
        {
            string windowName = "Добавление строки в таблицу адресов";
            var city = Interaction.InputBox("Введите город", windowName, "");
            var street = Interaction.InputBox("Введите наименование улицы", windowName, "");
            var house = Interaction.InputBox("Введите номер дома", windowName, "");
            var apartment = Interaction.InputBox("Введите номер квартиры", windowName, "");

            string stmt = String.Format("INSERT INTO address (city, street, house, apartment) VALUES ('{0}', '{1}', '{2}', {3})", city, street, house, apartment);
            return stmt;
        }

        public string getStmtForInsertingIntoTopic()
        {
            string windowName = "Добавление строки в таблицу \"Жанры\"";
            var name = Interaction.InputBox("Введите название жанра", windowName, "");

            string stmt = String.Format("INSERT INTO topic (name) VALUES ('{0}')", name);
            return stmt;
        }

        private bool isAddressPresent(string id)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM address WHERE id = " + id, dBUtils.MySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            bool isPresent = reader.Read();
            reader.Close();

            return isPresent;
        }

        public string getStmtForInsertingIntoPublisher()
        {
            string windowName = "Добавление строки в таблицу \"Издательства\"";
            var addrId = Interaction.InputBox("Введите id адреса издательства", windowName, "");
            if (!isAddressPresent(addrId))
            {
                dBUtils.addRowToTable("address");
            }
            
            var name = Interaction.InputBox("Введите наименование издательства", windowName, "");

            string stmt = String.Format("INSERT INTO publisher (name, address_id) VALUES ('{0}', {1})", name, addrId);
            return stmt;
        }

        public string getStmtForInsertingIntoLibrary()
        {
            string windowName = "Добавление строки в таблицу \"Библиотеки\"";
            var city = Interaction.InputBox("Введите город библиотеки", windowName, "");
            var street = Interaction.InputBox("Введите наименование улицы", windowName, "");
            var house = Interaction.InputBox("Введите номер дома библиотеки", windowName, "");

            int idAddr = repetitionService.isAddressPresent(city, street, house);
            if (idAddr == -1)
            {
                string stmtAddr = String.Format("INSERT INTO address (city, street, house) VALUES ('{0}', '{1}', '{2}')", city, street, house);
                MySqlCommand command = new MySqlCommand(stmtAddr, dBUtils.MySqlConnection);
                command.ExecuteNonQuery();

                idAddr = repetitionService.isAddressPresent(city, street, house);
            }

            var name = Interaction.InputBox("Введите название библиотеки", windowName, "");

            string stmt = String.Format("INSERT INTO library (name, address_id) VALUES ('{0}', {1})", name, idAddr);
            return stmt;
        }

        public string getStmtForInsertingIntoBook()
        {
            string windowName = "Добавление строки в таблицу \"Книги\"";

            var name = Interaction.InputBox("Введите название библиотеки", windowName, "");
            int id_lib = repetitionService.getIdOfLibrary(name);

            if (id_lib == -1)
            {
                string stmtLib = getStmtForInsertingIntoLibrary();
                MySqlCommand command = new MySqlCommand(stmtLib, dBUtils.MySqlConnection);
                command.ExecuteNonQuery();

                id_lib = repetitionService.getIdOfLibrary(name);
            }

            var topicName = Interaction.InputBox("Введите название жанра книги", windowName, "");
            int id_topic = repetitionService.getIdOfTopic(topicName);

            if (id_topic == -1)
            {
                string stmtTopic = String.Format("INSERT INTO topic (name) VALUES ('{0}')", topicName);
                MySqlCommand command = new MySqlCommand(stmtTopic, dBUtils.MySqlConnection);
                command.ExecuteNonQuery();

                id_topic = repetitionService.getIdOfTopic(topicName);
            }

            var publName = Interaction.InputBox("Введите наименование издателя", windowName, "");
            int id_pub = repetitionService.getIdOfPublisher(publName);

            if (id_pub == -1)
            {
                string stmtPub = getStmtForInsertingIntoPublisher();
                MySqlCommand command = new MySqlCommand(stmtPub, dBUtils.MySqlConnection);
                command.ExecuteNonQuery();

                id_pub = repetitionService.getIdOfPublisher(publName);
            }

            var author = Interaction.InputBox("Введите ФИО автора", windowName, "");
            var title = Interaction.InputBox("Введите название книги", windowName, "");
            var year = Interaction.InputBox("Введите год издания книги", windowName, "");
            var quantity = Interaction.InputBox("Введите кол-во книг в данной библиотеке", windowName, "");

            string stmt = String.Format("INSERT INTO book (id_library, id_topic, author, title, id_publisher, year, quantity) VALUES ({0}, {1}, '{2}', '{3}', {4}, {5}, {6})", id_lib, id_topic, author, title, id_pub, year, quantity);
            return stmt;
        }
    }
}
