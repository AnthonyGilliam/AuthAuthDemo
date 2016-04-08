using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuthAuthDemo.Web.Models
{
    public class UserViewModel
    {
        [ReadOnly(true)]
        public int ID { get; set; }

        [ReadOnly(true)]
        public string FirstName { get; set; }

        [ReadOnly(true)]
        public string LastName { get; set; }

        [ReadOnly(true)]
        public string Password { get; set; }

        [ReadOnly(true)]
        public string EmailAddress { get; set; }
    }
}