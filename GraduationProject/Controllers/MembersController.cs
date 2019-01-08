using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Models;
using GraduationProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class MembersController : Controller
    {
        private MembersService service;

        public MembersController(MembersService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Index(MembersIndexVM membersIndexVM)
        {
            if (!ModelState.IsValid)
                return View(membersIndexVM);

            var isLoggedIn = await service.SignInAsync(membersIndexVM);

            if (!isLoggedIn)
                return View(membersIndexVM);

            return RedirectToAction("Map", "Receivers");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterPrivate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPrivate(MembersRegisterPrivateVM membersRegisterPrivateVM)
        {
            if (!ModelState.IsValid)
                return View(membersRegisterPrivateVM);

            var isAdded = await service.CreateAsync(membersRegisterPrivateVM);

            if (!isAdded)
                return View(membersRegisterPrivateVM);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult RegisterOrganization()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterOrganization(MembersRegisterOrganizationVM membersRegisterOrganizationVM)
        {
            if (!ModelState.IsValid)
                return View(membersRegisterOrganizationVM);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Profile(MembersProfileVM membersProfileVM)
        {
            if (!ModelState.IsValid)
                return View(membersProfileVM);

            return RedirectToAction(nameof(Profile));
        }
    }
}