using System.Security.Cryptography;
using System.Text;

public class UserService
{
    private readonly Dictionary<string, (string HashedPassword, string Role)> _users = new();

    // Create a new user with hashed password and role
    public void RegisterUser(string username, string password, string role)
    {
        var hashedPassword = HashPassword(password);
        _users[username] = (hashedPassword, role);
    }

    // Authenticate user credentials
    public bool Authenticate(string username, string password)
    {
        if (_users.TryGetValue(username, out var userInfo))
        {
            var hashedInput = HashPassword(password);
            return userInfo.HashedPassword == hashedInput;
        }
        return false;
    }

    // Get user role
    public string GetUserRole(string username)
    {
        return _users.TryGetValue(username, out var userInfo) ? userInfo.Role : null;
    }

    // Password hashing (simplified with SHA256 for demo - bcrypt or Argon2 preferred in production)
    private string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hash);
    }
}
