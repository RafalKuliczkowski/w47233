using System;
using System.Collections.Generic;

namespace ZarzadzanieBudynkiem
{
    class ZarzadzanieLogami // Klasa odpowiedzialna za zarządzanie logami wejść i wyjść z budynku.
    {
        public static void WyswietlLogi(ZarzadzanieBazaDanych dbManager) // Metoda wyświetlająca historię wejść i wyjść użytkowników.
        {
            Console.Clear();
            Console.WriteLine("Historia wejść i wyjść:");
            List<string> logi = dbManager.PobierzLogi(); // Pobranie logów z bazy danych i ich wyświetlenie
            foreach (var log in logi)
            {
                Console.WriteLine(log);
            }
            Console.WriteLine("Wciśnij Enter, aby powrócić do menu..."); // Oczekiwanie na wciśnięcie klawisza Enter, aby powrócić do menu
            Console.ReadLine();
        }
    }
}