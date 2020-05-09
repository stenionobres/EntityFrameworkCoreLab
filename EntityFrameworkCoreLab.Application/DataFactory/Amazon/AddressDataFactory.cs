using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using FizzWare.NBuilder;
using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Application.DataFactory.Amazon
{
    public class AddressDataFactory
    {
        public static IEnumerable<Address> Make(int quantity)
        {
            var address = Builder<Address>.CreateListOfSize(quantity)
                                          .All()
                                          .With(a => a.Id = 0)
                                          .With(a => a.Street = GetStreet())
                                          .With(a => a.ZipPostCode = GetZipCode())
                                          .With(a => a.City = GetCity())
                                          .Build();
            return address;
        }

        private static string GetStreet()
        {
            var street = Faker.Address.StreetAddress();

            if (street.Length > 20)
            {
                return street.Substring(0, 20);
            }

            return street;
        }

        private static string GetZipCode()
        {
            var zipCode = Faker.Address.ZipCode();

            if (zipCode.Length > 8)
            {
                return zipCode.Substring(0, 8);
            }

            return zipCode;
        }

        private static string GetCity()
        {
            var city = Faker.Address.City();

            if (city.Length > 20)
            {
                return city.Substring(0, 8);
            }

            return city;
        }
    }
}
