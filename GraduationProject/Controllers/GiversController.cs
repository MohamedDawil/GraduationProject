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
    public class GiversController : Controller
    {
        private GiversService giversService;
        private MembersService membersService;
        private readonly IHostingEnvironment hostingEnvironment;

        public GiversController(GiversService giversService, MembersService membersService, IHostingEnvironment environment)
        {
            this.giversService = giversService;
            this.membersService = membersService;
            this.hostingEnvironment = environment;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View(new GiversAddProductVM());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(GiversAddProductVM giversAddProductVM)
        {
            if (!ModelState.IsValid)
                return View(giversAddProductVM);

            if (giversAddProductVM.Picture != null)
            {
                var uniqueFileName = Helper.GetUniqueFileName(giversAddProductVM.Picture.FileName);
                var images = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                var filePath = Path.Combine(images, uniqueFileName);
                giversAddProductVM.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
                giversAddProductVM.PictureFileName = uniqueFileName;
            }

            var giver = await membersService.GetUser(HttpContext.User);
            giversAddProductVM.GiverId = giver.Id;

            var location = await giversService.GetCoordinates(giver);
            giversAddProductVM.Location = location;

            await giversService.CreateProductAsync(giversAddProductVM);

            return RedirectToAction(nameof(AddProduct));
        }

        [HttpGet]
        public IActionResult Products()
        {
            var viewModel = new GiversProductsVM
            {
                Claimed = new GiversClaimedVM[] { new GiversClaimedVM() },
                Unclaimed = new GiversClaimedVM[] { new GiversClaimedVM() }
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ChangeProduct(int productId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangeProduct(GiversChangeProductVM giversChangeProductVM)
        {
            if (!ModelState.IsValid)
                return View(giversChangeProductVM);

            return RedirectToAction(nameof(ChangeProduct));
        }
    }
}