using System;
using System.Data;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Common;
using Npgsql;

public class Program
{
    public static async Task Main(string[] args)
    {
        // --- 1. Parameter Validation ---
        if (args.Length != 3)
        {
            Console.WriteLine("Error: Incorrect number of arguments.");
            Console.WriteLine("Usage: dotnet run <ConnectionString> <Query>");
            return;

            // for test
            /*args = new string[]{ 
                "Oracle", 
                "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=201.91.21.42)(PORT=1831)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=NBS)));User Id=BPANDA;Password=NBS;",
                "SELECT CHAVE_ALTERNATIVA, PLACA, CHASSI_COMPLETO FROM NBS.CARRERAVW_PATIO_VEICULOS"};*/
            
        }

        string dbType = args[0];
        string connectionString = args[1];
        string sqlQuery = args[2];

        // --- 2. Data Retrieval ---
        DataTable dataTable = new DataTable();
        try
        {
            if (dbType == "SqlServer")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        // Load the results into a DataTable
                        dataTable.Load(reader);
                    }
                }
            }
            else if (dbType == "Oracle")
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (OracleCommand command = new OracleCommand(sqlQuery, connection))
                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        // Load the results into a DataTable
                        dataTable.Load(reader);
                    }
                }
            }
            else if(dbType == "MySql")
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        // Load the results into a DataTable
                        dataTable.Load(reader);
                    }
                }
            }
            else if(dbType== "PostgreSql") {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection))
                    using (DbDataReader reader = await command.ExecuteReaderAsync())
                    {
                        // Load the results into a DataTable
                        dataTable.Load(reader);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Error: Invalid dbType = {dbType} use: SqlServer, Oracle, MySql or PostgreSql");
                return;
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
                object? value = row[colName] == DBNull.Value ? null : row[colName];
                rowDict[colName] = value;
            }
            rows.Add(rowDict);
        }

        // Use System.Text.Json to serialize the List of Dictionaries
        var options = new JsonSerializerOptions { WriteIndented = true };
        return JsonSerializer.Serialize(rows, options);
    }
}