using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YesDay.Models;

namespace YesDay.Controllers
{
    public class AccountController : Controller
    {
        MyIdentityContext context;

        public AccountController(MyIdentityContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}