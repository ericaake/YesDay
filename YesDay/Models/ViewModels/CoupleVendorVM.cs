using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models.ViewModels
{
    public class CoupleVendorVM
    {
        public int Id { get; set; }

        public string Service { get; set; }
      
        public string ContactInfo { get; set; }


    }
}
