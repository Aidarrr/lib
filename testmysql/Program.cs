using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // строка подключения к базе данных
            string connectionString = "server=localhost;user=root;database=people;password=flomaster;";
            // объект для установления соединения с БД
            MySqlConnection connection = new MySqlConnection(connectionString);
            // открываем соединение
            connection.Open();
            // запросы
            // запрос вставки данных
            string query = "INSERT INTO men (id, name, age) VALUES (4, 'Kate', 18)";
            // запрос обновления данных
            string query2 = "UPDATE men SET age = 22 WHERE id = 4";
            // запрос удаления данных
            string query3 = "DELETE FROM men WHERE id = 4";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query3, connection);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            connection.Close();
        }
    }
}