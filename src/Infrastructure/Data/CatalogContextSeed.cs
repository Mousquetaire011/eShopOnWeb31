using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!catalogContext.CatalogBrands.Any())
                {
                    catalogContext.CatalogBrands.AddRange(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.CatalogTypes.Any())
                {
                    catalogContext.CatalogTypes.AddRange(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.CatalogItems.Any())
                {
                    catalogContext.CatalogItems.AddRange(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
                if (!catalogContext.Suppliers.Any())
                {
                    catalogContext.Suppliers.AddRange(
                        GetPreconfiguredSuppliers());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.ProductSuppliers.Any())
                {
                    catalogContext.ProductSuppliers.AddRange(
                        GetPreconfiguredProductSuppliers());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.Stocks.Any())
                {
                    catalogContext.Stocks.AddRange(
                        GetPreconfiguredStocks());

                    await catalogContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand() { Brand = "Azure"},
                new CatalogBrand() { Brand = ".NET" },
                new CatalogBrand() { Brand = "Visual Studio" },
                new CatalogBrand() { Brand = "SQL Server" }, 
                new CatalogBrand() { Brand = "Other" }
            };
        }

        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() { Type = "Mug"},
                new CatalogType() { Type = "T-Shirt" },
                new CatalogType() { Type = "Sheet" },
                new CatalogType() { Type = "USB Memory Stick" }
            };
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>()
            {
                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=2, Description = ".NET Bot Black Sweatshirt", Name = ".NET Bot Black Sweatshirt", Price = 19.5M, PictureUri = "http://catalogbaseurltobereplaced/images/products/1.png" },
                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=2, Description = ".NET Black & White Mug", Name = ".NET Black & White Mug", Price= 8.50M, PictureUri = "http://catalogbaseurltobereplaced/images/products/2.png" },
                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=5, Description = "Prism White T-Shirt", Name = "Prism White T-Shirt", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/3.png" },
                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=2, Description = ".NET Foundation Sweatshirt", Name = ".NET Foundation Sweatshirt", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/4.png" },
                new CatalogItem() { CatalogTypeId=3,CatalogBrandId=5, Description = "Roslyn Red Sheet", Name = "Roslyn Red Sheet", Price = 8.5M, PictureUri = "http://catalogbaseurltobereplaced/images/products/5.png" },
                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=2, Description = ".NET Blue Sweatshirt", Name = ".NET Blue Sweatshirt", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/6.png" },
                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=5, Description = "Roslyn Red T-Shirt", Name = "Roslyn Red T-Shirt", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/7.png"  },
                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=5, Description = "Kudu Purple Sweatshirt", Name = "Kudu Purple Sweatshirt", Price = 8.5M, PictureUri = "http://catalogbaseurltobereplaced/images/products/8.png" },
                new CatalogItem() { CatalogTypeId=1,CatalogBrandId=5, Description = "Cup<T> White Mug", Name = "Cup<T> White Mug", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/9.png" },
                new CatalogItem() { CatalogTypeId=3,CatalogBrandId=2, Description = ".NET Foundation Sheet", Name = ".NET Foundation Sheet", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/10.png" },
                new CatalogItem() { CatalogTypeId=3,CatalogBrandId=2, Description = "Cup<T> Sheet", Name = "Cup<T> Sheet", Price = 8.5M, PictureUri = "http://catalogbaseurltobereplaced/images/products/11.png" },
                new CatalogItem() { CatalogTypeId=2,CatalogBrandId=5, Description = "Prism White TShirt", Name = "Prism White TShirt", Price = 12, PictureUri = "http://catalogbaseurltobereplaced/images/products/12.png" }
            };
        }

        static IEnumerable<Supplier> GetPreconfiguredSuppliers()
        {
            return new List<Supplier>()
            {
                new Supplier() { Name = "Supplier1"},
                new Supplier() { Name = "Supplier2"},
                new Supplier() { Name = "Supplier3"},
                new Supplier() { Name = "Supplier4"},
                new Supplier() { Name = "Supplier5"},
                new Supplier() { Name = "Supplier6"},
                new Supplier() { Name = "Supplier7"}

            };
        }

        static IEnumerable<ProductSupplier> GetPreconfiguredProductSuppliers()
        {
            return new List<ProductSupplier>()
            {
                new ProductSupplier() { CatalogID = 2, SupplierID=1 , Price=6.5m , Quantity=5},
                new ProductSupplier() { CatalogID = 2, SupplierID=2 , Price=7.5m , Quantity=5},
                new ProductSupplier() { CatalogID = 3, SupplierID=3 , Price=10 , Quantity=10},
                new ProductSupplier() { CatalogID = 4, SupplierID= 2, Price=9 , Quantity=10},
                new ProductSupplier() { CatalogID = 5, SupplierID= 4, Price= 6, Quantity=10},
                new ProductSupplier() { CatalogID = 6, SupplierID= 5, Price= 8, Quantity=6},
                new ProductSupplier() { CatalogID = 6, SupplierID= 3, Price= 10, Quantity=4},
                new ProductSupplier() { CatalogID = 7, SupplierID = 1 , Price = 6.5m , Quantity = 3},
                new ProductSupplier() { CatalogID = 8, SupplierID=6 , Price=5.5m , Quantity=10},
                new ProductSupplier() { CatalogID = 9, SupplierID=4 , Price=10 , Quantity=10},
                new ProductSupplier() { CatalogID = 10, SupplierID= 7, Price=9 , Quantity=10},
                new ProductSupplier() { CatalogID = 11, SupplierID= 7, Price= 6, Quantity=6},
                new ProductSupplier() { CatalogID = 11, SupplierID= 5, Price= 7, Quantity=4},
                new ProductSupplier() { CatalogID = 12, SupplierID= 6, Price= 10, Quantity=4}

            };
        }

        static IEnumerable<Stock> GetPreconfiguredStocks()
        {
            return new List<Stock>()
            {
                new Stock() { CatalogID= 2, Quantity = 10},
                new Stock() { CatalogID= 3, Quantity = 10},
                new Stock() { CatalogID= 4, Quantity = 10},
                new Stock() { CatalogID= 5, Quantity = 10},
                new Stock() { CatalogID= 6, Quantity = 10},
                new Stock() { CatalogID= 7, Quantity = 3},
                new Stock() { CatalogID= 8, Quantity = 10},
                new Stock() { CatalogID= 9, Quantity = 10},
                new Stock() { CatalogID= 10, Quantity = 10},
                new Stock() { CatalogID= 11, Quantity = 10},
                new Stock() { CatalogID= 12, Quantity = 4}

            };
        }

    }
}

