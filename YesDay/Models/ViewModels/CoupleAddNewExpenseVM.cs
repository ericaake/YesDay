using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models.ViewModels
{
    public class CoupleAddNewExpenseVM
    {
        [Required]
        [Display(Name ="Post *")]
        public string Item { get; set; }

        [Display(Name = "Beräknad kostnad")]
        public decimal? EstimatedCost { get; set; }

        [Display(Name = "Faktiskt kostnad")]
        public decimal? ActualCost { get; set; }
    }
}
