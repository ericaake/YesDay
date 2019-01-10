using System;
using System.Collections.Generic;

namespace YesDay.Models.Entities
{
    public partial class Expense
    {
        public int Id { get; set; }
        public string Userref { get; set; }
        public string Item { get; set; }
        public decimal? EstimatedCost { get; set; }
        public decimal? ActualCost { get; set; }
    }
}
