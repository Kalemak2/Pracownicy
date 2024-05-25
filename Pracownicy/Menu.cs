using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Pracownicy
{
    internal class Menu
    {
        public Menu(MySqlConnection conn) {
            Console.WriteLine("Witaj w aplikacji do zarządzania pracownikami!");

            string[] options = {
                "Dodaj nowego pracownika",
                "Wyświetl pracowników",
                "Usuń pracownika",
                "Wyświetl pracownika",
                "Wyświetl stanowiska w firmie",
                "Edytuj hasło pracownika",
                "Dodaj notatki o pracownikach",
                "Wyświetl notatki o pracownikach",
                "Edytuj notatki o pracownikach"
            };
            int number = 1;
           foreach(string option in options)
            {
                Console.WriteLine($"{number++}. {option}");
            }

            Console.Write("Twój wybór:");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    new AddWorkers(conn);
                    break;
                case "2":
                    Console.Clear();
                    new ShowWorkers(conn);
                    break;
                case "3":
                    Console.Clear();
                    new DeleteWorkers(conn);
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    break;
                default:
                    Console.WriteLine("Nie ma takiej opcji!");
                    break;

            }
        }
    }
}
