using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Models;
using GraduationProject.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class MembersController : Controller
    {
        private MembersService service;
        private readonly IHostingEnvironment hostingEnvironment;

        public MembersController(MembersService service, IHostingEnvironment hostingEnvironment)
        {
            this.service = service;
            this.hostingEnvironment = hostingEnvironment;
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
        public async Task<IActionResult> Profile()
        {
            var viewModel = await service.GetProfile(HttpContext.User);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(MembersProfileVM membersProfileVM)
        {
            if (!ModelState.IsValid)
                return View(membersProfileVM);

            var statusCode = await service.CheckAddress(membersProfileVM);

            if (!statusCode.Item1)
            {
                membersProfileVM.ErrorMessage = statusCode.Item2;
                return View(membersProfileVM);
            }
            if (membersProfileVM.FilePath != null)
            {
                var uniqueFileName = GetUniqueFileName(membersProfileVM.FilePath.FileName);
                var images = Path.Combine(hostingEnvironment.WebRootPath, "Profiles");
                var filePath = Path.Combine(images, uniqueFileName);
                membersProfileVM.FilePath.CopyTo(new FileStream(filePath, FileMode.Create));
                membersProfileVM.Picture = uniqueFileName;
                //to do : Save uniqueFileName  to your db table   
            }
            //https://papapi.se/json/?s=Birger+Jarlsgatan+10&c=Stockholm&token=DIN_TOKEN
           

            await service.ChangeProfile(membersProfileVM, HttpContext.User);
            return RedirectToAction(nameof(Profile));
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}