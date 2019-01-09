using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YesDay.Models;

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
    }
}