namespace ZarzadzanieBudynkiem
{
    class Uzytkownik
    {
        public int ID { get; set; } // Unikalny identyfikator użytkownika w bazie danych
        public string Imie { get; set; } // Imię użytkownika
        public string Nazwisko { get; set; }  // Nazwisko użytkownika
        public string Email { get; set; } // Adres e-mail użytkownika (unikalny w bazie danych)
        public string Rola { get; set; } // Rola użytkownika, np. "Mieszkaniec" lub "Administrator"
    }
}