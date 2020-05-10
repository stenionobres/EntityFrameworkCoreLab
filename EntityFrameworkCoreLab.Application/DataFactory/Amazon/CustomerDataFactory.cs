using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using FizzWare.NBuilder;
using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Application.DataFactory.Amazon
{
    public class CustomerDataFactory
    {
        public static IEnumerable<Customer> Make(int quantity)
        {
            const int nextUnusedAddressIdInDatabase = 4;
            var generator = new SequentialGenerator<int>();

            generator.StartingWith(nextValueToGenerate: nextUnusedAddressIdInDatabase);

            var customers = Builder<Customer>.CreateListOfSize(quantity)
                                             .All()
                                             .With(a => a.Id = 0)
                                             .With(a => a.Name = Faker.Name.FullName())
                                             .With(a => a.Birthday = Faker.Identification.DateOfBirth())
                                             .With(a => a.Email = Faker.Internet.Email())
                                             .With(a => a.Cpf = GetCpf())
                                             .With(a => a.AddressId = generator.Generate())
                                             .Build();

            return customers;
        }

        private static string GetCpf()
        {
            var random = new RandomGenerator();
            var cpf = random.Next(10000000000, 99999999999);

            return $"{cpf}";
        }
    }
}
