using System;
using System.Collections.Generic;

namespace GraduationProject.Models.Entities
{
    public partial class Chat
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string GiverId { get; set; }
        public string ReceiverId { get; set; }
        public int ProductId { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsServer { get; set; }
        public bool IsDeleted { get; set; }
        public string SentById { get; set; }
        public string ReadById { get; set; }

        public virtual AspNetUsers Giver { get; set; }
        public virtual Product Product { get; set; }
        public virtual AspNetUsers ReadBy { get; set; }
        public virtual AspNetUsers Receiver { get; set; }
        public virtual AspNetUsers SentBy { get; set; }
    }
}
