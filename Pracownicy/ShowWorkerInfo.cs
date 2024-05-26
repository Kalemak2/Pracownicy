using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pracownicy
{
    internal class ShowWorkerInfo
    {
        public ShowWorkerInfo(MySqlConnection conn) {
            new ShowWorkers(conn);

            Console.Write("Podaj id pracownika: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                conn.Open();

                string query = $"SELECT COUNT(*) FROM workers WHERE id_worker = @id_worker";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_worker", id);
                int workerCount = Convert.ToInt32(cmd.ExecuteScalar());

                if (workerCount > 0)
                {
                    query = $"SELECT workers.id_worker, workers.name, workers.surname, workers.login, workers.id_role, workers.hire_date, workers.age, role.role_name FROM workers INNER JOIN role ON workers.id_role = role.id_role WHERE workers.id_worker = @id_worker ";
                    MySqlCommand insertNoteCmd = new MySqlCommand(query, conn);
                    insertNoteCmd.Parameters.AddWithValue("@id_worker", id);
                    MySqlDataReader reader = insertNoteCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine($"ID: {reader["id_worker"]}");
                        Console.WriteLine($"{reader["name"]} {reader["surname"]} ({reader["age"]} lat)");
                        Console.WriteLine($"Login: {reader["login"]}");
                        Console.WriteLine($"Zatrudniony {reader["hire_date"]} na stanowisku {reader["role_name"]}");
                        Console.WriteLine("-----------------------------");
                    }

                }
                else
                {
                    Console.WriteLine("Pracownik o podanym ID nie istnieje!");
                }
                conn.Close();
            }
            else
            {
                Console.WriteLine("Podane ID nie jest liczbą!");
            }
        }
    }
}
