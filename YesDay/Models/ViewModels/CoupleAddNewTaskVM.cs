using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models.ViewModels
{
    public class CoupleAddNewTaskVM
    {
        public string TaskDescription { get; set; }
        public DateTime? DueDate { get; set; }
        public string TaskNote { get; set; }
        public string TaskStatus { get; set; }
        public string Userref { get; set; }


    }
}
