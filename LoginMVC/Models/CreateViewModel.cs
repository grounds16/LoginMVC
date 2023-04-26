using Login.DataAccess.EF.Model;

namespace LoginMVC.Models
{

    public class CreateViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDuplicate { get; set; }
        public string ActionMessage { get; set; }

    }
}
