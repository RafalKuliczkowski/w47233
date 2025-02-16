using System;
using System.Collections.Generic;

namespace ZarzadzanieBudynkiem
{
    class ZarzadzanieUsterkami  // Klasa odpowiedzialna za zarządzanie usterkami w systemie.
    {
        public static void Zarzadzaj(ZarzadzanieBazaDanych dbManager) // Metoda obsługująca menu zarządzania usterkami.
        {
            Console.Clear();
            Console.WriteLine("Lista usterek:");
            List<string> usterki = dbManager.PobierzUsterki(); // Pobranie listy usterek z bazy danych i ich wyświetlenie
            foreach (var usterka in usterki)
            {
                Console.WriteLine(usterka);
            }
            // Wyświetlenie opcji menu
            Console.WriteLine("\n1. Dodaj wpis");
            Console.WriteLine("2. Usuń wpis");
            Console.WriteLine("3. Zmień status");
            Console.WriteLine("4. Powrót");
            Console.Write("Wybierz opcję: ");

            string wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1": // Dodawanie nowej usterki
                    string data;
                    while (true)
                    {
                        Console.Write("Podaj datę zgłoszenia (YYYY-MM-DD): ");
                        data = Console.ReadLine();
                        if (DateTime.TryParse(data, out _)) // Sprawdzanie poprawności daty
                            break;
                        Console.WriteLine("Niepoprawny format daty. Spróbuj ponownie.");
                    }

                    Console.Write("Podaj opis usterki: ");
                    string opis = Console.ReadLine();
                    // Wybór statusu usterki
                    Console.WriteLine("Wybierz status usterki: ");
                    Console.WriteLine("1. Oczekujące");
                    Console.WriteLine("2. W trakcie");
                    Console.WriteLine("3. Naprawione");
                    string status = Console.ReadLine() switch
                    {
                        "1" => "Oczekujące",
                        "2" => "W trakcie",
                        "3" => "Naprawione",
                        _ => "Oczekujące"
                    };

                    // Dodanie usterki do bazy danych
                    dbManager.DodajUsterke(data, opis, status);
                    break;
                case "2": // Usuwanie usterki
                    int idUsterki;
                    while (true)
                    {
                        Console.Write("Podaj ID usterki do usunięcia: ");
                        if (int.TryParse(Console.ReadLine(), out idUsterki)) // Sprawdzanie poprawności ID
                            break;
                        Console.WriteLine("Niepoprawne ID. Wprowadź liczbę.");
                    }
                    // Usunięcie usterki z bazy danych
                    dbManager.UsunUsterke(idUsterki);
                    break;
                case "3": // Zmiana statusu usterki
                    int idZmiany;
                    while (true)
                    {
                        Console.Write("Podaj ID usterki do zmiany statusu: ");
                        if (int.TryParse(Console.ReadLine(), out idZmiany)) // Sprawdzanie poprawności ID
                            break;
                        Console.WriteLine("Niepoprawne ID. Wprowadź liczbę.");
                    }
                    // Wybór nowego statusu dla usterki
                    Console.WriteLine("Wybierz nowy status usterki: ");
                    Console.WriteLine("1. Oczekujące");
                    Console.WriteLine("2. W trakcie");
                    Console.WriteLine("3. Naprawione");
                    string nowyStatus = Console.ReadLine() switch
                    {
                        "1" => "Oczekujące",
                        "2" => "W trakcie",
                        "3" => "Naprawione",
                        _ => "Oczekujące"
                    };
                    // Aktualizacja statusu usterki w bazie danych
                    dbManager.ZmienStatusUsterki(idZmiany, nowyStatus); 
                    break;
                case "4": // Powrót do menu głównego
                    return;
                default:
                    Console.WriteLine("Niepoprawny wybór. Wciśnij Enter, aby kontynuować.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}