using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;

namespace EvilPanel
{
    /// <summary>
    /// Interaction logic for Setup.xaml
    /// </summary>
    public partial class Setup : Window
    {
        public Setup()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {

            // User input into table
            if (Directory.Exists(directoryBox.Text))
            {
                // Initialize database
                SQLiteConnection.CreateFile("EvilPanel.sqlite");
                SQLiteConnection db = new SQLiteConnection("Data Source=EvilPanel.sqlite;Version=3;");
                db.Open();
                Dictionary<String, String> data = new Dictionary<String, String>();

                // Create tables
                SQLiteCommand command = new SQLiteCommand("create table users (username TEXT, password TEXT)", db);
                command.ExecuteNonQuery();
                command = new SQLiteCommand("create table settings (setting TEXT, value TEXT)", db);
                command.ExecuteNonQuery();

                // User input
                command = new SQLiteCommand("insert into users (username, password) values ('" + userBox.Text + "', '" + sha512(passwordBox.Password) + "')", db);
                command.ExecuteNonQuery();
                command = new SQLiteCommand("insert into settings (setting, value) values ('directory', '" + directoryBox.Text + "')", db);
                command.ExecuteNonQuery();
                Console.WriteLine(userBox.Text);
                Console.WriteLine(sha512(passwordBox.Password));
                sqlite sql = new sqlite();
                Console.WriteLine(sql.readValue("users", "username"));
            }
            else MessageBox.Show("Please enter a valid directory.");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel setup?", "Cancel setup", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        public static string sha512(string input)
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
