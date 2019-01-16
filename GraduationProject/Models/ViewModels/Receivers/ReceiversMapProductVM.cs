using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class ReceiversMapProductVM
    {
        public string ProductName { get; set; }
        public double ProductLongitude { get; set; }
        public double ProductLatitude { get; set; }
        public int ProductDistance { get; set; }
        public string ProductImage { get; set; }
        public bool ProductClaimed { get; set; }
        public DateTime ProductPickUpDate1 { get; set; }
        public DateTime ProductPickUpDate2 { get; set; }
        public int ProductFreshness { get; set; }
        public DateTime ProductExpiryDate { get; set; }
        public string ProductDescription { get; set; }
        public string GiverName { get; set; }
        public string GiverStreet { get; set; }
        public string GiverZipCode { get; set; }
        public string GiverCity{ get; set; }
        public int ProductId { get; set; }
    }
}
 