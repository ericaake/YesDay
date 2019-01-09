using System;
using System.Collections.Generic;

namespace YesDay.Models.Entities
{
    public partial class Vendor
    {
        public int Id { get; set; }
        public string Userref { get; set; }
        public string Service { get; set; }
        public string ContactInfo { get; set; }

    }
}
