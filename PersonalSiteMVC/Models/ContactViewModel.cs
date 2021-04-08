using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PersonalSiteMVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Name is a required field.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress(ErrorMessage = "Please input a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is a required field.")]
        [UIHint("MultilineText")]
        public string Message { get; set; }
    }
}