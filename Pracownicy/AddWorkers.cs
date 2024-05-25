using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pracownicy
{
    internal class AddWorkers
    {
        public AddWorkers(MySqlConnection conn) {

            Console.Write("Podaj imie: ");
            string name = Console.ReadLine();

            Console.Write("Podaj nazwisko: ");
            string surname = Console.ReadLine();

            Console.Write("Podaj login: ");
            string login = Console.ReadLine();

            string password = Guid.NewGuid().ToString("d").Substring(1, 8);
            Console.WriteLine($"Wygenerowane hasło: {password}");

            Console.WriteLine($"Wybierz stanowisko: ");


            string[] options = {
                "Administrator",
                "Rekruter",
                "Programista",
                "H4",
            };

            int number = 1;
            foreach (string option in options)
            {
                Console.WriteLine($"{number++}. {option}");
            }


            int position = 0;

            while (position < 1 || position > 4)
            {
                Console.Write("Twój wybór: ");
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input >= 1 && input <= 4)
                    {
                        position = input;
                    }
                    else
                    {
                        Console.WriteLine("Podana liczba wyszła poza zakres!");
                    }
                }
                else
                {
                    Console.WriteLine("Proszę podać poprawną liczbę.");
                }
            }


            Console.Write("Podaj wiek pracownika: ");
            int.TryParse(Console.ReadLine(), out int age);

            DateTime hire_date = DateTime.Now;
            bool success = false;

            while (!success)
            {
                Console.Write("Podaj date zatrudnienia (np. 2022-01-22): ");
                string input = Console.ReadLine();

                success = DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out hire_date);

                if (!success)
                {
                    Console.WriteLine("Nieprawidłowy format daty. Użyj formatu yyyy-MM-dd.");
                }
            }

            string query = $"INSERT INTO workers (name, surname, login, password, id_role, age, hire_date) VALUES ('{name}', '{surname}', '{login}', '{password}', '{position}', {age}, '{hire_date.ToString("yyyy-MM-dd")}')";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Console.WriteLine($"Pracownik {name} {surname} został dodany pomyślnie!");
            conn.Close();
        }
    }
}
