using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class MessagesChatBubbleVM
    {
        public bool IsSent { get; set; }
        public string MemberImage { get; set; }
        public string MemberMessage { get; set; }
        public string MemberName { get; set; }
        public DateTime PublishDate { get; set; }  
    }
}
