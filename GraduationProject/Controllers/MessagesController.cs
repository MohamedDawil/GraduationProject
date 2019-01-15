using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Hubs;
using GraduationProject.Models;
using GraduationProject.Models.Services;
using GraduationProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace GraduationProject.Controllers
{
    public class MessagesController : Controller
    {
        private MessagesService messagesService;
        private MembersService membersService;
        private BadgeService badgeService;
        private readonly IHubContext<ChatHub> hubContext;

        public MessagesController(IHubContext<ChatHub> hubContext, MessagesService messagesService, MembersService membersService, BadgeService badgeService)
        {
            this.hubContext = hubContext;
            this.messagesService = messagesService;
            this.membersService = membersService;
            this.badgeService = badgeService;
        }

        [HttpGet]
        public async Task<IActionResult> Inbox()
        {
            var userId = membersService.GetUserId(HttpContext.User);
            var viewModels = await messagesService.GetInbox(userId);

            await SetBadges();

            return View(viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> StartChat(string receiverId, int productId)
        {
            var giverId = membersService.GetUserId(HttpContext.User);
            await messagesService.StartChat(productId, receiverId, giverId);
            await SetBadges();

            return RedirectToAction("Chat", new { productId });
        }

        [HttpGet]
        public async Task<IActionResult> Chat(int productId)
        {
            var userId = membersService.GetUserId(HttpContext.User);
            var viewModel = await messagesService.GetChat(productId, userId);
            if (viewModel == null)
                return RedirectToAction(nameof(Inbox));

            await SetBadges();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Chat(MessagesChatVM messagesChatVM)
        {
            if (!ModelState.IsValid)
                return View(messagesChatVM);

            return RedirectToAction(nameof(Chat));
        }
        //public async Task SendMessage(string user, string message)
        //{
        //    await hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
        private async Task SetBadges()
        {
            var userId = membersService.GetUserId(HttpContext.User);
            ViewBag.BadgeProducts = await badgeService.ProductCount(userId);
            ViewBag.BadgeCart = await badgeService.CartCount(userId);
            ViewBag.BadgeInbox = await badgeService.InboxCount(userId);
        }
    }
}