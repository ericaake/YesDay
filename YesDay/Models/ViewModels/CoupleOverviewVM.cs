using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models.ViewModels
{
    public class CoupleOverviewVM
    {
        [Display(Name = "Förnamn")]
        public string FirstName1 { get; set; }

        [Display(Name = "Förnamn")]
        public string FirstName2 { get; set; }

        [Display(Name = "Bröllopsdatum")]
        [DataType(DataType.Date)]
        public DateTime WeddingDate { get; set; }
    }
}
