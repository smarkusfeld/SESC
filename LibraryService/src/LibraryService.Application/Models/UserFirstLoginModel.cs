using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Models
{
    public class UserFirstLoginModel
    {
        [Required]
        public string StudentID { get; set; }

        [Required(ErrorMessage = "Pin is required")]
        [DataType(DataType.Password)]
        public int Pin { get; set; }


        [Compare("Pin", ErrorMessage = "The pin and confirmation pin do not match.")]
        [DataType(DataType.Password)]
        public int Confirmation { get; set; }
    }
}
