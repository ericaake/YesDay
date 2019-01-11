using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models.ViewModels
{
    public class PublicLogInVM
    {
        [Required]
        [Display(Name = "Ange e-post")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Ange ett lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
