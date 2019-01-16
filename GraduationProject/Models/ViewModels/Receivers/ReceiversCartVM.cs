using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class ReceiversCartVM
    {
        public int ProductId { get; set; }
        public int GiverId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        [Display(Name ="Beskrivning")]
        public string ProductDescription { get; set; }
        [Display(Name = "Utgångsdatum")]
        public DateTime ProductExpiryDate { get; set; }
        [Display(Name = "Hämttid")]
        public DateTime ProductPickUpDate1 { get; set; }
        public DateTime ProductPickUpDate2 { get; set; }
        public double ProductLatitude { get; set; }
        public double ProductLongitude { get; set; }
        public int ProductFreshness { get; set; }
        public bool ProductClaimed { get; set; }
        public string GiverName { get; set; }
        public string GiverCity { get; set; }
        public string GiverStreet { get; set; }
        public string GiverZipCode { get; set; }
        public int ProductDistance { get; set; }
    }
}
