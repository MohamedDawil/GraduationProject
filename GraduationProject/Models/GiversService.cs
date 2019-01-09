using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Models.Entities;
using GraduationProject.Models.ViewModels;

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
                Latitude = "59.403311",
                Longitude = "17.9442849",
                Name = giversAddProductVM.ProductName,
                PickUpDate1 = giversAddProductVM.PickUpDate1,
                PickUpDate2 = giversAddProductVM.PickUpDate2,
                Picture = giversAddProductVM.Picture,
                PublishDate = DateTime.Now,
                GiverId = giversAddProductVM.GiverId
            });
            await context.SaveChangesAsync();
        }
    }
}
