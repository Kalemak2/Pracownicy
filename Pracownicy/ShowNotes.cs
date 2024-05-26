using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy
{
    /*******************************************************  
     * nazwa klasy:          ShowNotes
     * parametry wejściowe:  conn - połączenie z bazą danych
     * opis:                 Klasa wyświetla wszystkie dodane notatki.
     * autor:                Kornel Pakulski
     * ******************************************************/
    internal class ShowNotes
    {
        public ShowNotes(MySqlConnection conn) {
            string query = "SELECT note.id_note, note.id_worker, workers.name, workers.surname, note.content, note.added_at FROM note INNER JOIN workers ON note.id_worker = workers.id_worker";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"ID: {reader["id_note"]}");
                Console.WriteLine($"Pracownik: {reader["name"]} {reader["surname"]}");
                Console.WriteLine($"Treść: {reader["content"]}");
                Console.WriteLine($"Dodano: {reader["added_at"]}");
                Console.WriteLine("-----------------------------");
            }

            conn.Close();
        }
    }
}
