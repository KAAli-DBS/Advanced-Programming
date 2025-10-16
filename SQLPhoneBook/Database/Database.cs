using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using PhoneBook_BS;

namespace PhoneBook_BS.Database
{
    public static class Database
    {
        private const string DbFile = "phonebook.db";

        public static void Initialize()
        {
            using var connection = new SqliteConnection($"Data Source={DbFile}");
            connection.Open();

            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Contacts (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                PhoneNumber TEXT NOT NULL
            )";
            tableCmd.ExecuteNonQuery();
        }

        public static List<Contact> GetAllContacts()
        {
            var contacts = new List<Contact>();

            using var connection = new SqliteConnection($"Data Source={DbFile}");
            connection.Open();

            var selectCmd = connection.CreateCommand();
            selectCmd.CommandText = "SELECT Name, PhoneNumber FROM Contacts";

            using var reader = selectCmd.ExecuteReader();
            while (reader.Read())
            {
                contacts.Add(new Contact(reader.GetString(0), reader.GetString(1)));
            }

            return contacts;
        }

        public static void AddContact(Contact contact)
        {
            using var connection = new SqliteConnection($"Data Source={DbFile}");
            connection.Open();

            var insertCmd = connection.CreateCommand();
            insertCmd.CommandText = "INSERT INTO Contacts (Name, PhoneNumber) VALUES ($name, $phone)";
            insertCmd.Parameters.AddWithValue("$name", contact.Name);
            insertCmd.Parameters.AddWithValue("$phone", contact.PhoneNumber);
            insertCmd.ExecuteNonQuery();
        }
    }
}