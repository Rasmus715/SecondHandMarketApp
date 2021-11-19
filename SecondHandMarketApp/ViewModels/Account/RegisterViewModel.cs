using System.ComponentModel.DataAnnotations;

namespace SecondHandMarketApp.ViewModels.Account
{
    public class RegisterViewModel
    { 
        [Required(ErrorMessage = "Имя не введено")]
        public string Name { get; set; } 
        
        [Required(ErrorMessage = "Фамилия не введена")]
        public string Surname { get; set; }
        
        [Required(ErrorMessage = "Почта не введена")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Введите действительную почту")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Номер телефона не введён")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Некорректный номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password, ErrorMessage = "Введите пароль")]
        [MinLength(6, ErrorMessage = "Пароль не удовлетворяет требованиям (длинна должна составлять не менее 6 символов)")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Required(ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }
    }
}
