using NUnit.Framework;

namespace SafeVault.Security.Tests
{
    public class TestAdvancedSecurity
    {
        [Test]
        public void Test_SQLInjection_Attempt()
        {
            var repo = new UserRepository();
            string maliciousInput = "'; DROP TABLE Users;--";

            // Here we can't really DROP the table because we're mocking, but:
            Assert.DoesNotThrow(() => repo.AddUser(maliciousInput, "safe@example.com"));
        }

        [Test]
        public void Test_XSS_Attempt()
        {
            string maliciousScript = "<script>alert('Hacked');</script>";
            string sanitized = InputSanitizer.SanitizeInput(maliciousScript);

            Assert.IsFalse(sanitized.Contains("<script>"));
            Assert.IsTrue(sanitized.Contains("&lt;script&gt;"));
        }
    }
}
