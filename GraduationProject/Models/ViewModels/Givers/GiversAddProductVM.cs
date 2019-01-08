using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class GiversAddProductVM
    {
        public string Image { get; set; }
        public string ProductName { get; set; }
        public int Freshness { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Description { get; set; }
        public DateTime PickUpDate1 { get; set; }
        public DateTime PickUpDate2 { get; set; }
        public string Scan { get; set; }
    }
}
