using System;
using System.Collections.Generic;
using System.IO;

namespace CarRentalSystem.Util
{
    public static class PropertyUtil
    {
        public static string GetConnectionString()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dbconfig.properties");
            Dictionary<string, string> properties = new Dictionary<string, string>();

            try
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                    {
                        var keyValue = line.Split(new[] { '=' }, 2);
                        properties[keyValue[0].Trim()] = keyValue[1].Trim();
                    }
                }

                string connectionString = $"Data Source={properties["hostname"]},{properties["port"]};" +
                                          $"Initial Catalog={properties["dbname"]};" +
                                          $"User ID={properties["username"]};" +
                                          $"Password={properties["password"]};" +
                                          "Encrypt=False;";

                return connectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading the properties file: " + ex.Message);
                throw;
            }
        }
    }
}
