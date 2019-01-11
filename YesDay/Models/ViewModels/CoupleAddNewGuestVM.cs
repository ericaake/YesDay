﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YesDay.Models.ViewModels
{
    public class CoupleAddNewGuestVM
    {
        [Display(Name ="Förnamn *")]
        [Required(ErrorMessage = "Vängligen ange förnamn")]
        public string Firstname { get; set; }

        [Display(Name = "Efternamn *")]
        [Required(ErrorMessage = "Vängligen ange efternamn")]
        public string Lastname { get; set; }

        [Display(Name = "Adress")]
        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Inbjuden av")]
        public string InvitedBy { get; set; }

        [Display(Name = "Gästtitel")]
        public string GuestTitle { get; set; }

        [Display(Name = "Bröllopsroll")]
        public string WeddingCrewTitle { get; set; }

        [Display(Name = "OSA")]
        public string Rsvp { get; set; }

        [Display(Name = "Specialkost")]
        public string FoodPreference { get; set; }

        [Display(Name = "Anteckningar")]
        public string GuestNote { get; set; }

        public string Userref { get; set; }

    }
}
