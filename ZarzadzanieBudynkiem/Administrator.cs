namespace ZarzadzanieBudynkiem
{
    class Administrator : Uzytkownik // Klasa reprezentująca administratora budynku, dziedziczy po klasie Uzytkownik
    {
        // Metoda pozwalająca administratorowi oznaczyć usterkę jako rozwiązana
        // Przyjmuje jako parametr ID usterki i wyświetla komunikat w konsoli
        public void RozwiazProblemy(int idUsterki)
        {
            Console.WriteLine("Rozwiązano usterkę o ID: " + idUsterki);
        }
    }
}