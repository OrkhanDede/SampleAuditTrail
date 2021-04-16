    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    using AuditTrail.Entities;
    using Microsoft.EntityFrameworkCore;

    namespace AuditTrail
{
    public class InitializeData
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            context.Database.Migrate();
            context.Database.EnsureCreated();
            FakeData fakeDatas = new FakeData();
            var companies = fakeDatas.CreateProducts();
            await context.Products.AddRangeAsync(companies);
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
    public class FakeData
    {
        public List<Product> CreateProducts()
        {
            var pList = new List<Product>();
            for (int i = 0; i < 100; i++)
            {
                pList.Add(new Product()
                {
                    Title = $"Title {i}",
                    Description =$"Description {i}",
                    Price = (i+1)*100
                });
            }
            return pList;
        }
    }
}
