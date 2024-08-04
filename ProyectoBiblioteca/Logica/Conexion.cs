using System;
using System.Data.SqlClient;

public class Conexion
{
    public static string CN = @"Server=DESKTOP-BSDGG84\SQLEXPRESS;Database=DB_BIBLIOTECA;Integrated Security=True;TrustServerCertificate=True";

    public static void TestConnection()
    {
        using (SqlConnection connection = new SqlConnection(CN))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Conexión exitosa");

                // Intenta obtener la versión del servidor
                string serverVersion = connection.ServerVersion;
                Console.WriteLine($"Versión del servidor: {serverVersion}");

                // Ejecuta una consulta simple
                using (SqlCommand command = new SqlCommand("SELECT @@VERSION", connection))
                {
                    string version = (string)command.ExecuteScalar();
                    Console.WriteLine($"Versión completa: {version}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error SQL: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error de operación: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
            }
        }
    }
}