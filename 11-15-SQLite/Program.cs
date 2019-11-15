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
            }
        }
    }
}
