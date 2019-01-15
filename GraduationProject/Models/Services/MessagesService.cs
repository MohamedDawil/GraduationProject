using GraduationProject.Models.Entities;
using GraduationProject.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GraduationProject.Models.Services
{
    public class MessagesService
    {
        private FreshishContext context;
        public MessagesService(FreshishContext context)
        {
            this.context = context;
        }

        public async Task StartChat(int productId, string receiverId, string giverId)
        {
            await context.Chat.AddAsync(new Chat
            {
                GiverId = giverId,
                ReceiverId = receiverId,
                ProductId = productId,
                IsDeleted = false,
                IsServer = true,
                Message = "Startade en ny chatt",
                PublishDate = DateTime.Now
            });
            await context.SaveChangesAsync();
        }

        public async Task AddMessage(MessagesChatVM viewModel)
        {
            await context.Chat.AddAsync(new Chat
            {
                GiverId = viewModel.GiverId,
                IsDeleted = false,
                IsServer = false,
                Message = viewModel.SendMessage,
                ProductId = viewModel.ProductId,
                PublishDate = DateTime.Now,
                ReceiverId = viewModel.ReceiverId,
                SentById = viewModel.SentById
            });
            await context.SaveChangesAsync();
        }

        public async Task<MessagesInboxVM[]> GetInbox(string userId)
        {
            var conversations = await context.Chat.Where(c => c.GiverId == userId || c.ReceiverId == userId)
                .GroupBy(d => d.ProductId).ToArrayAsync();

            var viewModels = new List<MessagesInboxVM>();

            foreach (var group in conversations)
            {
                var viewModel = new MessagesInboxVM();

                viewModel.ProductId = group.Key;

                var chats = new List<Chat>();
                foreach (var chat in group)
                {
                    chats.Add(chat);
                }

                var newestChat = chats.OrderByDescending(c => c.PublishDate).First();
                viewModel.MemberName = (newestChat.SentBy != null) ? newestChat.SentBy.FirstName :  "Server";
                viewModel.ProductName = context.Product.SingleOrDefault(p => p.Id == group.Key).Name;
                viewModel.PublishDate = newestChat.PublishDate;

                viewModels.Add(viewModel);

            }
            return viewModels.ToArray(); 
        }

        public async Task<MessagesChatVM> GetChat(int productId, string userId)
        {
            var product = await context.Product.SingleOrDefaultAsync(p => p.Id == productId);
            return new MessagesChatVM
            {
                ProductName = product.Name,
                ProductId = product.Id,
                GiverId = product.GiverId,
                ReceiverId = product.ReceiverId,
                SentById = userId,
                Bubbles = await context.Chat.Select(c => new MessagesChatBubbleVM
                {
                    IsSent = c.SentById.Equals(userId),
                    MemberImage = c.SentBy.Picture,
                    MemberMessage = c.Message,
                    MemberName = c.SentBy.FirstName,
                    PublishDate = c.PublishDate
                }).ToArrayAsync()
            };
        }
    }
}
