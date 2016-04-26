using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AuthAuthDemo.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter the user's first name.")]
        [MaxLength(50, ErrorMessage="Sorry, your First Name must be 50 characters or less")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the user's last name.")]
        [MaxLength(50, ErrorMessage = "Sorry, your Last Name must be 50 characters or less")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the user's email address.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide a password.")]
        [MinLength(6, ErrorMessage="The Password must be at least 6 characters.")]
        [RegularExpression(".*[A-Z].*", ErrorMessage="The Password must contain at least 1 uppercase character.")]
        public string Password { get; set; }
    }
}