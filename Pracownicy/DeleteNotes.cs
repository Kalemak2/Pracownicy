using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy
{
    internal class DeleteNotes
    {
        /*******************************************************  
         * nazwa klasy:          DeleteNotes
         * parametry wejściowe:  conn - połączenie z bazą danych
         * opis:                 Klasa umożliwia usunięcie notatki z bazy danych.
         * autor:                Kornel Pakulski
         * ******************************************************/
        public DeleteNotes(MySqlConnection conn) { 
            new ShowNotes(conn);


            Console.Write("Podaj ID notatki do usunięcia: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                conn.Open();

                string query = $"SELECT COUNT(*) FROM note WHERE id_note = @id_note";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_note", id);
                int noteCount = Convert.ToInt32(cmd.ExecuteScalar());

                if (noteCount > 0)
                {
                    string querynotes = $"DELETE FROM note WHERE id_note = {id}";
                    MySqlCommand insertNoteCmd = new MySqlCommand(querynotes, conn);
                    insertNoteCmd.ExecuteNonQuery();

                    Console.WriteLine("Notatka została pomyślnie usunięta!");
                }
                else
                {
                    Console.WriteLine("Notatka o podanym ID nie istnieje!");
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
