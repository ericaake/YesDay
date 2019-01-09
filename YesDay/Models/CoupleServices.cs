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
                    GuestNote = r.GuestNote
                })
                .ToArray();

        }

        public void AddNewGuest(CoupleAddNewGuestVM newGuestVM)
        {
            Guest guest = new Guest()
            {
                Firstname = newGuestVM.Firstname,
                Lastname = newGuestVM.Lastname,
                Address = newGuestVM.Address,
                Email = newGuestVM.Email,
                InvitedBy = newGuestVM.InvitedBy,
                GuestTitle = newGuestVM.GuestTitle,
                WeddingCrewTitle = newGuestVM.WeddingCrewTitle,
                Rsvp = newGuestVM.Rsvp,
                FoodPreference = newGuestVM.FoodPreference,
                GuestNote = newGuestVM.GuestNote

            };
            context.Guest.Add(guest);
            context.SaveChanges();

        }
    }
}
