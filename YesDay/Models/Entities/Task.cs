using System;
using System.Collections.Generic;

namespace YesDay.Models.Entities
{
    public partial class Task
    {
        public int Id { get; set; }
        public int Coupleref { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? DueDate { get; set; }
        public string TaskNote { get; set; }

        public CoupleAccount CouplerefNavigation { get; set; }
    }
}
