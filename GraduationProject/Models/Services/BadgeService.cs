using GraduationProject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models
{
    public class BadgeService
    {
        private FreshishContext context;

        public BadgeService(FreshishContext context)
        {
            this.context = context;
        }

        public async Task<int> ProductCount(string giverId)
        {
            var products = await context.Product.Where(p => p.GiverId == giverId).ToArrayAsync();
            return products.Count();
        }
        public async Task<int> CartCount(string receiverId)
        {
            var products = await context.Product.Where(p => p.ReceiverId == receiverId).ToArrayAsync();
            return products.Count();
        }
        public async Task<int> InboxCount(string userId)
        {
            var chats = await context.Chat.Where(p => p.ReceiverId == userId || p.GiverId == userId).ToArrayAsync();
            return chats.Count();
        }
    }
}
