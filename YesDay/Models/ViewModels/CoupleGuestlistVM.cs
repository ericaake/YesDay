﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YesDay.Models.Entities;

namespace YesDay.Models.ViewModels
{
    public class CoupleGuestlistVM
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string InvitedBy { get; set; }
        public string GuestTitle { get; set; }
        public string WeddingCrewTitle { get; set; }
        public int Rsvp { get; set; }
        public SelectListItem[] GuestStatus { get; set; }
        public string FoodPreference { get; set; }
        public string GuestNote { get; set; }
        public string Userref { get; set; }
        public int[] GuestCount { get; set; }


    }
}
