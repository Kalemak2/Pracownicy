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
        /*******************************************************  
         * nazwa klasy:          Menu
         * parametry wejściowe:  conn - połączenie z bazą danych
         * opis:                 Klasa wyświetla menu główne z opcjami do wyboru.
         * autor:                Kornel Pakulski
         * ******************************************************/

        public Menu(MySqlConnection conn) {
            Console.WriteLine("Witaj w aplikacji do zarządzania pracownikami!");

            string[] options = {
                "Dodaj nowego pracownika",
                "Wyświetl pracowników",
                "Usuń pracownika",
                "Wyświetl szczegółowe informacje o pracowniku",
                "Wyświetl stanowiska w firmie",
                "Edytuj hasło pracownika",
                "Dodaj notatki o pracownikach",
                "Wyświetl notatki o pracownikach",
                "Usuń notatki o pracownikach"
            };
            int number = 1;
           foreach(string option in options)
            {
                Console.WriteLine($"{number++}. {option}");
            }

            Console.Write("Twój wybór: ");
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
                    Console.Clear();
                    new ShowWorkerInfo(conn);
                    break;
                case "5":
                    Console.Clear();
                    new ShowPosition(conn);
                    break;
                case "6":
                    Console.Clear();
                    new ChangePassword(conn);
                    break;
                case "7":
                    Console.Clear();
                    new AddNote(conn);
                    break;
                case "8":
                    Console.Clear();
                    new ShowNotes(conn);
                    break;
                case "9":
                    Console.Clear();
                    new DeleteNotes(conn);
                    break;
                default:
                    Console.WriteLine("Nie ma takiej opcji!");
                    break;

            }
        }
    }
}
