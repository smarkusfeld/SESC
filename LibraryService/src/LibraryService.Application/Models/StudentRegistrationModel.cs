using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Models
{
    public class StudentRegistrationModel
    {
        [Required(ErrorMessage = "StudentID is required")]
        public string StudentID { get; set; }

        [Required(ErrorMessage = "Pin is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The pin and confirmation pin do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
