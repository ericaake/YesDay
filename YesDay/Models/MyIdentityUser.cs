using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models
{
    public class MyIdentityUser : IdentityUser
    {
        public string FirstName1 { get; set; }
        public string FirstName2 { get; set; }
        public DateTime WeddingDate { get; set; }
        public decimal Budget { get; set; }
    }
}
