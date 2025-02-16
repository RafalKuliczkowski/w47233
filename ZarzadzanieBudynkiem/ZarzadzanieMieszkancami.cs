using System;
using System.Collections.Generic;

namespace ZarzadzanieBudynkiem
{
    class ZarzadzanieMieszkancami // Klasa odpowiedzialna za zarządzanie mieszkańcami w systemie

    {
        public static void Zarzadzaj(ZarzadzanieBazaDanych dbManager) // Metoda obsługująca menu zarządzania mieszkańcami.
        {
            Console.Clear();
            Console.WriteLine("Informacje o mieszkańcach:");
            // Pobranie listy mieszkańców z bazy danych i ich wyświetlenie
            List<Uzytkownik> mieszkancy = dbManager.PobierzUzytkownikow();
            foreach (var mieszkaniec in mieszkancy)
            {
                Console.WriteLine($"{mieszkaniec.ID}. {mieszkaniec.Imie} {mieszkaniec.Nazwisko}, Email: {mieszkaniec.Email}, Rola: {mieszkaniec.Rola}");
            }
            // Wyświetlenie opcji menu
            Console.WriteLine("\n1. Dodaj użytkownika");
            Console.WriteLine("2. Usuń użytkownika");
            Console.WriteLine("3. Powrót");
            Console.Write("Wybierz opcję: ");

            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1": // Dodawanie nowego użytkownika
                    Console.Write("Podaj imię: ");
                    string imie = Console.ReadLine();
                    Console.Write("Podaj nazwisko: ");
                    string nazwisko = Console.ReadLine();
                    Console.Write("Podaj email: ");
                    string email = Console.ReadLine();
                    Console.Write("Podaj rolę: ");
                    string rola = Console.ReadLine();
                    dbManager.DodajUzytkownika(new Uzytkownik { Imie = imie, Nazwisko = nazwisko, Email = email, Rola = rola }); // Dodanie użytkownika do bazy danych
                    break;
                case "2": // Usuwanie użytkownika
                    Console.Write("Podaj ID użytkownika do usunięcia: ");
                    int idUsun = int.Parse(Console.ReadLine());
                    dbManager.UsunUzytkownika(idUsun); // Usunięcie użytkownika z bazy danych
                    break;
            }
        }
    }
}