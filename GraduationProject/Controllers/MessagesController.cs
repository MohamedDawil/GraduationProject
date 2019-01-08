using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    public class MessagesController : Controller
    {
        [HttpGet]
        public IActionResult Inbox()
        {
            var viewModel = new MessagesInboxVM[] { new MessagesInboxVM() };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Chat(int ProductId)
        {
            var viewModel = new MessagesChatVM
            {
                ProductName = "Morötter",
                Bubbles = new MessagesChatBubbleVM[]
                {
                    new MessagesChatBubbleVM {IsSent = false, MemberMessage = "Ge mig mina morötter!"},
                    new MessagesChatBubbleVM {IsSent = true, MemberMessage = "I helvete heller!!"}
                }
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Chat(MessagesChatVM messagesChatVM)
        {
            if (!ModelState.IsValid)
                return View(messagesChatVM);

            return RedirectToAction(nameof(Chat));
        }
    }
}