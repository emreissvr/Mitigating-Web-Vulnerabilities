using MySql.Data.MySqlClient;

public class UserRepository
{
    private readonly string _connectionString = "your-connection-string-here";

    public void AddUser(string username, string email)
    {
        using var connection = new MySqlConnection(_connectionString);
        string query = "INSERT INTO Users (Username, Email) VALUES (@Username, @Email)";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Username", InputSanitizer.SanitizeInput(username));
        cmd.Parameters.AddWithValue("@Email", InputSanitizer.SanitizeInput(email));
        connection.Open();
        cmd.ExecuteNonQuery();
    }
}
