using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class ReceiversController : Controller
    {
        [HttpGet]
        public IActionResult Map()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
    }
}