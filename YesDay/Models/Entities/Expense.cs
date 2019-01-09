using System;
using System.Collections.Generic;

namespace YesDay.Models.Entities
{
    public partial class Expense
    {
        public int Id { get; set; }
        public int Coupleref { get; set; }
        public string Item { get; set; }
        public decimal? EstimatedCost { get; set; }
        public decimal? ActualCost { get; set; }

        public CoupleAccount CouplerefNavigation { get; set; }
    }
}
