using System.ComponentModel.DataAnnotations;

namespace PortfolioApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        public string Password { get; set; }
    }
}
