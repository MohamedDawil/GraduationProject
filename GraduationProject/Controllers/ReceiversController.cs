using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class ReceiversController : Controller
    {
        [HttpGet]
        public IActionResult Map()
        {
            var viewModel = new ReceiversMapVM
            {
                Positions = new ReceiversMapPositionVM[]
                {
                    new ReceiversMapPositionVM()
                },
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
        
        public IActionResult ClaimProduct(int productId)
        {
            return RedirectToAction(nameof(Search));
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
    }
}
















