using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Models;
using GraduationProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class ReceiversController : Controller
    {
        private ReceiversService receiversService;
        private MembersService membersService;
        private BadgeService badgeService;

        public ReceiversController(ReceiversService receiversService, MembersService membersService, BadgeService badgeService)
        {
            this.receiversService = receiversService;
            this.membersService = membersService;
            this.badgeService = badgeService;
        }

        [HttpGet]
        public async Task<IActionResult> Map()
        {
            var viewModel = new ReceiversMapVM
            {
                Positions = await receiversService.GetPositions(),
                Products = new ReceiversMapProductVM[]
                {
                    new ReceiversMapProductVM()
                }
            };

            await SetBadges();

            ViewBag.ActiveAddProduct = false;
            ViewBag.ActiveProducts = false;
            ViewBag.ActiveProfile = false;
            ViewBag.ActiveMap = true;
            ViewBag.ActiveSearch = false;
            ViewBag.ActiveCart = false;
            ViewBag.ActiveInbox = false;

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            var viewModels = new ReceiversSearchVM
            {
                Products = new ReceiversProductVM[] { new ReceiversProductVM() }
            };

            await SetBadges();

            ViewBag.ActiveAddProduct = false;
            ViewBag.ActiveProducts = false;
            ViewBag.ActiveProfile = false;
            ViewBag.ActiveMap = false;
            ViewBag.ActiveSearch = true;
            ViewBag.ActiveCart = false;
            ViewBag.ActiveInbox = false;

            return View(viewModels);
        }

        [HttpPost]
        public IActionResult Search(ReceiversSearchVM receiversSearchVM)
        {
            if (!ModelState.IsValid)
                return View(receiversSearchVM);

            return RedirectToAction(nameof(Search));
        }

        public async Task<IActionResult> ClaimProduct(int id)
        {
            var receiverId = membersService.GetUserId(HttpContext.User);
            var isClaimed = await receiversService.ClaimProduct(id, receiverId);

            return Json(isClaimed);
        }

        public async Task<IActionResult> UnclaimProduct(int id)
        {
            var receiver = await membersService.GetUser(HttpContext.User);
            var isUnClaimed = await receiversService.UnclaimProduct(id, receiver.Id);

            return Json(isUnClaimed);
        }

        [HttpGet]
        public async Task<IActionResult> UnclaimProductCart(int id)
        {
            var receiver = await membersService.GetUser(HttpContext.User);
            var isUnClaimed = await receiversService.UnclaimProduct(id, receiver.Id);

            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            await SetBadges();

            ViewBag.ActiveAddProduct = false;
            ViewBag.ActiveProducts = false;
            ViewBag.ActiveProfile = false;
            ViewBag.ActiveMap = false;
            ViewBag.ActiveSearch = false;
            ViewBag.ActiveCart = true;
            ViewBag.ActiveInbox = false;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetCart(double lat, double lng)
        {
            var receiverId = membersService.GetUserId(HttpContext.User);
            var viewModels = await receiversService.GetCart(receiverId, lat, lng);
            
            await SetBadges();

            return PartialView("_CartBox", viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(double lat, double lng)
        {
            var viewModels = await receiversService.GetDistances(lat, lng);

            await SetBadges();

            return PartialView("_ProductBox", viewModels);
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
















