using System;
using System.Collections.Generic;

namespace GraduationProject.Models.Entities
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            ChatGiver = new HashSet<Chat>();
            ChatReadBy = new HashSet<Chat>();
            ChatReceiver = new HashSet<Chat>();
            ChatSentBy = new HashSet<Chat>();
            ProductGiver = new HashSet<Product>();
            ProductReceiver = new HashSet<Product>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Chat> ChatGiver { get; set; }
        public virtual ICollection<Chat> ChatReadBy { get; set; }
        public virtual ICollection<Chat> ChatReceiver { get; set; }
        public virtual ICollection<Chat> ChatSentBy { get; set; }
        public virtual ICollection<Product> ProductGiver { get; set; }
        public virtual ICollection<Product> ProductReceiver { get; set; }
    }
}
