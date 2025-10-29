using System;
using System.Data;
using System.Text.Json;
using Microsoft.Data.SqlClient;

public class Program
{
    public static async Task Main(string[] args)
    {
        // --- 1. Parameter Validation ---
        if (args.Length != 2)
        {
            Console.WriteLine("Error: Incorrect number of arguments.");
            Console.WriteLine("Usage: dotnet run <ConnectionString> <Query>");
            return;
        }

        string connectionString = args[0];
        string sqlQuery = args[1];

        // --- 2. Data Retrieval ---
        DataTable dataTable = new DataTable();
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    // Load the results into a DataTable
                    dataTable.Load(reader);
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine($"\n[SQL Error]: An error occurred while executing the query.");
            Console.WriteLine($"Message: {ex.Message}");
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[General Error]: An unexpected error occurred.");
            Console.WriteLine($"Message: {ex.Message}");
            return;
        }

        // --- 3. JSON Conversion ---
        string jsonResult = ConvertDataTableToJson(dataTable);

        // --- 4. Output Result ---
        Console.WriteLine(jsonResult);
    }

    /// <summary>
    /// Converts a DataTable into a JSON array of objects.
    /// </summary>
    /// <param name="table">The DataTable to convert.</param>
    /// <returns>A JSON string.</returns>
    public static string ConvertDataTableToJson(DataTable table)
    {
        var rows = new List<Dictionary<string, object>>();
        var columns = table.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();

        foreach (DataRow row in table.Rows)
        {
            var rowDict = new Dictionary<string, object>();
            foreach (var colName in columns)
            {
                // Convert DBNull to null, otherwise use the value
                object value = row[colName] == DBNull.Value ? null : row[colName];
                rowDict[colName] = value;
            }
            rows.Add(rowDict);
        }

        // Use System.Text.Json to serialize the List of Dictionaries
        var options = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(rows, options);
    }
}