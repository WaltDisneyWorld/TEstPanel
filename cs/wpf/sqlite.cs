using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EvilPanel
{
    class sqlite
    {
        string result;
        
        public string readValue(string table, string query)
        {
            Setup setup = new Setup();
            string dbLocation = setup.dbLocation;
            SQLiteConnection db = new SQLiteConnection("Data Source=EvilPanel.sqlite;Version=3;");
            db.Open();
            SQLiteCommand command = new SQLiteCommand("select " + query + " from " + table, db);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetString(0);
            }
            return result;
        }

        public string sha512(string input)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha512.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}
