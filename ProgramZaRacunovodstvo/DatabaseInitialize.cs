using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProgramZaRacunovodstvo
{
    public class DatabaseInitialize
    {
        private readonly string _databasePath = "baza.db";

        private readonly Dictionary<string, string> _tableSchemas = new()
        {
            { "Korisnici", @"CREATE TABLE IF NOT EXISTS `Korisnici` (
                                `Id` INTEGER PRIMARY KEY,
                                `Ime` TEXT,
                                `Prezime` TEXT,
                                `JMBG` TEXT,
                                `Grad` TEXT,
                                `Adresa` TEXT,
                                `Email` TEXT,
                                `Lozinka` TEXT
                            );" },
            {"Firme", @"CREATE TABLE IF NOT EXISTS `Firme`(
                                `Id` INTEGER PRIMARY KEY,
                                `ImeFirme` TEXT,
                                `PIB` TEXT,
                                `MaticniBroj` TEXT,
                                `Adresa`TEXT,
                                `Grad` TEXT,
                                `BrojRacuna` TEXT,
                                `Zastupnik` TEXT
                            );"},
            {"AdministratoriFirme", @"CREATE TABLE IF NOT EXISTS `AdministratoriFirme`(
                                `Id` INTEGER PRIMARY KEY ,
                                `KorisnikId` INTEGER,
                                `FirmaId` INTEGER

                            );"},
        };

        public void InitializeDatabase()
        {

            if (!File.Exists(_databasePath))
            {
                using (var connection = new SqliteConnection($"Data Source={_databasePath}"))
                {
                    connection.Open();
                    Console.WriteLine($"Database created at {_databasePath}.");
                }
            }
            else
            {
                Console.WriteLine($"Database already exists at {_databasePath}.");
            }

            CreateTables();
        }

        private void CreateTables()
        {
            using var connection = new SqliteConnection($"Data Source={_databasePath}");
            connection.Open();

            foreach (var table in _tableSchemas)
            {
                string tableName = table.Key;
                string createTableSql = table.Value;

                using (var checkTableCommand = new SqliteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'", connection))
                {
                    var result = checkTableCommand.ExecuteScalar();
                    if (result == null)
                    {
                        using var command = new SqliteCommand(createTableSql, connection);
                        command.ExecuteNonQuery();
                        Console.WriteLine($"Table {tableName} created.");
                    }
                    else
                    {
                        Console.WriteLine($"Table {tableName} already exists.");
                    }
                }
            }
        }

    }
}
