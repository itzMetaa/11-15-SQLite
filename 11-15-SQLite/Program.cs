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
                command.CommandText = @"CREATE TABLE macskak (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    nev VARCHAR(1000) NOT NULL,
                    meret INTEGER NOT NULL
                )";
                command.ExecuteNonQuery();
            }
        }
    }
}
