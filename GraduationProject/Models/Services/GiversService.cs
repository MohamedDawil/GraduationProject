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
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
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
                Street = giversAddProductVM.Street,
                City = giversAddProductVM.City,
                ZipCode = giversAddProductVM.ZipCode,
                Name = giversAddProductVM.ProductName,
                PickUpDate1 = giversAddProductVM.PickUpDate1,
                PickUpDate2 = giversAddProductVM.PickUpDate2,
                Picture = giversAddProductVM.PictureFileName,
                PublishDate = DateTime.Now,
                GiverId = giversAddProductVM.GiverId
            });
            await context.SaveChangesAsync();

        }

        public async Task<Point> GetCoordinates(MyIdentityUser giver)
        {
            var http = new HttpClient();
            var url = string.Format($"https://maps.googleapis.com/maps/api/geocode/json?" +
                $"address={giver.Street}+{giver.ZipCode}+{giver.City}+Sweden&key=AIzaSyDtkrfI4kUln6UUZTJTvZvv3FC5wP624D4");
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<JsonCoordinates>(result); // Convertor from string"result" to json
            var point = new Point(new Coordinate((double)json.results[0].geometry.location.lat, 
                (double)json.results[0].geometry.location.lng));
            point.SRID = 4326;
            return point;
        }

        public async Task<GiversChangeProductVM> GetProduct(int productId)
        {
            var product = await context.Product.SingleOrDefaultAsync(p => p.Id == productId);
            return new GiversChangeProductVM
            {
                Description = product.Description,
                ExpiryDate = product.ExpiryDate,
                Freshness = product.Freshness,
                PictureFileName = product.Picture,
                PickUpDate1 = product.PickUpDate1,
                PickUpDate2 = product.PickUpDate2,
                ProductName = product.Name,
                ProductId = product.Id
            };
        }

        public async Task<GiversClaimedVM[]> GetClaimed(string giverId)
        {
            return await context.Product
                .Where(p => p.Claimed == true && p.GiverId == giverId)
                .Select(p => new GiversClaimedVM
                {
                    ProductId = p.Id,
                    ProductImage = p.Picture,
                    ProductName = p.Name,
                    ReceiverName = $"{p.Receiver.FirstName} {p.Receiver.LastName}",
                    ReceiverId = p.ReceiverId,
                    ProductPickUpDate1 = p.PickUpDate1,
                    ProductPickUpDate2 = p.PickUpDate2
                }).ToArrayAsync();
        }

        public async Task<GiversClaimedVM[]> GetUnclaimed(string giverId)
        {
            return await context.Product
                .Where(p => p.Claimed == false && p.GiverId == giverId)
                .Select(p => new GiversClaimedVM
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductImage = p.Picture,
                    ProductPickUpDate1 = p.PickUpDate1,
                    ProductPickUpDate2 = p.PickUpDate2
                }).ToArrayAsync();
        }

        public async Task DeleteProduct(int productId, string giverId)
        {
            var product = await context.Product.SingleOrDefaultAsync(p => p.Id == productId && p.GiverId == giverId);
            if (product != null)
            {
                context.Product.Remove(product);
                await context.SaveChangesAsync();
            }
        }

        public async Task ChangeProductAsync(GiversChangeProductVM giversChangeProductVM)
        {
            var product = await context.Product.SingleOrDefaultAsync(p => p.Id == giversChangeProductVM.ProductId);
            product.Description = giversChangeProductVM.Description;
            product.ExpiryDate = giversChangeProductVM.ExpiryDate;
            product.Freshness = giversChangeProductVM.Freshness;
            product.Location = giversChangeProductVM.Location;
            product.Street = giversChangeProductVM.Street;
            product.City = giversChangeProductVM.City;
            product.ZipCode = giversChangeProductVM.ZipCode;
            product.Name = giversChangeProductVM.ProductName;
            product.PickUpDate1 = giversChangeProductVM.PickUpDate1;
            product.PickUpDate2 = giversChangeProductVM.PickUpDate2;
            product.Picture = giversChangeProductVM.PictureFileName;
            product.PublishDate = DateTime.Now;

            await context.SaveChangesAsync();
        }
    }
}
