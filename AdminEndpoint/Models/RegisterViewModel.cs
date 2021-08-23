using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminEndpoint.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "نام کاربری")]
        [Remote("IsUserNameInUse", "Account", "Account", ErrorMessage = "Invalid username")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        [Remote("IsEmailInUse", "Account", "Account", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "شماره همراه")]
        [MaxLength(11,ErrorMessage ="فرمت شماره همراه درست نیست")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "تکرار رمز عبور")]
        [Compare(nameof(Password),ErrorMessage ="رمز عبور برابر نیست")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
