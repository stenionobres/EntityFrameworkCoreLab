using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreLab.Application.DataFactory.Amazon
{
    public class CartDataFactory
    {
        public static IEnumerable<Cart> Make(int quantityOfCarts, int quantityOfCustomers)
        {
            var generator = new SequentialGenerator<int>();

            generator.StartingWith(nextValueToGenerate: 10_000);

            var carts = Builder<Cart>.CreateListOfSize(quantityOfCarts)
                                     .All()
                                     .With(a => a.Id = generator.Generate())
                                     .With(a => a.PurchaseDate = GetPurchaseDate())
                                     .With(a => a.CustomerId = GetCustomerId(quantityOfCustomers))
                                     .Build();

            return carts;
        }
        
        private static DateTime GetPurchaseDate()
        {
            var random = new RandomGenerator();
            var minDate = new DateTime(2020, 1, 1);
            var maxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var purchaseDate = random.Next(minDate, maxDate);

            return purchaseDate;
        }

        private static int GetCustomerId(int quantityOfCustomers)
        {
            var random = new RandomGenerator();
            const int nextUnusedCustomerIdInDatabase = 6;
            var maxCustomerId = (quantityOfCustomers + 6) - 1;
            var customerId = random.Next(min: nextUnusedCustomerIdInDatabase, max: maxCustomerId);

            return customerId;
        }
    }
}
