using Microsoft.AspNetCore.Mvc;
using Login.DataAccess.EF;
using Login.DataAccess.EF.Model;
using Login.DataAccess.EF.Repo;
using Login.DataAccess.EF.Context;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using LoginMVC.Models;

namespace LoginMVC.Controllers
{
    public class LoginController : Controller
    {
        private LoginDbContext _context;
        public LoginController(LoginDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            LoginViewModel model = new LoginViewModel(_context);
            return View(model);
        }
        //Verifies if user has an existing account
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            LoginViewModel view = new LoginViewModel(_context);
            model.IsLoginSuccessful = false;
            LoginModel user = new LoginModel();

            foreach (LoginModel login in view.GetAllAccounts())
            {
                if (login.UserName == model.UserName)
                {
                    user = login;
                }
            }

            if (model.UserName == user.UserName && user.Password == model.Password)
            {
                model.IsLoginSuccessful = true;

                return View("Success");
            }
            else
            {
                model.ActionMessage = "Incorrect Username or Password. Please try again.";
                return View("Index", model);
            }
        }

        public IActionResult AllAccounts()
        {
            LoginViewModel model = new LoginViewModel(_context);
            return View("AllAccounts", model);
        }

        [HttpPost]
        public IActionResult AllAccounts(int loginId, string userName, string Password)
        {
            LoginViewModel model = new LoginViewModel(_context);
            LoginModel account = new LoginModel(loginId, userName, Password);

            model.SaveAccount(account);
            model.IsActionSuccess = true;
            model.ActionMessage = "Account has been saved successfully";

            return View(model);
        }

        public IActionResult Update(int id)
        {
            LoginViewModel model = new LoginViewModel(_context, id);
            return View(model);

        }

        public IActionResult Delete(int id)
        {
            LoginViewModel model = new LoginViewModel(_context);
            if (id > 0)
            {
                model.DeleteAccount(id);
            }
            model.IsActionSuccess = true;
            model.ActionMessage = "Account has been deleted successfully";
            return View("AllAccounts",model);
        }
    }
}
