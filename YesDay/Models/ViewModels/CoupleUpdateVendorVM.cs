using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models.ViewModels
{
    public class CoupleUpdateVendorVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Företag/tjänst*")]
        public string Service { get; set; }

        [Display(Name = "Kontaktinfo")]
        public string ContactInfo { get; set; }

        public string Userref { get; set; }
    }
}
