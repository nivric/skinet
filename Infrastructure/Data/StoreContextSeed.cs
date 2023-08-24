using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brands = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brandsJson = JsonSerializer.Deserialize<List<ProductBrand>>(brands);
                context.ProductBrands.AddRange(brandsJson);
            }

            if (!context.ProductTypes.Any())
            {
                var types = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var typesJson = JsonSerializer.Deserialize<List<ProductType>>(types);
                context.ProductTypes.AddRange(typesJson);
            }

            if (!context.Products.Any())
            {
                var products = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var productsJson = JsonSerializer.Deserialize<List<Product>>(products);
                context.Products.AddRange(productsJson);
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}