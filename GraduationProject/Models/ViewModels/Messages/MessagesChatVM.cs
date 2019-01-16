using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class MessagesChatVM
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public string ReceiverId { get; set; }
        public string GiverId { get; set; }
        public string SentById { get; set; }
        [Required]
        public string SendMessage { get; set; }
        public MessagesChatBubbleVM[] Bubbles { get; set; }
    }
}
