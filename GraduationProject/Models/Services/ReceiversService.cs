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
                Latitude = ((Point)p.Location).X,
                Longitude = ((Point)p.Location).Y,
                ProductName = p.Name
            }).ToArrayAsync();
        }
    }
}
