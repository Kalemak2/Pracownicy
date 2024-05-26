using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy
{
    internal class ChangePassword
    {
        public ChangePassword(MySqlConnection conn)
        {
            new ShowWorkers(conn);

            Console.Write("Podaj ID pracownika, któremu chcesz zmienić hasło: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                conn.Open();

                string query = $"SELECT COUNT(*) FROM workers WHERE id_worker = @id_worker";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_worker", id);
                int workerCount = Convert.ToInt32(cmd.ExecuteScalar());

                if (workerCount > 0)
                {
                    string password = Guid.NewGuid().ToString("d").Substring(1, 8);
                    Console.WriteLine($"Nowe hasło pracownika o ID {id} to {password}");
                    query = $"UPDATE workers SET password = @password WHERE id_worker = @id_worker";
                    MySqlCommand insertNoteCmd = new MySqlCommand(query, conn);
                    insertNoteCmd.Parameters.AddWithValue("@id_worker", id);
                    insertNoteCmd.Parameters.AddWithValue("@password", password);
                    insertNoteCmd.ExecuteNonQuery();
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
