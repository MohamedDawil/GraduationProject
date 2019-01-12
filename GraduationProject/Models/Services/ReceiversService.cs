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
            return await context.Product.Select(p => new ReceiversMapPositionVM
            {
                //FIXME: Shift due to strange behaviour
                Latitude = ((Point)p.Location).Y,
                Longitude = ((Point)p.Location).X,
                ProductName = p.Name
            }).ToArrayAsync();
        }

        public async Task<ReceiversMapProductVM[]> GetDistances(double lat, double lng)
        {
            var point = new Point(new Coordinate(lat, lng));
            point.SRID = 4326;
            return await context.Product.Select(p => new ReceiversMapProductVM
            {
                GiverCity = p.Giver.City,
                ProductDistance = Convert.ToInt32(Helper.Distance(point, (Point)p.Location)),
                ProductLatitude = ((Point)p.Location).X,
                ProductLongitude = ((Point)p.Location).Y
            }).ToArrayAsync();
        }
    }
}
