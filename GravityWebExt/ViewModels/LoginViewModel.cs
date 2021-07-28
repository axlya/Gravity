using System.ComponentModel.DataAnnotations;

namespace GravityWebExt.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*{0} не может быть пустым!")]
        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*{0} не может быть пустым!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}