using System.ComponentModel.DataAnnotations;

namespace GravityWebExt.ViewModels
{
    public class EditPasswordViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "*{0} не может быть пустым!")]
        [DataType(DataType.Password)]
        [Display(Name = "Старый пароль")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "*{0} не может быть пустым!")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "*{0} должен иметь минимум {2} и максимум {1} символов!", MinimumLength = 3)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "*{0} не может быть пустым!")]
        [Compare("NewPassword", ErrorMessage = "*Пароли не совпадают!")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить новый пароль")]
        public string ConfirmNewPassword { get; set; }
    }
}
