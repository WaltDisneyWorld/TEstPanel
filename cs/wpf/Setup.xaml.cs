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
        public string dbLocation;

        public Setup()
        {
            InitializeComponent();
        }

        

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
         

            // User input into table
            if (Directory.Exists(directoryBox.Text) && userBox.Text != null && passwordBox.Password != null)
            {
                // Initialize database
                SQLiteConnection.CreateFile("EvilPanel.sqlite");
                SQLiteConnection db = new SQLiteConnection("Data Source=EvilPanel.sqlite;Version=3;");
                db.Open();
                Dictionary<String, String> data = new Dictionary<String, String>();
                sqlite sql = new sqlite();

                // Create tables
                SQLiteCommand command = new SQLiteCommand("create table users (username TEXT, password TEXT)", db);
                command.ExecuteNonQuery();
                command = new SQLiteCommand("create table settings (setting TEXT, value TEXT)", db);
                command.ExecuteNonQuery();

                // User input
                dbLocation = directoryBox.Text + "EvilPanel.sqlite";
                command = new SQLiteCommand("insert into users (username, password) values ('" + userBox.Text + "', '" + sql.sha512(passwordBox.Password) + "')", db);
                command.ExecuteNonQuery();
                command = new SQLiteCommand("insert into settings (setting, value) values ('directory', '" + directoryBox.Text + "')", db);
                command.ExecuteNonQuery();

                MessageBox.Show("EvilPanel has been configured!");
                MainWindow main = new MainWindow();
                this.Hide();
                main.Show();
            }
            else MessageBox.Show("Error: invalid inputs");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Closing code
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
