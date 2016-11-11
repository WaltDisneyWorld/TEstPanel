using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;

namespace EvilPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("EvilPanel.sqlite"))
            {
                this.Hide();
                Setup setup = new Setup();
                setup.Show();
            }
        }

        private void verify_Click(object sender, RoutedEventArgs e)
        {
            sqlite sql = new sqlite();
            if (verifyUser.Text == sql.readValue("users", "username") && sql.sha512(verifyPassword.Password) == sql.readValue("users", "password"))
                MessageBox.Show("Verified!");
            else MessageBox.Show("Not verified!");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
