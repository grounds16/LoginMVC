using Login.DataAccess.EF.Context;
using Login.DataAccess.EF.Repo;
using Microsoft.AspNetCore.Mvc;
using LoginMVC.Models;
using Login.DataAccess.EF.Model;
using System.Web;

namespace LoginMVC.Controllers
{
    public class CreateController : Controller
    {
        public readonly LoginRepository _Repo;

        public CreateController(LoginDbContext context)
        {
            _Repo = new LoginRepository(context);
        }
        public IActionResult Index()
        {
            CreateViewModel model = new CreateViewModel();
            return View(model);
        }

        public IActionResult Create(CreateViewModel model)
        {
            foreach (LoginModel login in _Repo.GetAllUsers())
            {
                if (login.UserName == model.UserName)
                {
                    model.IsDuplicate = true;
                }
            }

            if (model.IsDuplicate)
            {
                model.ActionMessage = "Username is already in use. Please try a different Username";
                return View("Index", model);
            }
            else
            {
                model.IsDuplicate = false;
                LoginModel user = new LoginModel(model.UserName, model.Password);
                _Repo.Create(user);
                return View("Success");
            }

        }
    }
}
