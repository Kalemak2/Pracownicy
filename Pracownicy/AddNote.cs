using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy
{
    internal class AddNote
    {
        /*******************************************************  
         * nazwa klasy:          AddNote
         * parametry wejściowe:  conn - połączenie z bazą danych
         * opis:                 Klasa umożliwia dodawanie notatek do bazy danych.
         * autor:                Kornel Pakulski
         * ******************************************************/
        public AddNote(MySqlConnection conn) {

            new ShowWorkers(conn);

            Console.Write("\nPodaj treść notatki: ");
            string content = Console.ReadLine();
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
                    query = "INSERT INTO notes(id_worker, content) VALUES (@id_worker, @content)";
                    MySqlCommand insertNoteCmd = new MySqlCommand(query, conn);
                    insertNoteCmd.Parameters.AddWithValue("@content", content);
                    insertNoteCmd.Parameters.AddWithValue("@id_worker", id);
                    insertNoteCmd.ExecuteNonQuery();

                    Console.WriteLine("Notatka została dodana pomyślnie!");
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