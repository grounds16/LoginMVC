using Microsoft.AspNetCore.Mvc;
using Login.DataAccess.EF;
using Login.DataAccess.EF.Repo;
using Login.DataAccess.EF.Model;
using Login.DataAccess.EF.Context;

namespace LoginMVC.Models
{
    public class LoginViewModel
    {
        private LoginRepository _repo;
        public int LoginID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsLoginSuccessful { get; set; }
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }
        public LoginModel CurrentAccount { get; set; }
        public List<LoginModel> AccountList { get; set; }

        public LoginViewModel() { }

        public LoginViewModel(LoginDbContext context)
        {
            _repo = new LoginRepository(context);
            AccountList = GetAllAccounts();
            CurrentAccount = AccountList.FirstOrDefault();
        }
        public LoginViewModel(LoginDbContext context, int LoginID)
        {
            _repo = new LoginRepository(context);
            AccountList = new List<LoginModel>();

            if (LoginID > 0)
            {
                CurrentAccount = GetAccount(LoginID);
            }
            else
            {
                CurrentAccount = new LoginModel();
            }
        }

        public void SaveAccount(LoginModel account)
        {
            if (account.LoginID > 0)
            {
                _repo.Update(account);
            }
            else
            {
                _repo.Create(account);
            }

            AccountList = GetAllAccounts();
            CurrentAccount = AccountList.FirstOrDefault();
        }

        public void DeleteAccount(int account)
        {
            _repo.Delete(account);
            AccountList = GetAllAccounts();
            CurrentAccount = AccountList.FirstOrDefault();
        }

        public List<LoginModel> GetAllAccounts()
        {
            return _repo.GetAllUsers();
        }

        public LoginModel GetAccount(int LoginId)
        {
            return _repo.GetLogin(LoginId);
        }


    }
}
