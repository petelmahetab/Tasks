using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADO.NET_Demo
{
    public partial class Form1 : Form
    {
        private string connectionString = "Your_Connection_String_Here";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Task 1: Create Database
            CreateDatabase();

            // Task 2: Create Table 'employee' along with Primary Key Constraint
            CreateTableEmployee();

            // Task 3: Print All Information
            PrintAllInformation();

            // Task 4: Perform CRUD Operations
            // For demonstration purpose, you can perform CRUD operations manually or add buttons to perform these operations

            // Task 5: Update Information using Id and apply validation in the entire form
            // For demonstration purpose, you can implement update operation and validation logic

            // Task 6: Display Information in DataGridView
            DisplayInformationInDataGridView();
        }

        private void CreateDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string createDatabaseQuery = "CREATE DATABASE YourDatabaseName";
                    using (SqlCommand command = new SqlCommand(createDatabaseQuery, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Database created successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating database: " + ex.Message);
            }
        }

        private void CreateTableEmployee()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string createTableQuery = "CREATE TABLE employee (Id INT PRIMARY KEY, Name NVARCHAR(50), Age INT)";
                    using (SqlCommand command = new SqlCommand(createTableQuery, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Table 'employee' created successfully with primary key constraint!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating table: " + ex.Message);
            }
        }

        private void PrintAllInformation()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM employee";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
        }

        private void DisplayInformationInDataGridView()
        {
            // Task 6: Display Information in DataGridView
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM employee";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying data: " + ex.Message);
            }
        }
    }
}
