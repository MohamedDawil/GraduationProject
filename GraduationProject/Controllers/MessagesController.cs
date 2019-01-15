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
        private readonly IHubContext<ChatHub> hubContext;

        public MessagesController(IHubContext<ChatHub> hubContext, MessagesService messagesService, MembersService membersService)
        {
            this.hubContext = hubContext;
            this.messagesService = messagesService;
            this.membersService = membersService;
        }

        [HttpGet]
        public async Task<IActionResult> Inbox()
        {
            var userId = membersService.GetUserId(HttpContext.User);
            var viewModels = await messagesService.GetInbox(userId);
            return View(viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> StartChat(string receiverId, int productId)
        {
            var giverId = membersService.GetUserId(HttpContext.User);
            await messagesService.StartChat(productId, receiverId, giverId);
            return RedirectToAction("Chat", new { productId });
        }

        [HttpGet]
        public async Task<IActionResult> Chat(int productId)
        {
            var userId = membersService.GetUserId(HttpContext.User);
            var viewModel = await messagesService.GetChat(productId, userId);
            if (viewModel == null)
                return RedirectToAction(nameof(Inbox));
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Chat(MessagesChatVM messagesChatVM)
        {
            if (!ModelState.IsValid)
                return View(messagesChatVM);

            return RedirectToAction(nameof(Chat));
        }
        public async Task SendMessage(string user, string message)
        {
            await hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}