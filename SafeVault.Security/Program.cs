Console.WriteLine("SafeVault Input Security Demo");

string dirtyInput = "<script>alert('xss')</script>";
Console.WriteLine($"Original: {dirtyInput}");
Console.WriteLine($"Sanitized: {InputSanitizer.SanitizeInput(dirtyInput)}");
