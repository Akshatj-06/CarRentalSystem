using System;
using System.Data.SqlClient;

namespace CarRentalSystem.DatabaseConnection
{
    public static class DBConnection
    {
        private static SqlConnection connection;

        public static SqlConnection GetDBConnection()
        {
            if (connection == null)
            {
                try
                {
                    string connectionString = CarRentalSystem.Util.PropertyUtil.GetConnectionString();
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: Could not establish a database connection. Details: " + ex.Message);
                }
            }
            return connection;
        }
    }
}
