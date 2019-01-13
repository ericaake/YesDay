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
        public IActionResult GetPartialView()
        {
            var date = coupleServices.GetWeddingDate();
            DateTime today = DateTime.Now;
            CoupleGetPartialViewVM vM = new CoupleGetPartialViewVM
            {
                DaysRemaining = (date - today).Days.ToString()
            };
            return PartialView("_CountDownBox", vM);

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

            if (!string.IsNullOrEmpty(saveAdd))
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
            var couple = coupleServices.GetUserById();
            CoupleOverviewVM vM = new CoupleOverviewVM
            {
                FirstName1 = couple.FirstName1,
                FirstName2 = couple.FirstName2
            };
            return View(vM);

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
            var vm = coupleServices.CreateViewModel();
            return View(vm);
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

        [HttpGet]
        public IActionResult Vendor()
        {
            return View(coupleServices.ShowAllVendors());
        }


        [HttpGet]
        public IActionResult AddVendor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVendor(CoupleAddNewVendorVM newVendorVM, string saveAdd, string saveCancel)
        {
            if (!ModelState.IsValid)
                return View(newVendorVM);

            if (!string.IsNullOrEmpty(saveAdd))
            {
                coupleServices.AddNewVendor(newVendorVM);
                return RedirectToAction(nameof(AddVendor));
            }
            else if (!string.IsNullOrEmpty(saveCancel))
            {
                coupleServices.AddNewVendor(newVendorVM);
                return RedirectToAction(nameof(Vendor));
            }

            return RedirectToAction(nameof(Vendor));
        }

        [HttpGet]
        public IActionResult Expense()
        {
            return View(coupleServices.ShowAllExpenses());
        }

        [HttpGet]
        public IActionResult AddExpense()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExpense(CoupleAddNewExpenseVM newExpenseVM, string saveAdd, string saveCancel)
        {
            if (!ModelState.IsValid)
                return View(newExpenseVM);

            if (!string.IsNullOrEmpty(saveAdd))
            {
                coupleServices.AddNewExpense(newExpenseVM);
                return RedirectToAction(nameof(AddExpense));
            }
            else if (!string.IsNullOrEmpty(saveCancel))
            {
                coupleServices.AddNewExpense(newExpenseVM);
                return RedirectToAction(nameof(Expense));
            }

            return RedirectToAction(nameof(Expense));
        }



        public IActionResult Settings()
        {
            var couple = coupleServices.GetUserById();
            CoupleSettingVM vM = new CoupleSettingVM
            {
                FirstName1 = couple.FirstName1,
                FirstName2 = couple.FirstName2,
                Email = couple.Email,
                Password = couple.PasswordHash,
                WeddingDate = couple.WeddingDate
            };
            return View(vM);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(CoupleSettingVM vM)
        {
            if (!ModelState.IsValid)
                return View(vM);
            else
            {
                var result = await coupleServices.UpdateUserAsync(vM);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Overview));

                else
                    return View(vM);
            }
        }
    }
}