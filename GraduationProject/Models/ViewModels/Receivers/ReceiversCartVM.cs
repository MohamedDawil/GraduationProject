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
        public decimal ProductGpsLatitude { get; set; }
        public decimal ProductGpsLongitude { get; set; }

    }
}
