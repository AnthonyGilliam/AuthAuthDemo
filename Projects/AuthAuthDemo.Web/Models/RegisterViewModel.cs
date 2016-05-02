using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AuthAuthDemo.Web.CustomAttributes;

namespace AuthAuthDemo.Web.Models
{
    public class RegisterViewModel
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter the user's first name.")]
        [MaxLength(50, ErrorMessage="Sorry, your First Name must be 50 characters or less")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter the user's last name.")]
        [MaxLength(50, ErrorMessage = "Sorry, your Last Name must be 50 characters or less")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the user's email address.")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("User Name")]
        [RequiredWhenNot("UseEmailAsUserName", true, "Please provide a user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please provide a password.")]
        [MinLength(6, ErrorMessage="The Password must be at least 6 characters.")]
        [RegularExpression(".*[A-Z].*", ErrorMessage="The Password must contain at least 1 uppercase character.")]
        public string Password { get; set; }

        [DisplayName("Use Email As Username?")]
        public bool UseEmailAsUserName { get; set; }
    }
}