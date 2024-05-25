using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy
{
    internal class ShowWorkers
    {     
        public ShowWorkers(MySqlConnection conn) {

            string query = "SELECT workers.id_worker, workers.name, workers.surname, workers.id_role, role.role_name FROM workers INNER JOIN role ON workers.id_role = role.id_role";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.Write($"{reader["id_worker"]}. {reader["name"]} {reader["surname"]} / {reader["role_name"]} \n");
            }

            conn.Close();
        }
    }
}
