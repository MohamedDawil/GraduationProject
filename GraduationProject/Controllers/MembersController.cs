using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class MembersController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


    }
}