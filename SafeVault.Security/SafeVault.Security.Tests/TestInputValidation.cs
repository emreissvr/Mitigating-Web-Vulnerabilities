using NUnit.Framework;

namespace SafeVault.Security.Tests
{
    public class TestInputValidation
    {
        [Test]
        public void TestForSQLInjection()
        {
            string input = "'; DROP TABLE Users;--";
            string sanitized = InputSanitizer.SanitizeInput(input);
            Assert.IsFalse(sanitized.Contains("'"));
            Assert.IsFalse(sanitized.ToLower().Contains("drop"));
        }

        [Test]
        public void TestForXSS()
        {   
            string input = "<script>alert('XSS')</script>";
            string sanitized = InputSanitizer.SanitizeInput(input);
            Assert.IsFalse(sanitized.Contains("<script>"));
            Assert.IsTrue(sanitized.Contains("&lt;"));
        }
    }
}
