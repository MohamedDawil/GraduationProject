using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GeoAPI.Geometries;
using GraduationProject.Json;
using GraduationProject.Models.Entities;
using GraduationProject.Models.ViewModels;
using NetTopologySuite;
using Newtonsoft.Json;

namespace GraduationProject.Models
{
    public class GiversService
    {
        private FreshishContext context;

        public GiversService(FreshishContext context)
        {
            this.context = context;
        }

        public async Task CreateProductAsync(GiversAddProductVM giversAddProductVM)
        {
            await context.Product.AddAsync(new Product
            {
                Claimed = false,
                Collected = false,
                Description = giversAddProductVM.Description,
                ExpiryDate = giversAddProductVM.ExpiryDate,
                Freshness = giversAddProductVM.Freshness,
                Location = giversAddProductVM.Location,
                Name = giversAddProductVM.ProductName,
                PickUpDate1 = giversAddProductVM.PickUpDate1,
                PickUpDate2 = giversAddProductVM.PickUpDate2,
                Picture = giversAddProductVM.PictureFileName,
                PublishDate = DateTime.Now,
                GiverId = giversAddProductVM.GiverId
            });
            await context.SaveChangesAsync();
        }

        public async Task<IPoint> GetCoordinates(MyIdentityUser giver)
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            var http = new HttpClient();
            var url = string.Format($"https://maps.googleapis.com/maps/api/geocode/json?address={giver.Street}+{giver.ZipCode}+{giver.City}+Sweden&key=AIzaSyDtkrfI4kUln6UUZTJTvZvv3FC5wP624D4");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<JsonCoordinates>(result); // Convertor from string"result" to json
            return geometryFactory.CreatePoint(new Coordinate(json.results[0].geometry.location.lat, json.results[0].geometry.location.lng));
            //return new Tuple<IGeometry, IGeometry>
            //(
            //    json.results[0].geometry.location.lat,
            //    json.results[0].geometry.location.lng
            //);
        }
    }
}
