public class AuthorizationService
{
    private readonly UserService _userService;

    public AuthorizationService(UserService userService)
    {
        _userService = userService;
    }

    // Check if the user has the required role
    public bool Authorize(string username, string requiredRole)
    {
        var role = _userService.GetUserRole(username);
        return role == requiredRole;
    }
}
