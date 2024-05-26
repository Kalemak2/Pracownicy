using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy
{
    internal class DeleteWorkers
    {
        /*******************************************************  
         * nazwa klasy:          DeleteNotes
         * parametry wejściowe:  conn - połączenie z bazą danych
         * opis:                 Klasa umożliwia usunięcie pracownika z bazy danych.
         * autor:                Kornel Pakulski
         * ******************************************************/
        public DeleteWorkers(MySqlConnection conn) {
            new ShowWorkers(conn);

            Console.Write("Podaj ID pracownika do usunięcia: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                conn.Open();

                string query = $"SELECT COUNT(*) FROM workers WHERE id_worker = @id_worker";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_worker", id);
                int workerCount = Convert.ToInt32(cmd.ExecuteScalar());

                if (workerCount > 0)
                {
                    string querynotes = $"DELETE FROM note WHERE id_worker = {id}";
                    MySqlCommand insertNoteCmd = new MySqlCommand(querynotes, conn);
                    insertNoteCmd.ExecuteNonQuery();

                    string queryworkers = $"DELETE FROM workers WHERE id_worker = {id}";
                    MySqlCommand insertWorkerCmd = new MySqlCommand(queryworkers, conn);
                    insertWorkerCmd.ExecuteNonQuery();



                    Console.WriteLine("Pracownik został pomyślnie usunięty!");
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
