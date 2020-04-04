using EntityFrameworkCoreLab.Application.DataTransferObjects;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using FizzWare.NBuilder;
using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Application.Process
{
    public class PerformanceInsertLabProcess
    {
        public InsertTimeStatistics GetInsertTimeStatistics()
        {
            var insertTimeStatistics = new InsertTimeStatistics();
            var address = MakeFifteenThousandAddress();

            return insertTimeStatistics;
        }

        private IEnumerable<Address> MakeFifteenThousandAddress()
        {
            var address = Builder<Address>.CreateListOfSize(15_000)
                                          .All()
                                          .With(a => a.Id = 0)
                                          .With(a => a.Street = GetStreet())
                                          .With(a => a.ZipPostCode = GetZipCode())
                                          .With(a => a.City = Faker.Address.City())
                                          .Build();
            return address;
        }

        private string GetStreet()
        {
            var street = Faker.Address.StreetAddress();
            
            if (street.Length > 20)
            {
                return street.Substring(0, 20);
            }

            return street;
        }

        private string GetZipCode()
        {
            var zipCode = Faker.Address.ZipCode();

            if (zipCode.Length > 8)
            {
                return zipCode.Substring(0, 8);
            }

            return zipCode;
        }
    }
}
