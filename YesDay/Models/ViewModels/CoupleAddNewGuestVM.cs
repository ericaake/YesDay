using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models.ViewModels
{
    public class CoupleAddNewGuestVM
    {
        //Kom ihåg att lägga till UserRef också i denna. 
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string InvitedBy { get; set; }
        public string GuestTitle { get; set; }
        public string WeddingCrewTitle { get; set; }
        public string Rsvp { get; set; }
        public string FoodPreference { get; set; }
        public string GuestNote { get; set; }
    }
}
