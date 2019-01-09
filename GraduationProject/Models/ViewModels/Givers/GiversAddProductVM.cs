using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class GiversAddProductVM
    {
        public string GiverId { get; set; }
        //[Required(ErrorMessage ="Vänligen lägg till en bild på din vara")]
        public string Picture { get; set; }

        [Required(ErrorMessage ="Vänligen ange varans namn")]
        public string ProductName { get; set; }

        [Required(ErrorMessage ="Vänligen ange varans skick")]
        public int Freshness { get; set; }

        public DateTime ExpiryDate { get; set; }
        
        [Required(ErrorMessage ="Vänligen ange en enkel beskrivning av din vara")]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Starttid måste anges")]
        public DateTime PickUpDate1 { get; set; }

        //[Required(ErrorMessage = "Sluttid måste anges")]
        public DateTime PickUpDate2 { get; set; }
        public string Scan { get; set; }
    }
}
