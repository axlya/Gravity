using System.ComponentModel.DataAnnotations;

namespace GravityWebExt.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "*{0} не может быть пустым!")]
        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*{0} не может быть пустым!")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "*{0} должен иметь минимум {2} и максимум {1} символов!", MinimumLength = 3)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*{0} не может быть пустым!")]
        [Compare("Password", ErrorMessage = "*Пароли не совпадают!")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}