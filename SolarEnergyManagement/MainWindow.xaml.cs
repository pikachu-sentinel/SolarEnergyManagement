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
using System.Data.SQLite;

namespace SolarEnergyManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Define the connection string
            string connectionString = "Data Source=mydatabase.db;Version=3;";

            // Create a new SQLite connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Create a table (if it doesn't exist)
                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS MyTable (
                    Id INTEGER PRIMARY KEY,
                    Name TEXT,
                    Age INTEGER
                );";
                using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection))
                {
                    createTableCommand.ExecuteNonQuery();
                }

                // Insert data into the table
                string insertDataQuery = "INSERT INTO MyTable (Name, Age) VALUES (@Name, @Age);";
                using (SQLiteCommand insertDataCommand = new SQLiteCommand(insertDataQuery, connection))
                {
                    insertDataCommand.Parameters.AddWithValue("@Name", "John");
                    insertDataCommand.Parameters.AddWithValue("@Age", 30);
                    insertDataCommand.ExecuteNonQuery();
                }

                // Read data from the table
                string readDataQuery = "SELECT * FROM MyTable;";
                using (SQLiteCommand readDataCommand = new SQLiteCommand(readDataQuery, connection))
                {
                    using (SQLiteDataReader reader = readDataCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int age = reader.GetInt32(2);
                            Console.WriteLine($"Id: {id}, Name: {name}, Age: {age}");
                        }
                    }
                }
            }
        }
    }
}
