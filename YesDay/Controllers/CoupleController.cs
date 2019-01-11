using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YesDay.Models;
using YesDay.Models.ViewModels;

namespace YesDay.Controllers
{
    [Authorize]
    public class CoupleController : Controller
    {
        CoupleServices coupleServices;

        public CoupleController(CoupleServices services)
        {
            this.coupleServices = services;
        }

        [HttpGet]
        public IActionResult GuestList()
        {
            return View(coupleServices.ShowAllGuests());

        }

        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();

        }

        [HttpPost]
        public IActionResult AddGuest(CoupleAddNewGuestVM newGuestVM, string saveAdd, string saveCancel)
        {
            if (!ModelState.IsValid)
                return View(newGuestVM);

            if (! string.IsNullOrEmpty(saveAdd))
            {
                coupleServices.AddNewGuest(newGuestVM);
                return RedirectToAction(nameof(AddGuest));
            }
            else if (!string.IsNullOrEmpty(saveCancel))
            {
                coupleServices.AddNewGuest(newGuestVM);
                return RedirectToAction(nameof(GuestList));
            }
            return RedirectToAction(nameof(GuestList));  //redirect to something went wrong
        }

        [HttpGet]
        public IActionResult Overview()
        {
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await coupleServices.LogoutAsync();
            return RedirectToAction("Index", "Public");
        }

        [HttpGet]
        public IActionResult Checklist()
        {
            return View(coupleServices.GetChecklist());
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(CoupleAddNewTaskVM newTaskVM, string saveAdd, string saveCancel)
        {
            if (!ModelState.IsValid)
                return View(newTaskVM);

            if (!string.IsNullOrEmpty(saveAdd))
            {
                coupleServices.AddNewTask(newTaskVM);
                return RedirectToAction(nameof(AddTask));
            }
            else if (!string.IsNullOrEmpty(saveCancel))
            {
                coupleServices.AddNewTask(newTaskVM);
                return RedirectToAction(nameof(Checklist));
            }

            return RedirectToAction(nameof(Checklist));
        }


    }
}