using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Personal_Finance_Tracker.Modeli;

namespace Personal_Finance_Tracker.Baza
{
    class DatabaseManager
    {
        private static DatabaseManager instance;
        private readonly string putanjaDoBaze = "Data Source=finance.db";

        private DatabaseManager()
        {

        }

        public static DatabaseManager GetInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseManager();
            }
            return instance;
        }

        public void InitializeDatabase()
        {
            using(SqliteConnection konekcija=new SqliteConnection(putanjaDoBaze))
            {
                konekcija.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS Transakcija
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Naziv TEXT NOT NULL,
                    Iznos REAL NOT NULL,
                    Kategorija TEXT NOT NULL,
                    Tip TEXT NOT NULL,
                    Datum TEXT NOT NULL
                );";

                using (SqliteCommand komanda = new SqliteCommand(sql, konekcija))
                {
                    komanda.ExecuteNonQuery();
                }
            }
        }

        public void Dodaj(Transakcija t)
        {
            using(SqliteConnection konekcija=new SqliteConnection(putanjaDoBaze))
            {
                konekcija.Open();
                string sql = @"INSERT INTO Transakcija(Naziv, Iznos, Datum, Kategorija, Tip)
                                VALUES (@naziv,@iznos,@datum,@kategorija,@tip)";

                using(SqliteCommand komanda=new SqliteCommand(sql, konekcija))
                {
                    komanda.Parameters.AddWithValue("@naziv", t.Naziv);
                    komanda.Parameters.AddWithValue("@iznos", t.Iznos);
                    komanda.Parameters.AddWithValue("@datum", t.Datum);
                    komanda.Parameters.AddWithValue("@kategorija", t.Kategorija);
                    komanda.Parameters.AddWithValue("@tip", t.Tip);
                    komanda.ExecuteNonQuery();
                }
            }
        }

        public List<Transakcija> VratiSve()
        {
            List<Transakcija> lista = new List<Transakcija>();
            using (SqliteConnection konekcija = new SqliteConnection(putanjaDoBaze))
            {
                konekcija.Open();
                string sql = @"SELECT * FROM Transakcija";

                using(SqliteCommand komanda=new SqliteCommand(sql, konekcija))
                {
                    using(SqliteDataReader citac = komanda.ExecuteReader())
                    {
                        while (citac.Read())
                        {
                            Transakcija t = new Transakcija();
                            t.Naziv = citac["Naziv"].ToString();
                            t.Kategorija = citac["Kategorija"].ToString();
                            t.Tip = citac["Tip"].ToString();
                            t.Id = Convert.ToInt32(citac["Id"]);
                            t.Iznos = Convert.ToDecimal(citac["Iznos"]);
                            t.Datum = DateTime.Parse(citac["Datum"].ToString());
                            lista.Add(t);
                        }
                    }
                }
            }
            return lista;
        }

        public void Obrisi(Transakcija t)
        {
            using(SqliteConnection konekcija=new SqliteConnection(putanjaDoBaze))
            {
                konekcija.Open();
                string sql = @"DELETE FROM Transakcija WHERE Id=@Id";
                using(SqliteCommand komanda=new SqliteCommand(sql, konekcija))
                {
                    komanda.Parameters.AddWithValue("@Id", t.Id);
                    komanda.ExecuteNonQuery();
                }
            }
        }

        public void Izmeni(Transakcija t)
        {
            using(SqliteConnection konekcija=new SqliteConnection(putanjaDoBaze))
            {
                konekcija.Open();
                string sql = @"UPDATE TRansakcija
                                SET Naziv=@naziv, Iznos=@Iznos, Datum=@Datum, Kategorija=@Kategorija, Tip=@Tip
                                WHERE id=@Id;";

                using(SqliteCommand komanda=new SqliteCommand(sql, konekcija))
                {
                    komanda.Parameters.AddWithValue("@naziv", t.Naziv);
                    komanda.Parameters.AddWithValue("@Iznos", t.Iznos);
                    komanda.Parameters.AddWithValue("@Datum", t.Datum);
                    komanda.Parameters.AddWithValue("@Kategorija", t.Kategorija);
                    komanda.Parameters.AddWithValue("@Tip", t.Tip);
                    komanda.Parameters.AddWithValue("@Id", t.Id);
                    komanda.ExecuteNonQuery();
                }
            }
        }
    }
}
