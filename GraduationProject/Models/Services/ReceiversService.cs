using GeoAPI.Geometries;
using GraduationProject.Helpers;
using GraduationProject.Models.Entities;
using GraduationProject.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Models
{
    public class ReceiversService
    {
        private FreshishContext context;

        public ReceiversService(FreshishContext context)
        {
            this.context = context;
        }

        public async Task<ReceiversMapPositionVM[]> GetPositions()
        {
            return await context.Product.Where(q => q.IsDeleted != 1 && q.Claimed == false).Select(p => new ReceiversMapPositionVM
            {
                //FIXME: Shift due to strange behaviour
                Latitude = ((Point)p.Location).Y,
                Longitude = ((Point)p.Location).X,
                ProductName = p.Name,
            }).ToArrayAsync();
        }

        public async Task<ReceiversMapProductVM[]> GetDistances(double lat, double lng)
        {
            var point = new Point(new Coordinate(lat, lng));
            point.SRID = 4326;
            return await context.Product.Where(p=>p.Claimed == false && p.IsDeleted != 1).Select(p => new ReceiversMapProductVM
            {
                ProductId = p.Id,
                ProductImage = p.Picture,
                ProductName = p.Name,
                ProductPickUpDate1 = p.PickUpDate1,
                ProductPickUpDate2= p.PickUpDate2,  
                ProductDescription = p.Description,
                ProductFreshness = p.Freshness,
                ProductExpiryDate = p.ExpiryDate,
                ProductLatitude = ((Point)p.Location).X,
                ProductLongitude = ((Point)p.Location).Y,
                ProductClaimed = p.Claimed,
                GiverName = $"{p.Giver.FirstName} {p.Giver.LastName}",
                GiverCity = p.City,
                GiverStreet = p.Street,
                GiverZipCode = p.ZipCode,
                ProductDistance = Convert.ToInt32(Helper.Distance(point, (Point)p.Location)),
            }).OrderBy(p => p.ProductDistance).ToArrayAsync();
        }

        public async Task<bool> ClaimProduct(int productId, string receiverId)
        {
            var product = await context.Product.SingleOrDefaultAsync(p => p.Id == productId);
            if (product == null)
                return false;

            product.Claimed = true;
            product.ReceiverId = receiverId;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<ReceiversCartVM[]> GetCart(string receiverId, double lat, double lng)
        {
            var point = new Point(new Coordinate(lat, lng));
            point.SRID = 4326;
            return await context.Product.Where(r => r.ReceiverId == receiverId).Select(p => new ReceiversCartVM
            {
                ProductId = p.Id,
                ProductImage = p.Picture,
                ProductName = p.Name,
                ProductPickUpDate1 = p.PickUpDate1,
                ProductPickUpDate2 = p.PickUpDate2,
                ProductDescription = p.Description,
                ProductFreshness = p.Freshness,
                ProductExpiryDate = p.ExpiryDate,
                ProductLatitude = ((Point)p.Location).X,
                ProductLongitude = ((Point)p.Location).Y,
                ProductClaimed = p.Claimed,
                HasChat = p.Chat.Count != 0,
                GiverId = p.GiverId,
                GiverName = p.Giver.FirstName,
                GiverCity = p.City,
                GiverStreet = p.Street,
                GiverZipCode = p.ZipCode,
                ProductDistance = Convert.ToInt32(Helper.Distance(point, (Point)p.Location)),
            }).OrderBy(p => p.ProductDistance).ToArrayAsync();
        }
       
        public async Task<bool> UnclaimProduct(int productId, string receiverId)
        {
            var product = await context.Product.SingleOrDefaultAsync(p => p.Id == productId);
            if (product == null)
                return false;

            product.Claimed = false;
            product.ReceiverId = null;
            await context.SaveChangesAsync();
            return true;
        }
    }
}
