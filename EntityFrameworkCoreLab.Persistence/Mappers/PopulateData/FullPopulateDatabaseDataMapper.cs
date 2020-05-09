using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreLab.Persistence.Mappers.PopulateData
{
    public class FullPopulateDatabaseDataMapper
    {
        public void CleanDataOfAllTables()
        {
            using (var amazonCodeFirstDbContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstDbContext.Database.ExecuteSqlInterpolated($"delete from common.Address where Id > 3");
                amazonCodeFirstDbContext.Database.ExecuteSqlInterpolated($"DBCC CHECKIDENT ('common.Address', RESEED, 3)");

                amazonCodeFirstDbContext.Database.ExecuteSqlInterpolated($"delete from common.ShippingRate");
                amazonCodeFirstDbContext.Database.ExecuteSqlInterpolated($"DBCC CHECKIDENT ('common.ShippingRate', RESEED, 0)");

                // common.ProductShippingRate hasn't identity auto increment field
                amazonCodeFirstDbContext.Database.ExecuteSqlInterpolated($"delete from common.ProductShippingRate");

                // sales.CartProduct hasn't identity auto increment field
                amazonCodeFirstDbContext.Database.ExecuteSqlInterpolated($"delete from sales.CartProduct");

                // sales.Cart hasn't identity auto increment field
                amazonCodeFirstDbContext.Database.ExecuteSqlInterpolated($"delete from sales.Cart");

                amazonCodeFirstDbContext.Database.ExecuteSqlInterpolated($"delete from common.Product");
                amazonCodeFirstDbContext.Database.ExecuteSqlInterpolated($"DBCC CHECKIDENT ('common.Product', RESEED, 0)");

                amazonCodeFirstDbContext.Database.ExecuteSqlInterpolated($"delete from common.Customer where Id > 5");
                amazonCodeFirstDbContext.Database.ExecuteSqlInterpolated($"DBCC CHECKIDENT ('common.Customer', RESEED, 5)");
            }
        }

        public void FullPopulateDatabase(DTOAmazonDatabaseData amazonDatabaseData)
        {
            using (var amazonCodeFirstDbContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstDbContext.Address.AddRange(amazonDatabaseData.Adresses);
                amazonCodeFirstDbContext.Product.AddRange(amazonDatabaseData.Products);
                amazonCodeFirstDbContext.ShippingRate.AddRange(amazonDatabaseData.ShippingRates);

                amazonCodeFirstDbContext.SaveChanges();
            }

            using (var amazonCodeFirstDbContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstDbContext.ProductShippingRate.AddRange(amazonDatabaseData.ProductsShippingRates);
                
                amazonCodeFirstDbContext.SaveChanges();
            }
        }
    }
}
