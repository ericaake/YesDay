using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models.ViewModels
{
    public class CoupleSettingVM
    {
        [Display(Name = "Ange e-post")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Förnamn *")]
        public string FirstName1 { get; set; }

        [Required]
        [Display(Name = "Förnamn *")]
        public string FirstName2 { get; set; }

        [Display(Name = "Ange ett lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Bröllopsdatum")]
        [DataType(DataType.Date)]
        public DateTime WeddingDate { get; set; }

        [Display(Name = "Total budget")]
        public decimal Budget { get; set; }
    }
}
