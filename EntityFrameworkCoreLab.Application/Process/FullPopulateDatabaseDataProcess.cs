using EntityFrameworkCoreLab.Application.DataFactory.Amazon;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments;
using EntityFrameworkCoreLab.Persistence.Mappers.PopulateData;

namespace EntityFrameworkCoreLab.Application.Process
{
    public class FullPopulateDatabaseDataProcess
    {
        public void FullPopulateDatabaseWithFakeData()
        {
            var fullPopulateDatabaseDataMapper = new FullPopulateDatabaseDataMapper();
            var addresses = AddressDataFactory.Make(500);
            var products = ProductDataFactory.Make(1_500);
            var dtoAmazonDatabaseData = new DTOAmazonDatabaseData() 
            {
                Adresses = addresses,
                Products = products
            };

            fullPopulateDatabaseDataMapper.CleanDataOfAllTables();
            fullPopulateDatabaseDataMapper.FullPopulateDatabase(dtoAmazonDatabaseData);
        }
    }
}
