using System;
using System.Collections.Generic;

namespace YesDay.Models.Entities
{
    public partial class CoupleAccount
    {
        public CoupleAccount()
        {
            Expense = new HashSet<Expense>();
            Guest = new HashSet<Guest>();
            Task = new HashSet<Task>();
            Vendor = new HashSet<Vendor>();
        }

        public int Id { get; set; }
        public string Firstname1 { get; set; }
        public string Firstname2 { get; set; }
        public string Email { get; set; }
        public DateTime? WeddingDate { get; set; }
        public decimal? Budget { get; set; }

        public ICollection<Expense> Expense { get; set; }
        public ICollection<Guest> Guest { get; set; }
        public ICollection<Task> Task { get; set; }
        public ICollection<Vendor> Vendor { get; set; }
    }
}
