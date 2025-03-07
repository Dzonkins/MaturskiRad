using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

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
    }
}
