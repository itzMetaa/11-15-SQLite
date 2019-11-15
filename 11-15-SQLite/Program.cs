using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_15_SQLite
{
    class Program
    {
        static void Main(string[] args)
        {       //ConnectionStrings.com
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=mydb.db"))
            {  
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS macskak (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    nev VARCHAR(1000) NOT NULL,
                    meret INTEGER NOT NULL
                )";
                command.ExecuteNonQuery();

                /*
                var beszurCmd = conn.CreateCommand();
                beszurCmd.CommandText = @"INSERT INTO macskak(nev,meret)
                VALUES ('Tigris', 45), ('Cirmos', 20), ('Pici', 120)";
                beszurCmd.ExecuteNonQuery();
                */

                var osszegCmd = conn.CreateCommand();
                osszegCmd.CommandText = @"SELECT COUNT(*) FROM macskak";
                long db = (long)osszegCmd.ExecuteScalar();

                Console.WriteLine("Darab " + db);

                Console.WriteLine("Mekkora macska kell?");
                string userMeretStr = Console.ReadLine();
                int userMeret;
                if (!int.TryParse(userMeretStr, out userMeret)) {
                    Console.WriteLine("Ervenytelen meret");
                    return;
                }

                var lekerdezesCmd = conn.CreateCommand();
                lekerdezesCmd.CommandText = @"
                    SELECT id, nev, meret FROM macskak
                    WHERE meret >= @meret
                ";
                lekerdezesCmd.Parameters.AddWithValue("@meret", userMeret);

                using (var reader = lekerdezesCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = reader.GetInt64(0);
                        string nev = reader.GetString(1);
                        long meret = reader.GetInt64(2);
                        Console.WriteLine("{0}, {1}cm ({2})", nev, meret, id);
                    }
                }

                Console.ReadLine();
            }
        }
    }
}
