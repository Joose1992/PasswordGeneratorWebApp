using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PasswordGeneratorWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string PasswordText { get; set; } = "";

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnPostSubmit()
        {
            PasswordText = "";

            PasswordText = GeneratorPassword();
        }

        private string GeneratorPassword()
        {
            string password = "";

            const long minPasswordLenght = 5;
            const long maxPasswordLenght = 30;

            int minCharCode = 35;
            int maxCharCode = 126;

            Random random = new Random();
            long passwordLenght = random.NextInt64(minPasswordLenght, maxPasswordLenght);

            for (int i = 0; i < passwordLenght; i++)
            {
                long charIntValue = random.NextInt64(minCharCode, maxCharCode);

                char c = Convert.ToChar(charIntValue);

                password += c;
            }

            return password;
        }

        public void OnGet()
        {

        }
    }
}