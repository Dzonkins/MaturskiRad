using Microsoft.Data.Sqlite;
using ProgramZaRacunovodstvo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgramZaRacunovodstvo
{
    internal class DatabaseKomande
    {
private readonly string _connectionString = "Data Source=baza.db";

        public bool ProveraPrijava(string email, string lozinka)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = new SqliteCommand("SELECT COUNT(*) FROM Korisnici WHERE Email = @Email AND Lozinka = @Lozinka", connection);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Lozinka", lozinka);

            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }
        public void RegistrujSe(string ime, string prezime, string jmbg, string grad, string adresa, string email, string lozinka)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var command = new SqliteCommand("INSERT INTO Korisnici (Ime, Prezime, JMBG, Grad, Adresa, Email, Lozinka) VALUES (@Ime, @Prezime, @JMBG, @Grad, @Adresa, @Email, @Lozinka)", connection);
            command.Parameters.AddWithValue("@Ime", ime);
            command.Parameters.AddWithValue("@Prezime", prezime);
            command.Parameters.AddWithValue("@JMBG", jmbg);
            command.Parameters.AddWithValue("@Grad", grad);
            command.Parameters.AddWithValue("@Adresa", adresa);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Lozinka", lozinka);
            command.ExecuteNonQuery();
        }

        public string NadjiIme(string email)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = new SqliteCommand("SELECT Ime FROM Korisnici WHERE Email = @Email", connection);
            command.Parameters.AddWithValue("@Email", email);

            string? ime = Convert.ToString(command.ExecuteScalar());
            if (ime != null) {
                return ime;
            }
            else {
                return "null";
            }
        }

        public int NadjiID(string email)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = new SqliteCommand("SELECT Id FROM Korisnici WHERE Email = @Email", connection);
            command.Parameters.AddWithValue("@Email", email);

            var result = command.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public List<string> IzvuciFirmeIzBaze(int korisnikId)
        {
            List<string> firme = new List<string>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string query = $@"
                SELECT Firme.ImeFirme 
                FROM Firme
                INNER JOIN AdministratoriFirme ON Firme.Id = AdministratoriFirme.FirmaId
                WHERE AdministratoriFirme.KorisnikId = {korisnikId}";

            var command = new SqliteCommand(query, connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                firme.Add(reader.GetString(0));
            }
            return firme;
        }

        public void DodajFirmu(string imeFirme, string pib, string maticniBroj, string adresa, string grad, string brojRacuna, string zastupnik, int korisnikId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = "INSERT INTO Firme (ImeFirme, PIB, MaticniBroj, Adresa, Grad, BrojRacuna, Zastupnik) VALUES (@ImeFirme, @PIB, @MaticniBroj, @Adresa, @Grad, @BrojRacuna, @Zastupnik)";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ImeFirme", imeFirme);
                command.Parameters.AddWithValue("@PIB", pib);
                command.Parameters.AddWithValue("@MaticniBroj", maticniBroj);
                command.Parameters.AddWithValue("@Adresa", adresa);
                command.Parameters.AddWithValue("@Grad", grad);
                command.Parameters.AddWithValue("@BrojRacuna", brojRacuna);
                command.Parameters.AddWithValue("@Zastupnik", zastupnik);
                command.ExecuteNonQuery();
            }

            long firmaId;
            using (var idCommand = new SqliteCommand("SELECT last_insert_rowid();", connection))
            {
                object? result = idCommand.ExecuteScalar();
                firmaId = result != null ? Convert.ToInt64(result) : throw new Exception("Failed to retrieve last inserted ID.");
            }

            string query2 = "INSERT INTO AdministratoriFirme (KorisnikId, FirmaId) VALUES (@KorisnikId, @FirmaId)";
            using (var command2 = new SqliteCommand(query2, connection))
            {
                command2.Parameters.AddWithValue("@KorisnikId", korisnikId);
                command2.Parameters.AddWithValue("@FirmaId", firmaId);
                command2.ExecuteNonQuery();
            }
        }

        public int FirmaID(string Imefirme)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = new SqliteCommand("SELECT Id FROM Firme WHERE ImeFirme = @ImeFirme", connection);
            command.Parameters.AddWithValue("@ImeFirme", Imefirme);

            var result = command.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public void DodajPravnoLice(string Naziv, string PIB, string MaticniBroj, string Grad, string Adresa, string BrojRacuna, string Zastupnik, int FirmaId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = "INSERT INTO PravnaLica (FirmaId, Naziv, PIB, MaticniBroj, Grad, Adresa, BrojRacuna, Zastupnik) VALUES (@FirmaId, @Naziv, @PIB, @MaticniBroj, @Grad, @Adresa, @BrojRacuna, @Zastupnik)";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirmaId", FirmaId);
                command.Parameters.AddWithValue("@Naziv", Naziv);
                command.Parameters.AddWithValue("@PIB", PIB);
                command.Parameters.AddWithValue("@MaticniBroj", MaticniBroj);
                command.Parameters.AddWithValue("@Adresa", Adresa);
                command.Parameters.AddWithValue("@Grad", Grad);
                command.Parameters.AddWithValue("@BrojRacuna", BrojRacuna);
                command.Parameters.AddWithValue("@Zastupnik", Zastupnik);
                command.ExecuteNonQuery();
            }
        }

        public List<PravnaLica> IzvuciPravnaLica(int firmaId)
        {
            List<PravnaLica> PravnaLica = new List<PravnaLica>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string query = @"SELECT Id, Naziv, PIB, MaticniBroj, Grad, Adresa, brojRacuna, Zastupnik FROM PravnaLica WHERE FirmaId = @FirmaId";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@FirmaId", firmaId);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                PravnaLica.Add(new PravnaLica {
                    Id = reader.GetInt32("Id"),
                    Naziv = reader.GetString(1),
                    PIB = reader.GetString(2),
                    Maticnibroj = reader.GetString(3),
                    Grad = reader.GetString(4),
                    Adresa = reader.GetString(5),
                    Racun = reader.GetString(6),
                    Zastupnik = reader.GetString(7)
                });
            }
            return PravnaLica;
        }

        public void IzbrisiPravnoLice(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = "DELETE FROM PravnaLica WHERE Id = @Id";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
