using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UserLogin
    {

        public UserLogin(string email, string passWord)
        {
            Email = email;
            PassWord = passWord;
        }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string PassWord { get; set; }
    }
}
