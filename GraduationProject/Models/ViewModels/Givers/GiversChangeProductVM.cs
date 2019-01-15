using GeoAPI.Geometries;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models.ViewModels
{
    public class GiversChangeProductVM
    {
        public IGeometry Location { get; set; }
        public IFormFile Picture { get; set; }
        public string PictureFileName { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Freshness { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Description { get; set; }
        public DateTime PickUpDate1 { get; set; }
        public DateTime PickUpDate2 { get; set; }
        public string Scan { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string GiverId { get; set; }
    }
}
