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
        private BadgeService badgeService;
        private readonly IHostingEnvironment hostingEnvironment;

        public GiversController(GiversService giversService, MembersService membersService, BadgeService badgeService, IHostingEnvironment environment)
        {
            this.giversService = giversService;
            this.membersService = membersService;
            this.badgeService = badgeService;
            this.hostingEnvironment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            await SetBadges();

            return View(new GiversAddProductVM());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(GiversAddProductVM giversAddProductVM)
        {
            //http://api.ica.se/api/upclookup?upc=7310390001383
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
            giversAddProductVM.Street = giver.Street;
            giversAddProductVM.City = giver.City;
            giversAddProductVM.ZipCode = giver.ZipCode;

            var location = await giversService.GetCoordinates(giver);
            giversAddProductVM.Location = location;

            await giversService.CreateProductAsync(giversAddProductVM);

            return RedirectToAction(nameof(AddProduct));
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var giverId = membersService.GetUserId(HttpContext.User);
            var viewModel = new GiversProductsVM
            {
                Claimed = await giversService.GetClaimed(giverId),
                Unclaimed = await giversService.GetUnclaimed(giverId)
            };

            await SetBadges();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeProduct(int id)
        {
            var viewModel = await giversService.GetProduct(id);

            await SetBadges();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeProduct(GiversChangeProductVM giversChangeProductVM)
        {
            if (!ModelState.IsValid)
                return View(giversChangeProductVM);

            if (giversChangeProductVM.Picture != null)
            {
                var uniqueFileName = Helper.GetUniqueFileName(giversChangeProductVM.Picture.FileName);
                var images = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                var filePath = Path.Combine(images, uniqueFileName);
                giversChangeProductVM.Picture.CopyTo(new FileStream(filePath, FileMode.Create));
                giversChangeProductVM.PictureFileName = uniqueFileName;
            }

            var giver = await membersService.GetUser(HttpContext.User);
            giversChangeProductVM.GiverId = giver.Id;
            giversChangeProductVM.Street = giver.Street;
            giversChangeProductVM.City = giver.City;
            giversChangeProductVM.ZipCode = giver.ZipCode;

            var location = await giversService.GetCoordinates(giver);
            giversChangeProductVM.Location = location;

            await giversService.ChangeProductAsync(giversChangeProductVM);

            return RedirectToAction(nameof(Products));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var giverId = membersService.GetUserId(HttpContext.User);
            await giversService.DeleteProduct(id, giverId);
            return RedirectToAction(nameof(Products));
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