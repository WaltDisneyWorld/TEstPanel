using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilPanel
{
    class sqlite
    {
        string result;
        

        public string readValue(string table, string query)
        {
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
    }
}
