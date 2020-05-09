using EntityFrameworkCoreLab.Application.DataFactory.Amazon;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments;
using EntityFrameworkCoreLab.Persistence.Mappers.PopulateData;
using System.Linq;

namespace EntityFrameworkCoreLab.Application.Process
{
    public class FullPopulateDatabaseDataProcess
    {
        public void FullPopulateDatabaseWithFakeData()
        {
            var fullPopulateDatabaseDataMapper = new FullPopulateDatabaseDataMapper();
            var addresses = AddressDataFactory.Make(500);
            var products = ProductDataFactory.Make(1_500);
            var shippingRates = ShippingRateDataFactory.Make();
            var productsShippingRates = ProductShippingRateDataFactory.Make(1_500, shippingRates.Count());
            var dtoAmazonDatabaseData = new DTOAmazonDatabaseData() 
            {
                Adresses = addresses,
                Products = products,
                ShippingRates = shippingRates,
                ProductsShippingRates = productsShippingRates
            };

            fullPopulateDatabaseDataMapper.CleanDataOfAllTables();
            fullPopulateDatabaseDataMapper.FullPopulateDatabase(dtoAmazonDatabaseData);
        }
    }
}
