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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace EuroGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=eurovizio;";
        private readonly MySqlConnection connection;
        
        public MainWindow()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
        }

        private void _4fel_Click(object sender, RoutedEventArgs e)
        {
            string readString = "SELECT * where orszag = Magyarország;";
            MySqlCommand readCommand = new MySqlCommand(readString, connection);
            connection.Open();
            readCommand.ExecuteReader();
            if(readCommand != null)
            
            {
                while(readCommand.read())
                {
                    List<string> magyarok = readCommand.read();
                    MessageBox.Show(magyarok.ToString());
                }
            }
            connection.Close();
        }

        private void _5fel_Click(object sender, RoutedEventArgs e)
        {
            string select = "SELECT AVG(pontszam) WHERE orszag = Németország;";
            MySqlCommand command = new MySqlCommand(select, connection);
            connection.Open();
            command.ExecuteReader();
            while (command.read())
            {
                List<string> nemetpontok = command.read();
                MessageBox.Show(nemetpontok.ToString());
            }
            connection.Close();
        }

        private void _6fel_Click(object sender, RoutedEventArgs e)
        {
            string select = "SELECT eloado, cim WHERE cim LIKE 'Luck';";
            MySqlCommand command = new MySqlCommand(select, connection);
            connection.Open();
            command.ExecuteReader();
            while (command.read())
            {
                List<string> containsLuck = command.read();
                MessageBox.Show(containsLuck.ToString());
            }
            connection.Close();
        }

        private void _7fel_Click(object sender, RoutedEventArgs e)
        {
            string nev = Nev.Text;
            string select = $"SELECT cim, eloado WHERE eloado LIKE {nev} ORDER BY cim ASC;";
            MySqlCommand command = new MySqlCommand(select, connection);
            connection.Open();
            command.ExecuteReader();
            while (command.read())
            {
                List<string> eloadokcimvalami = command.read();
                eloadok.Items.Add(eloadokcimvalami.ToString());
                
            }
            connection.Close();

        }

        private void _8fel_Click(object sender, RoutedEventArgs e)
        {
            datum.Content = data.SelectedItem.ToString();
        }
    }
}
