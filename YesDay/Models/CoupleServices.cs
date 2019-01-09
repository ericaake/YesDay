using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YesDay.Models.Entities;
using YesDay.Models.ViewModels;

namespace YesDay.Models
{
    public class CoupleServices
    {
        YesDayContext context;

        public CoupleServices(YesDayContext context)
        {
            this.context = context;
        }

        public CoupleGuestlistVM[] ShowAllGuests()
        {
            return context.Guest
                .Select(r => new CoupleGuestlistVM()
                {
                    Id = r.Id,
                    Firstname = r.Firstname,
                    Lastname = r.Lastname,
                    Address = r.Address,
                    Email = r.Email,
                    InvitedBy = r.InvitedBy,
                    GuestTitle = r.GuestTitle,
                    WeddingCrewTitle = r.WeddingCrewTitle,
                    Rsvp = r.Rsvp,
                    FoodPreference = r.FoodPreference,
                    GuestNote = r.GuestNote,
                    CouplerefNavigation = r.CouplerefNavigation
                })
                .ToArray();
        }
    }
}
