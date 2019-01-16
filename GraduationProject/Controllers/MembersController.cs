using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Helpers;
using GraduationProject.Models;
using GraduationProject.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class MembersController : Controller
    {
        private MembersService membersService;
        private BadgeService badgeService;
        private readonly IHostingEnvironment hostingEnvironment;

        public MembersController(MembersService membersService, IHostingEnvironment hostingEnvironment, BadgeService badgeService)
        {
            this.membersService = membersService;
            this.badgeService = badgeService;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            await SetBadges();

            return View();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Index(MembersIndexVM membersIndexVM)
        {
            if (!ModelState.IsValid)
                return View(membersIndexVM);

            var isLoggedIn = await membersService.SignInAsync(membersIndexVM);

            if (!isLoggedIn)
                return View(membersIndexVM);

            return RedirectToAction("Map", "Receivers");
        }


        [HttpGet]

        public async Task<IActionResult> Register()
        {
            ViewBag.BackButton = true;
            await SetBadges();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegisterPrivate()
        {
            ViewBag.BackButton = true;
            await SetBadges();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPrivate(MembersRegisterPrivateVM membersRegisterPrivateVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BackButton = true;
                return View(membersRegisterPrivateVM);
            }

            var isAdded = await membersService.CreateAsync(membersRegisterPrivateVM);

            if (!isAdded)
            {
                ViewBag.BackButton = true;
                return View(membersRegisterPrivateVM);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> RegisterOrganization()
        {
            await SetBadges();
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
        [HighlightedMenu(Menu.Profile)]
        public async Task<IActionResult> Profile()
        {
            var viewModel = await membersService.GetProfile(HttpContext.User);

            await SetBadges();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(MembersProfileVM membersProfileVM)
        {
            if (!ModelState.IsValid)
                return View(membersProfileVM);

            var statusCode = await membersService.CheckAddress(membersProfileVM);

            if (!statusCode.Item1)
            {
                membersProfileVM.ErrorMessage = statusCode.Item2;
                return View(membersProfileVM);
            }

            if (membersProfileVM.FilePath != null)
            {
                var uniqueFileName = Helper.GetUniqueFileName(membersProfileVM.FilePath.FileName);
                var images = Path.Combine(hostingEnvironment.WebRootPath, "profiles");
                var filePath = Path.Combine(images, uniqueFileName);
                membersProfileVM.FilePath.CopyTo(new FileStream(filePath, FileMode.Create));
                membersProfileVM.Picture = uniqueFileName;
            }

            await membersService.ChangeProfile(membersProfileVM, HttpContext.User);
            return RedirectToAction(nameof(Profile));
        }

        private async Task SetBadges()
        {
            var userId = membersService.GetUserId(HttpContext.User);
            ViewBag.BadgeProducts = await badgeService.ProductCount(userId);
            ViewBag.BadgeCart = await badgeService.CartCount(userId);
            ViewBag.BadgeInbox = await badgeService.InboxCount(userId);
        }

    }
}