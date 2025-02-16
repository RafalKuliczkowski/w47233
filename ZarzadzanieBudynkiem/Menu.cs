using System;

namespace ZarzadzanieBudynkiem
{
    class Menu // Klasa odpowiedzialna za wyświetlanie i obsługę menu głównego systemu zarządzania budynkiem.
    {
        private ZarzadzanieBazaDanych dbManager; 

        public Menu(ZarzadzanieBazaDanych dbManager) // Obiekt zarządzający bazą danych
        {
            this.dbManager = dbManager; 
        }

        public void WyswietlMenu() // Metoda wyświetlająca menu główne oraz obsługująca wybór użytkownika.
        {
            bool running = true; // Flaga kontrolująca działanie menu
            while (running)
            {
                // Wyczyszczenie ekranu i wyświetlenie nagłówka menu
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("    SYSTEM ZARZĄDZANIA BUDYNKIEM    ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Informacje o mieszkańcach");
                Console.WriteLine("2. Wejścia i wyjścia");
                Console.WriteLine("3. Usterki");
                Console.WriteLine("4. Wyjście");
                Console.Write("Wybierz opcję: ");

                string wybor = Console.ReadLine(); // Pobranie wyboru użytkownika
                switch (wybor) // Obsługa wyboru użytkownika
                {
                    case "1": // Zarządzanie mieszkańcami
                        ZarzadzanieMieszkancami.Zarzadzaj(dbManager);
                        break;
                    case "2": // Wyświetlanie logów wejść i wyjść
                        ZarzadzanieLogami.WyswietlLogi(dbManager);
                        break;
                    case "3": // Zarządzanie usterkami
                        ZarzadzanieUsterkami.Zarzadzaj(dbManager);
                        break;
                    case "4":  // Zakończenie działania menu
                        running = false;
                        break;
                    default: // Obsługa niepoprawnego wyboru
                        Console.WriteLine("Niepoprawny wybór. Wciśnij Enter, aby kontynuować.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}