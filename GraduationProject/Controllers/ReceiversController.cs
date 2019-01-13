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

        public ReceiversController(ReceiversService receiversService, MembersService membersService)
        {
            this.receiversService = receiversService;
            this.membersService = membersService;
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
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Search()
        {
            var viewModels = new ReceiversSearchVM
            {
                Products = new ReceiversProductVM[] { new ReceiversProductVM() }
            };
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
            var receiver = await membersService.GetUser(HttpContext.User);
            var isClaimed = await receiversService.ClaimProduct(id, receiver.Id);

            return Json(isClaimed);
        }

        public async Task<IActionResult> UnclaimProduct(int id)
        {
            var receiver = await membersService.GetUser(HttpContext.User);
            var isUnClaimed = await receiversService.UnclaimProduct(id, receiver.Id);

            return Json(isUnClaimed);
        }

        [HttpGet]
        public IActionResult Cart()
        {
            var viewModels = new ReceiversCartVM[]
            {
                new ReceiversCartVM()
            };

            return View(viewModels);
        }

        //[Route("/Receivers/SaveCurrentLocation/{lat}/{lng}")]
        [HttpGet]
        public async Task<IActionResult> SaveCurrentLocation(double lat, double lng)
        {
            var viewModels = await receiversService.GetDistances(lat, lng);
            //Partiell view
            return PartialView("_ProductBox", viewModels);
            //return Json(viewModels);
        }
    }
}
















