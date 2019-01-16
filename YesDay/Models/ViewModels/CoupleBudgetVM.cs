using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models.ViewModels
{
    public class CoupleBudgetVM
    {
        public decimal? TotalBudget { get; set; }
        public decimal SumExpenses { get; set; }
        public decimal Percentage { get; set; }
    }
}
