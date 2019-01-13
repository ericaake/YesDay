using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models.ViewModels
{
    public class CoupleExpenseVM
    {

        public string Userref { get; set; }
        public string Item { get; set; }
        public decimal? EstimatedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public decimal SumAllCost { get; set; }
    }
}
