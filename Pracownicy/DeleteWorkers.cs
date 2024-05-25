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
        public DeleteWorkers(MySqlConnection conn) {
            ShowWorkers showworkers = new ShowWorkers(conn);

            Console.WriteLine("Podaj ID pracownika do usunięcia: ");
            int id = Convert.ToInt16(Console.ReadLine());


            string query = $"DELETE FROM workers WHERE id_worker = {id}";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Pracownik zostaŁ pomyślnie usunięty!");
            conn.Close();


        }
    }
}
