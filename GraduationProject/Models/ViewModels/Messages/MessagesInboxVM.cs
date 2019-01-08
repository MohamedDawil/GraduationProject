using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class MessagesInboxVM
    {
        public string ProductName { get; set; }
        public string MemberName { get; set; }
        public DateTime PublishDate { get; set; }
        public int ProductId { get; set; }
    }
}
