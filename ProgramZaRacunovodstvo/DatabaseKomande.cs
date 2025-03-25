﻿using LiveChartsCore.Themes;
using Microsoft.Data.Sqlite;
using ProgramZaRacunovodstvo.Models;
using ProgramZaRacunovodstvo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgramZaRacunovodstvo
{
    internal class DatabaseKomande
    {
        private readonly string _connectionString = "Data Source=baza.db";
        private static readonly CultureInfo culture = new("sr-Latn-RS");


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

        public bool RegistracijaProvera(string email)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var check = new SqliteCommand("SELECT COUNT(*) FROM Korisnici WHERE Email = @Email", connection);
            check.Parameters.AddWithValue("@Email", email);
            long count = (check.ExecuteScalar() as long?) ?? 0;

            return count > 0;
        }

        public bool RegistracijaJMBG(string jmbg)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var check = new SqliteCommand("SELECT COUNT(*) FROM Korisnici WHERE JMBG = @JMBG", connection);
            check.Parameters.AddWithValue("@JMBG", jmbg);
            long count = (check.ExecuteScalar() as long?) ?? 0;

            return count > 0;
        }

        public string NadjiIme(string email)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = new SqliteCommand("SELECT Ime FROM Korisnici WHERE Email = @Email", connection);
            command.Parameters.AddWithValue("@Email", email);

            string? ime = Convert.ToString(command.ExecuteScalar());
            if (ime != null)
            {
                return ime;
            }
            else
            {
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

        public bool DodajFirmuProvera(string imeFirme)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var check = new SqliteCommand("SELECT COUNT(*) FROM Firme WHERE ImeFirme = @ImeFirme", connection);
            check.Parameters.AddWithValue("@ImeFirme", imeFirme);
            long count = (check.ExecuteScalar() as long?) ?? 0;

            return count > 0;
        }
        public bool PIBProvera(string pib)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var check = new SqliteCommand("SELECT COUNT(*) FROM Firme WHERE PIB = @PIB", connection);
            check.Parameters.AddWithValue("@PIB", pib);
            long count = (check.ExecuteScalar() as long?) ?? 0;

            return count > 0;
        }
        public bool MaticniBrojProvera(string maticniBroj)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var check = new SqliteCommand("SELECT COUNT(*) FROM Firme WHERE MaticniBroj = @MaticniBroj", connection);
            check.Parameters.AddWithValue("@MaticniBroj", maticniBroj);
            long count = (check.ExecuteScalar() as long?) ?? 0;

            return count > 0;
        }

        public bool BrojRacunaProvera(string brojRacuna)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var check = new SqliteCommand("SELECT COUNT(*) FROM Firme WHERE BrojRacuna = @BrojRacuna", connection);
            check.Parameters.AddWithValue("@BrojRacuna", brojRacuna);
            long count = (check.ExecuteScalar() as long?) ?? 0;

            return count > 0;
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

        public bool PravnoLiceProvera(string naziv, int firmaId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var check = new SqliteCommand("SELECT COUNT(*) FROM PravnaLica WHERE Naziv = @Naziv AND FirmaId = @FirmaId", connection);
            check.Parameters.AddWithValue("@Naziv", naziv);
            check.Parameters.AddWithValue("@FirmaId", firmaId);
            long count = (check.ExecuteScalar() as long?) ?? 0;

            return count > 0;
        }
        public bool PravnoLicePIB(string pib, int firmaId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var check = new SqliteCommand("SELECT COUNT(*) FROM PravnaLica WHERE PIB = @Pib AND FirmaId = @FirmaId", connection);
            check.Parameters.AddWithValue("@Pib", pib);
            check.Parameters.AddWithValue("@FirmaId", firmaId);
            long count = (check.ExecuteScalar() as long?) ?? 0;

            return count > 0;
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
                PravnaLica.Add(new PravnaLica
                {
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

        public List<string> PodaciOPravnomLicu(int PravnoLiceId)
        {
            List<string> Podaci = new List<string>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string query = @"SELECT Naziv, PIB, MaticniBroj, Grad, Adresa, BrojRacuna, Zastupnik FROM PravnaLica WHERE Id = @Id";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Id", PravnoLiceId);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Podaci.Add(reader.GetString(i));
                }
            }
            return Podaci;
        }

        public void IzmeniPravnoLice(string Naziv, string PIB, string MaticniBroj, string Grad, string Adresa, string BrojRacuna, string Zastupnik, int PravnoLiceId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = @"UPDATE PravnaLica 
                     SET Naziv = @Naziv, PIB = @PIB, MaticniBroj = @MaticniBroj, Grad = @Grad, 
                         Adresa = @Adresa, BrojRacuna = @BrojRacuna, Zastupnik = @Zastupnik
                     WHERE Id = @Id";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", PravnoLiceId);
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

        public List<string> ImenaPravnihLica(int FirmaId)
        {
            List<string> pravnaLica = new List<string>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = "SELECT Naziv FROM PravnaLica WHERE FirmaId = @FirmaId";

            using (var command = new SqliteCommand(query, connection))
            {

                command.Parameters.AddWithValue("@FirmaId", FirmaId);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pravnaLica.Add(reader.GetString(0));
                }
            }


            return pravnaLica;
        }

        public List<string> PodaciOFirmi(int id)
        {
            List<string> Firma = new List<string>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = "SELECT ImeFirme, PIB, MaticniBroj, Adresa, Grad, BrojRacuna FROM Firme WHERE Id = @Id";

            using (var command = new SqliteCommand(query, connection))
            {

                command.Parameters.AddWithValue("@Id", id);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Firma.Add(reader.GetString(i));
                    }
                }
            }


            return Firma;
        }

        public List<string> PodaciPravnoLice(string ime)
        {
            List<string> Podaci = new List<string>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            string query = @"SELECT PIB, MaticniBroj, Grad, Adresa, BrojRacuna FROM PravnaLica WHERE Naziv = @ime";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@ime", ime);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Podaci.Add(reader.GetString(i));
                }
            }

            return Podaci;
        }

        public void KreirajFakturu(string tipFakture, string statusFakture, string dobavljac, string kupac, ObservableCollection<Stavka> Stavke, ObservableCollection<Dokument> Dokumenti, int firmaId, string brojFakture, decimal osnovica, decimal pdv, decimal ukupno, DateTime datum, byte[] fajl)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = "INSERT INTO Fakture (TipFakture, StatusFakture, BrojFakture, Dobavljac, Kupac, Osnovica, PDV, Ukupno, Datum, FirmaId, Fajl) VALUES (@TipFakture, @StatusFakture, @BrojFakture, @Dobavljac, @Kupac, @Osnovica, @PDV, @Ukupno, @Datum, @FirmaId, @Fajl)";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TipFakture", tipFakture);
                command.Parameters.AddWithValue("@StatusFakture", statusFakture);
                command.Parameters.AddWithValue("@BrojFakture", brojFakture);
                command.Parameters.AddWithValue("@Dobavljac", dobavljac);
                command.Parameters.AddWithValue("@Kupac", kupac);
                command.Parameters.AddWithValue("@Osnovica", osnovica);
                command.Parameters.AddWithValue("@PDV", pdv);
                command.Parameters.AddWithValue("@Ukupno", ukupno);
                command.Parameters.AddWithValue("@Datum", datum);
                command.Parameters.AddWithValue("@FirmaId", firmaId);
                command.Parameters.AddWithValue("@Fajl", SqliteType.Blob).Value = fajl;
                command.ExecuteNonQuery();
            }

            long fakturaId;
            using (var idCommand = new SqliteCommand("SELECT last_insert_rowid();", connection))
            {
                object? result = idCommand.ExecuteScalar();
                fakturaId = result != null ? Convert.ToInt64(result) : throw new Exception("Failed to retrieve last inserted ID.");
            }

            string stavkaQuery = @"
        INSERT INTO ElementiFakture (FakturaId, Sifra, Naziv, Kolicina, Cena, Osnovica, PDVPosto, PDV, Ukupno)
        VALUES (@FakturaId, @Sifra, @Naziv, @Kolicina, @Cena, @Osnovica, @PDVPosto, @PDV, @Ukupno)";

            using (var stavkaCommand = new SqliteCommand(stavkaQuery, connection))
            {
                foreach (var stavka in Stavke)
                {
                    stavkaCommand.Parameters.Clear();
                    stavkaCommand.Parameters.AddWithValue("@FakturaId", fakturaId);
                    stavkaCommand.Parameters.AddWithValue("@Sifra", stavka.sifra);
                    stavkaCommand.Parameters.AddWithValue("@Naziv", stavka.naziv);
                    stavkaCommand.Parameters.AddWithValue("@Kolicina", stavka.kolicina);
                    stavkaCommand.Parameters.AddWithValue("@Cena", stavka.cena);
                    stavkaCommand.Parameters.AddWithValue("@Osnovica", stavka.osnovica);
                    stavkaCommand.Parameters.AddWithValue("@PDVPosto", stavka.PDVPosto);
                    stavkaCommand.Parameters.AddWithValue("@PDV", stavka.PDV);
                    stavkaCommand.Parameters.AddWithValue("@Ukupno", stavka.Ukupno);
                    stavkaCommand.ExecuteNonQuery();
                }
            }



            string fajlQuery = "INSERT INTO FajloviFaktura (FakturaId, NazivFajla, Fajl) VALUES (@FakturaId, @NazivFajla, @Fajl)";
            using (var fajlCommand = new SqliteCommand(fajlQuery, connection))
            {
                foreach (var dokument in Dokumenti)
                {
                    fajlCommand.Parameters.Clear();
                    fajlCommand.Parameters.AddWithValue("@FakturaId", fakturaId);
                    fajlCommand.Parameters.AddWithValue("@NazivFajla", dokument.imeFajla);
                    fajlCommand.Parameters.AddWithValue("@Fajl", SqliteType.Blob).Value = dokument.fajl;

                    fajlCommand.ExecuteNonQuery();
                }
            }
        }

        public void IzbrisiFakturu(int fakturaid)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = "DELETE FROM Fakture WHERE Id = @Id";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", fakturaid);
                command.ExecuteNonQuery();
            }

            string query2 = @"DELETE FROM ElementiFakture WHERE FakturaId = @FakturaId";
            using (var command = new SqliteCommand(query2, connection))
            {
                command.Parameters.AddWithValue("@FakturaId", fakturaid);
                command.ExecuteNonQuery();
            }




            string query3 = "DELETE FROM FajloviFaktura WHERE FakturaId = @FakturaId";
            using (var command = new SqliteCommand(query3, connection))
            {
                command.Parameters.AddWithValue("@FakturaId", fakturaid);
                command.ExecuteNonQuery();
            }

        }

        public List<Nabavka> IzvuciNabavke(int firmaid, string tipFakture)
        {
            List<Nabavka> Nabavke = new List<Nabavka>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = @"SELECT Id, BrojFakture, StatusFakture, Dobavljac, Osnovica, PDV, Ukupno, Datum FROM Fakture WHERE FirmaId = @FirmaId AND TipFakture = @TipFakture";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@FirmaId", firmaid);
            command.Parameters.AddWithValue("@TipFakture", tipFakture);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Nabavke.Add(new Nabavka
                {
                    Id = reader.GetInt32("Id"),
                    BrojFakture = reader.GetString(1),
                    Status = reader.GetString(2),
                    Dobavljac = reader.GetString(3),
                    Osnovica = reader.GetDecimal(4),
                    Pdv = reader.GetDecimal(5),
                    Ukupno = reader.GetDecimal(6),
                    DatumSlanja = DateOnly.FromDateTime(reader.GetDateTime(7))
                });
            }

            return Nabavke;
        }

        public List<Prodaja> IzvuciProdaje(int firmaid, string tipFakture)
        {
            List<Prodaja> Prodaja = new List<Prodaja>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = @"SELECT Id, BrojFakture, StatusFakture, Kupac, Osnovica, PDV, Ukupno, Datum FROM Fakture WHERE FirmaId = @FirmaId AND TipFakture = @TipFakture";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@FirmaId", firmaid);
            command.Parameters.AddWithValue("@TipFakture", tipFakture);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Prodaja.Add(new Prodaja
                {
                    Id = reader.GetInt32("Id"),
                    BrojFakture = reader.GetString(1),
                    Status = reader.GetString(2),
                    Kupac = reader.GetString(3),
                    Osnovica = reader.GetDecimal(4),
                    Pdv = reader.GetDecimal(5),
                    Ukupno = reader.GetDecimal(6),
                    DatumSlanja = DateOnly.FromDateTime(reader.GetDateTime(7))
                });
            }

            return Prodaja;
        }

        public List<Izvod> Izvodi(int firmaid)
        {
            List<Izvod> Izvodi = new List<Izvod>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = @"SELECT Id, BrojFakture, TipFakture, StatusFakture, Kupac, Osnovica, PDV, Ukupno, Datum FROM Fakture WHERE FirmaId = @FirmaId";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@FirmaId", firmaid);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Izvodi.Add(new Izvod
                {
                    Id = reader.GetInt32("Id"),
                    BrojFakture = reader.GetString(1),
                    TipFakture = reader.GetString(2),
                    Status = reader.GetString(3),
                    PravnoLice = reader.GetString(4),
                    Osnovica = reader.GetDecimal(5),
                    Pdv = reader.GetDecimal(6),
                    Ukupno = reader.GetDecimal(7),
                    DatumSlanja = DateOnly.FromDateTime(reader.GetDateTime(8))
                });
            }

            return Izvodi;
        }
        public DetaljiFakture PodaciOFakturi(int fakturaId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = @"SELECT Brojfakture, TipFakture, StatusFakture, Ukupno, Dobavljac, Kupac, Datum, Fajl 
                     FROM Fakture WHERE Id = @Id";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@Id", fakturaId);

            using var reader = command.ExecuteReader();

            if (!reader.Read()) return null!;

            var faktura = new DetaljiFakture
            {
                BrojFakture = reader["Brojfakture"] as string ?? string.Empty,
                TipFakture = reader["TipFakture"] as string ?? string.Empty,
                StatusFakture = reader["StatusFakture"] as string ?? string.Empty,
                Ukupno = reader.IsDBNull(reader.GetOrdinal("Ukupno")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Ukupno")),
                Dobavljac = reader["Dobavljac"] as string ?? string.Empty,
                Kupac = reader["Kupac"] as string ?? string.Empty,
                Datum = reader.IsDBNull(reader.GetOrdinal("Datum")) ? null : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("Datum"))),
                Fajl = reader["Fajl"] as byte[]
            };

            faktura.Fajlovi = LoadFajlovi(fakturaId);

            return faktura;
        }

        private List<FajlFakture> LoadFajlovi(int fakturaId)
        {
            var fajlovi = new List<FajlFakture>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = "SELECT Id, FakturaId, NazivFajla, Fajl FROM FajloviFaktura WHERE FakturaId = @FakturaId";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@FakturaId", fakturaId);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Debug.WriteLine(reader.GetString(2));
                fajlovi.Add(new FajlFakture
                {
                    Id = reader.GetInt32(0),
                    FakturaId = reader.GetInt32(1),
                    NazivFajla = reader.GetString(2),
                    Fajl = (byte[])reader["Fajl"]
                });
            }

            return fajlovi;
        }

        public void AzurirajStatus(int fakturaId, string statusFakture)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = "UPDATE Fakture SET StatusFakture = @StatusFakture WHERE Id = @Id";
            using (var command = new SqliteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", fakturaId);
                command.Parameters.AddWithValue("@StatusFakture", statusFakture);
                command.ExecuteNonQuery();
            }
        }

        public int BrojUlaznihFaktura(int firmaId)
        {
            int count = 0;
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = "SELECT COUNT(*) FROM Fakture WHERE strftime('%Y-%m', Datum) = strftime('%Y-%m', 'now') AND FirmaId = @firmaId AND TipFakture = 'Nabavka'";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@firmaId", firmaId);

            count = Convert.ToInt32(command.ExecuteScalar());

            return count;
        }

        public int BrojIzlaznihFaktura(int firmaId)
        {
            int count = 0;
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = "SELECT COUNT(*) FROM Fakture WHERE strftime('%Y-%m', Datum) = strftime('%Y-%m', 'now') AND FirmaId = @firmaId AND TipFakture = 'Prodaja'";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@firmaId", firmaId);

            count = Convert.ToInt32(command.ExecuteScalar());

            return count;
        }

        public decimal Prihodi(int firmaId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = "SELECT SUM(Ukupno) FROM Fakture WHERE strftime('%Y-%m', Datum) = strftime('%Y-%m', 'now') AND StatusFakture = 'Plaćeno' AND TipFakture = 'Prodaja' AND FirmaId = @FirmaId";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@FirmaId", firmaId);
            var result = command.ExecuteScalar();
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
        }

        public decimal Rashodi(int firmaId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = "SELECT SUM(Ukupno) FROM Fakture WHERE strftime('%Y-%m', Datum) = strftime('%Y-%m', 'now') AND StatusFakture = 'Plaćeno' AND TipFakture = 'Nabavka' AND FirmaId = @FirmaId";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@FirmaId", firmaId);
            var result = command.ExecuteScalar();
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
        }

        public List<(string Klijent, decimal Ukupno)> Top10Klijenti(int firmaId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = @"
        SELECT Kupac, SUM(Ukupno) as Ukupno
        FROM Fakture
        WHERE strftime('%Y-%m', Datum) = strftime('%Y-%m', 'now') 
              AND StatusFakture = 'Plaćeno' 
              AND TipFakture = 'Prodaja' 
              AND FirmaId = @FirmaId
        GROUP BY Kupac
        ORDER BY Ukupno DESC
        LIMIT 10";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@FirmaId", firmaId);

            using var reader = command.ExecuteReader();

            var topKlijenti = new List<(string Klijent, decimal Ukupno)>();
            while (reader.Read())
            {
                string klijent = reader.GetString(0);
                decimal ukupno = reader.GetDecimal(1);
                topKlijenti.Add((klijent, ukupno));
            }

            return topKlijenti;
        }

        public List<(string Dobavljac, decimal Ukupno)> Top10Dobavljaci(int firmaId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = @"
        SELECT Dobavljac, SUM(Ukupno) as Ukupno
        FROM Fakture
        WHERE strftime('%Y-%m', Datum) = strftime('%Y-%m', 'now') 
              AND StatusFakture = 'Plaćeno' 
              AND TipFakture = 'Nabavka' 
              AND FirmaId = @FirmaId
        GROUP BY Dobavljac
        ORDER BY Ukupno DESC
        LIMIT 10";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@FirmaId", firmaId);

            using var reader = command.ExecuteReader();

            var topDobavljaci = new List<(string Dobavljac, decimal Ukupno)>();
            while (reader.Read())
            {
                string dobavljac = reader.GetString(0);
                decimal ukupno = reader.GetDecimal(1);
                topDobavljaci.Add((dobavljac, ukupno));
            }

            return topDobavljaci;
        }

        public (List<decimal> prihodi, List<decimal> rashodi, string[] months) PrihodiRashodi(int firmaId)
        {
            List<decimal> prihodi = new List<decimal>();
            List<decimal> rashodi = new List<decimal>();
            List<string> months = new List<string>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string query = @"
            SELECT strftime('%Y-%m', Datum) AS Mesec,
                   SUM(CASE WHEN TipFakture = 'Prodaja' AND StatusFakture = 'Plaćeno' THEN Ukupno ELSE 0 END) AS Prihodi,
                   SUM(CASE WHEN TipFakture = 'Nabavka' AND StatusFakture = 'Plaćeno' THEN Ukupno ELSE 0 END) AS Rashodi
            FROM Fakture
            WHERE Datum >= date('now', '-12 months')
            AND FirmaId = @firmaId
            GROUP BY Mesec
            ORDER BY Mesec;";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@firmaId", firmaId);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                DateTime date = DateTime.ParseExact(reader.GetString(0), "yyyy-MM", culture);
                months.Add(date.ToString("MMMM yyyy", culture));
                prihodi.Add(reader.IsDBNull(1) ? 0 : reader.GetInt32(1));
                rashodi.Add(reader.IsDBNull(2) ? 0 : reader.GetInt32(2));
            }

            return (prihodi, rashodi, months.ToArray());
        }
    }
}
