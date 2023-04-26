using LoginMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace LoginMVC.Controllers
{
    public class PasswordGeneratorController : Controller
    {
        public IActionResult Index()
        {
            PasswordGeneratorViewModel model = new PasswordGeneratorViewModel();
            return View(model);
        }

        public IActionResult GenerateResult(PasswordGeneratorViewModel model)
        {

            Random random = new Random();
            string defaultPassword = "abcdefghijklmnopqrstuvwxyz0123456789";
            string capLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string special = "!@#$%^&*";
            string currentPassword = "";
            string resultPassword = string.Empty;

            if (model.UpperCase && model.SpecialCharcters)
            {
                currentPassword = defaultPassword + capLetters + special;
            }
            if (model.UpperCase)
            {
                currentPassword = defaultPassword + capLetters;
            }

            if (model.SpecialCharcters)
            {
                currentPassword = defaultPassword + special;
            }
            else
            {
                currentPassword = defaultPassword;
            }

            for (int i = 0; i < model.PasswordLength; i++)
            {
                int currentValue = random.Next(0, currentPassword.Length);
                char currentLetter = currentPassword[currentValue];
                resultPassword += currentLetter;
            }
            model.PasswordGenerated = resultPassword;

            return View("Index", model);
        }
    }
}