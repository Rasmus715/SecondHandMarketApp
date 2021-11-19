using System.ComponentModel.DataAnnotations;

namespace SecondHandMarketApp.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Почта не введена")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль не введён")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
