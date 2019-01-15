using GraduationProject.Models;
using GraduationProject.Models.Services;
using GraduationProject.Models.ViewModels;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace GraduationProject.Hubs
{
    public class ChatHub : Hub
    {
        private MessagesService messagesService;
        private MembersService membersService;
        public ChatHub(MessagesService messagesService, MembersService membersService)
        {
            this.messagesService = messagesService;
            this.membersService = membersService;
        }

        public async Task SendMessage(int productId, string giverId, string receiverId, string sentById, string sendMessage)
        {
            await messagesService.AddMessage(new MessagesChatVM {
                ProductId = productId,
                GiverId = giverId,
                ReceiverId = receiverId,
                SentById = sentById,
                SendMessage = sendMessage
            });
            var member = await membersService.GetUser(sentById);
            await Clients.All.SendAsync("ReceiveMessage", member.Picture, member.FirstName, DateTime.Now, sendMessage);
        }
    }
}