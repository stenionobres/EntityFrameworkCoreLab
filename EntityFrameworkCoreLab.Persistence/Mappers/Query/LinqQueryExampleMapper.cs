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

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInLeftJoin()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from customer in amazonCodeFirstContext.Customer
                            join cart in amazonCodeFirstContext.Cart
                                on customer.Id equals cart.CustomerId into groupingCart
                            from cart in groupingCart.DefaultIfEmpty()
                            join address in amazonCodeFirstContext.Address
                                on customer.AddressId equals address.Id into groupingAddress
                            from address in groupingAddress.DefaultIfEmpty()
                            select new
                            {
                                customer, address, cart
                            };

                var data = query.ToList();

                return data.Select(d => d.customer).Distinct();
            }
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhere()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from customer in amazonCodeFirstContext.Customer
                            join cart in amazonCodeFirstContext.Cart
                                on customer.Id equals cart.CustomerId
                            join address in amazonCodeFirstContext.Address
                                on customer.AddressId equals address.Id
                            where customer.Id > 500
                            select new
                            {
                                customer, address, cart
                            };

                var data = query.ToList();

                return data.Select(d => d.customer).Distinct();
            }
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhereWithOperatorAND()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from customer in amazonCodeFirstContext.Customer
                            join cart in amazonCodeFirstContext.Cart
                                on customer.Id equals cart.CustomerId
                            join address in amazonCodeFirstContext.Address
                                on customer.AddressId equals address.Id
                            where customer.Id > 100 && cart.Id > 200 && address.Id > 120
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
