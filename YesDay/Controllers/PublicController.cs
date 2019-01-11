using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YesDay.Models;
using YesDay.Models.ViewModels;

namespace YesDay.Controllers
{
    public class PublicController : Controller
    {
        CoupleServices service;

        public PublicController(CoupleServices service)
        {
            this.service = service;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Signup()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Signup(PublicSignUpVM newCouple)
        {
            if (!ModelState.IsValid)
                return View(newCouple);
            else
            {
                var result = await service.RegisterUserAsync(newCouple);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Login));
                else
                {
                    ModelState.AddModelError(nameof(PublicSignUpVM.Email), "Försöket misslyckades");
                    return View(newCouple);
                }
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(PublicLogInVM logInVM)
        {
            if (!ModelState.IsValid)
                return View(logInVM);
            else
            {
                var result = await service.LoginInUserAsync(logInVM);
                if (result.Succeeded)
                    return RedirectToAction("Overview", "Couple");
                else
                {
                    ModelState.AddModelError(nameof(PublicLogInVM.Password), "Felaktigt lösenord");
                    return View(logInVM);
                }
            }

        }

    }
}