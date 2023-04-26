using Login.DataAccess.EF.Context;
using Login.DataAccess.EF.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Login.DataAccess.EF.Repo
{
    public class LoginRepository
    {
        private LoginDbContext _context;

        public LoginRepository(LoginDbContext context)
        {
            _context = context;
        }

        public int Create(LoginModel login)
        {
            _context.Add(login);
            _context.SaveChanges();

            return login.LoginID;
        }

        public int Update(LoginModel login)
        {
            LoginModel existingContact = _context.loginModel.Find(login.LoginID)!;

            existingContact.UserName = login.UserName;
            existingContact.Password = login.Password;

            _context.SaveChanges();

            return existingContact.LoginID;
        }

        public bool Delete(int LoginId)
        {
            LoginModel user = _context.loginModel.Find(LoginId)!;
            _context.Remove(user);
            _context.SaveChanges();

            return true;
        }

        public List<LoginModel>? GetAllUsers()
        {
            List<LoginModel> LoginList = _context.loginModel.ToList();
            return LoginList;
        }

        public LoginModel? GetLogin(int LoginID)
        {
            LoginModel account = _context.loginModel.Find(LoginID);
            return account;
        }

    }
}