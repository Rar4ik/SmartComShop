using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SmartCom.Domain.DTO.Identity;

namespace SmartCom.Domain.ViewModels
{
    public class UserCustomerViewModel
    {
        #region UserDTO
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }

        //[Required]
        //[Display(Name = "Логин")]
        public string UserName { get; set; }

        [Display(Name = "Запомнить меня")]
        public string RememberMe { get; set; }

        #endregion

        #region CustomerDTO
        public string CustomerName { get; set; }
        public string Code { get; set; }
        public string CustomerAddress { get; set; }
        public int? CustomerDiscount { get; set; } 
        #endregion
        public bool IsAdmin { get; set; }
    }
}
