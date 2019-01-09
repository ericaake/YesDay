using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YesDay.Models;

namespace YesDay.Controllers
{
    public class CoupleController : Controller
    {
        CoupleServices services;

        public IActionResult GuestList()
        {
            return View(services.ShowAllGuests());
        }
    }
}