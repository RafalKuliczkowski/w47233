using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ZarzadzanieBudynkiem
{
    class ZarzadzanieBazaDanych // Klasa do zarządzania połączeniem z bazą danych i operacjami na niej
    {
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=ZarzadzanieBudynkiem;Integrated Security=True;";
        // Ciąg połączeniowy do bazy danych SQL Server


        public void DodajUzytkownika(Uzytkownik uzytkownik) // Dodaje nowego użytkownika do bazy danych
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Uzytkownicy (Imie, Nazwisko, Email, Rola) VALUES (@Imie, @Nazwisko, @Email, @Rola)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Imie", uzytkownik.Imie);
                    command.Parameters.AddWithValue("@Nazwisko", uzytkownik.Nazwisko);
                    command.Parameters.AddWithValue("@Email", uzytkownik.Email);
                    command.Parameters.AddWithValue("@Rola", uzytkownik.Rola);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Uzytkownik> PobierzUzytkownikow() // Pobiera listę wszystkich użytkowników z bazy danych
        {
            List<Uzytkownik> uzytkownicy = new List<Uzytkownik>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Uzytkownicy";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        uzytkownicy.Add(new Uzytkownik
                        {
                            ID = reader.GetInt32(0),
                            Imie = reader.GetString(1),
                            Nazwisko = reader.GetString(2),
                            Email = reader.GetString(3),
                            Rola = reader.GetString(4)
                        });
                    }
                }
            }
            return uzytkownicy;
        }
        public void UsunUzytkownika(int id) // Usuwa użytkownika na podstawie ID
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Uzytkownicy WHERE ID_Uzytkownika = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<string> PobierzLogi()  // Pobiera historię wejść i wyjść mieszkańców
        {
            List<string> logi = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Uzytkownicy.Imie, Uzytkownicy.Nazwisko, Logi.Czas_Wejscia, Logi.Czas_Wyjscia " +
                               "FROM Logi INNER JOIN Uzytkownicy ON Logi.ID_Uzytkownika = Uzytkownicy.ID_Uzytkownika";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string log = $"{reader.GetString(0)} {reader.GetString(1)} - Wejście: {reader.GetDateTime(2)}";
                        if (!reader.IsDBNull(3))
                            log += $", Wyjście: {reader.GetDateTime(3)}";
                        logi.Add(log);
                    }
                }
            }
            return logi;
        }
        public List<string> PobierzUsterki() // Pobiera listę zgłoszonych usterek
        {
            List<string> usterki = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID_Usterki, Opis, Data_Zgloszenia, Status FROM Usterki";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string usterka = $"ID: {reader.GetInt32(0)}, Opis: {reader.GetString(1)}, " +
                                         $"Data: {reader.GetDateTime(2)}, Status: {reader.GetString(3)}";
                        usterki.Add(usterka);
                    }
                }
            }
            return usterki;
        }
        public void DodajUsterke(string data, string opis, string status) // Dodaje nową usterkę do bazy danych
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Usterki (Opis, Data_Zgloszenia, Status) VALUES (@Opis, @Data, @Status)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Opis", opis);
                    command.Parameters.AddWithValue("@Data", DateTime.Parse(data));
                    command.Parameters.AddWithValue("@Status", status);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UsunUsterke(int id) // Usuwa usterkę na podstawie ID
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Usterki WHERE ID_Usterki = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ZmienStatusUsterki(int idUsterki, string nowyStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Usterki SET Status = @Status WHERE ID_Usterki = @ID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", nowyStatus);
                    command.Parameters.AddWithValue("@ID", idUsterki);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
