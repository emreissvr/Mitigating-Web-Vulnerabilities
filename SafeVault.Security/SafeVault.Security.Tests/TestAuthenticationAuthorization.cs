using NUnit.Framework;

namespace SafeVault.Security.Tests
{
    public class TestAuthenticationAuthorization
    {
        private UserService _userService;
        private AuthorizationService _authorizationService;

        [SetUp]
        public void Setup()
        {
            _userService = new UserService();
            _authorizationService = new AuthorizationService(_userService);

            // Pre-register test users
            _userService.RegisterUser("adminuser", "AdminPass123", "admin");
            _userService.RegisterUser("normaluser", "UserPass456", "user");
        }

        [Test]
        public void TestSuccessfulLogin()
        {
            bool result = _userService.Authenticate("adminuser", "AdminPass123");
            Assert.IsTrue(result);
        }

        [Test]
        public void TestFailedLogin()
        {
            bool result = _userService.Authenticate("adminuser", "WrongPassword");
            Assert.IsFalse(result);
        }

        [Test]
        public void TestAdminAccess()
        {
            bool authorized = _authorizationService.Authorize("adminuser", "admin");
            Assert.IsTrue(authorized);
        }

        [Test]
        public void TestUnauthorizedAccess()
        {
            bool authorized = _authorizationService.Authorize("normaluser", "admin");
            Assert.IsFalse(authorized);
        }
    }
}
