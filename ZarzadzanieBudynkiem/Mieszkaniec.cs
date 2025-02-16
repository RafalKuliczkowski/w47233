namespace ZarzadzanieBudynkiem
{
    class Mieszkaniec : Uzytkownik // Klasa reprezentująca mieszkańca budynku, dziedziczy po klasie Uzytkownik
    {
        // Metoda pozwalająca mieszkańcowi zgłosić usterkę w budynku
        // Przyjmuje jako parametr opis usterki i wyświetla komunikat w konsoli
        public void ZglosUsterke(string opis)
        {
            Console.WriteLine("Zgłoszono usterkę: " + opis);
        }
    }
}