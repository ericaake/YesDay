using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models.ViewModels
{
    public class PublicSignUpVM
    {
        [Required(ErrorMessage ="Vänligen ange din e-post")]
        [Display(Name = "Ange e-post *")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Vänligen ange ditt namn")]
        [Display(Name = "Ditt namn *")]
        public string FirstName1 { get; set; }

        [Required(ErrorMessage = "Vänligen ange namnet på den person du ska gifta dig med")]
        [Display(Name = "Den du ska gifta dig med *")]
        public string FirstName2 { get; set; }

        [Required(ErrorMessage = "Vänligen ange ett lösenord med minst 8 tecken")]
        [Display(Name = "Ange ett lösenord *")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Vänligen ange ett datum för ditt bröllop")]
        [Display(Name ="Bröllopsdatum")]
        [DataType(DataType.Date, ErrorMessage =("Vänligen ange ett datum för ditt bröllop"))]
        public DateTime WeddingDate { get; set; }
    }
}
