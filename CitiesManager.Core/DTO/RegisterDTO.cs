using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CitiesManager.Core.DTO
{
    public class RegisterDTO
    {
        public string PersonName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email Can't be blank")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number should contain digits only")]
        [Remote(action: "IsEmailAlreadyRegister", controller: "Account", ErrorMessage = "Email is already is use")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number Can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        [Remote(action: "IsEmailAlreadyRegister", controller: "Account", ErrorMessage = "Email is already is use")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password  Can't be blank")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirm Password  Can't be blank")]
        [Compare("Password", ErrorMessage = "Password and Confirm  don't match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
