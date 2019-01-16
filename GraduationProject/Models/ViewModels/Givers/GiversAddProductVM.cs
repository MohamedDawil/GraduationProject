using GeoAPI.Geometries;
using Microsoft.AspNetCore.Http;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class GiversAddProductVM
    {
        public IGeometry Location { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public string GiverId { get; set; }
        //[Required(ErrorMessage ="Vänligen lägg till en bild på din vara")]
        public IFormFile Picture { get; set; }

        public string PictureFileName { get; set; }

        [Required(ErrorMessage ="Vänligen ange varans namn")]
        [Display(Name = "Produkt namn")]
        public string ProductName { get; set; }

        [Required(ErrorMessage ="Vänligen ange varans skick")]
        [Display(Name ="Fräschhet")]
        public int Freshness { get; set; }

        [Display(Name = "Utgångsdatum")]
        public DateTime ExpiryDate { get; set; }
        
        [Required(ErrorMessage ="Vänligen ange en enkel beskrivning av din vara")]
        [Display(Name = "Produkt beskrivning")]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Starttid måste anges")]
        [Display(Name = "Hämtningsdatum 1")]
        public DateTime PickUpDate1 { get; set; }

        //[Required(ErrorMessage = "Sluttid måste anges")]
        [Display(Name = "Hämtningsdatum 2")]
        public DateTime PickUpDate2 { get; set; }
        public string Scan { get; set; }
    }
}
