using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class GiversClaimedVM
    {
        public int ProductId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverId { get; set; }
        public DateTime ProductPickUpDate1 { get; set; }
        public DateTime ProductPickUpDate2 { get; set; }
    }
}
