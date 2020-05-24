using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCoreLab.Persistence.Mappers.Query
{
    public class LinqQueryExampleMapper
    {
        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInInnerJoin()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from customer in amazonCodeFirstContext.Customer
                            join cart in amazonCodeFirstContext.Cart
                                on customer.Id equals cart.CustomerId
                            join address in amazonCodeFirstContext.Address
                                on customer.AddressId equals address.Id
                            select new
                            {
                                customer, address, cart
                            };

                var data = query.ToList();

                return data.Select(d => d.customer).Distinct();
            }
        }
    }
}
