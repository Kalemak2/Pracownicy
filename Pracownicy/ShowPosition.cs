using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy
{
    internal class ShowPosition
    {
        public ShowPosition(MySqlConnection conn) {
            string query = "SELECT role.role_name, COUNT(workers.id_worker) AS liczba_osob FROM role LEFT JOIN workers ON role.id_role = workers.id_role WHERE workers.is_working = TRUE GROUP BY role.role_name;";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Stanowisko: {reader["role_name"]}");
                Console.WriteLine($"Liczba osób: {reader["liczba_osob"]}");
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
