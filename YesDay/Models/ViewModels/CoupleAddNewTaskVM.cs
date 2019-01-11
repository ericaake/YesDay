using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models.ViewModels
{
    public class CoupleAddNewTaskVM
    {   
        [Display(Name ="Uppgift *")]
        [Required(ErrorMessage = "Vängligen ange Uppgift")]
        public string TaskDescription { get; set; }

        [Display(Name = "Slutdatum")]
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Anteckningar")]
        public string TaskNote { get; set; }

        [Display(Name = "Status")]
        public string TaskStatus { get; set; }

        public string Userref { get; set; }


    }
}
