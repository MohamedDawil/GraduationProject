using GraduationProject.Models.Services;
using GraduationProject.Models.ViewModels;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace GraduationProject.Hubs
{
    public class ChatHub : Hub
    {
        private MessagesService messagesService;
        public ChatHub(MessagesService messagesService)
        {
            this.messagesService = messagesService;
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
            await Clients.All.SendAsync("ReceiveMessage", productId, giverId, receiverId, sentById, sendMessage);
        }
    }
}