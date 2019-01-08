using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class GiversController : Controller
    {
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(GiversAddProductVM giversAddProductVM)
        {
            if (!ModelState.IsValid)
                return View(giversAddProductVM);

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