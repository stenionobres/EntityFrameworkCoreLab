﻿using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCoreLab.Persistence.Mappers.Query
{
    public class LinqQueryExampleMapper
    {
        public IEnumerable<Customer> GetCustomersWithAddressExemplifyingOneToOneRelationship()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from customer in amazonCodeFirstContext.Customer
                            join address in amazonCodeFirstContext.Address
                                on customer.AddressId equals address.Id
                            select new
                            {
                                customer, address
                            };

                var data = query.ToList();

                return data.Select(d => d.customer);
            }
        }

        public IEnumerable<Cart> GetCartsWithProductsExemplifyingOneToManyRelationship()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from cart in amazonCodeFirstContext.Cart
                            join cartProduct in amazonCodeFirstContext.CartProduct
                                on cart.Id equals cartProduct.CartId
                            join product in amazonCodeFirstContext.Product
                                on cartProduct.ProductId equals product.Id
                            select new
                            {
                                cart, cartProduct, product
                            };

                var data = query.ToList();

                return data.Select(d => d.cart).Distinct();
            }
        }

        public IEnumerable<ProductShippingRate> GetProductsWithShippingRatesExemplifyingManyToManyRelationship()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from productShippingRate in amazonCodeFirstContext.ProductShippingRate
                            join product in amazonCodeFirstContext.Product
                                on productShippingRate.ProductId equals product.Id
                            join shippingRate in amazonCodeFirstContext.ShippingRate
                                on productShippingRate.ShippingRateId equals shippingRate.Id
                            select new
                            {
                                product, productShippingRate, shippingRate
                            };

                var data = query.ToList();

                return data.Select(d => d.productShippingRate);
            }
        }

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

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhereWithOperatorOR()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from customer in amazonCodeFirstContext.Customer
                            join cart in amazonCodeFirstContext.Cart
                                on customer.Id equals cart.CustomerId
                            join address in amazonCodeFirstContext.Address
                                on customer.AddressId equals address.Id
                            where customer.Id == 100 || customer.Id == 250 || customer.Id > 500
                            select new
                            {
                                customer, address, cart
                            };

                var data = query.ToList();

                return data.Select(d => d.customer).Distinct();
            }
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhereWithOperatorIN()
        {
            var customerIds = new List<int>() { 100, 250, 300, 310, 400 };

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from customer in amazonCodeFirstContext.Customer
                            join cart in amazonCodeFirstContext.Cart
                                on customer.Id equals cart.CustomerId
                            join address in amazonCodeFirstContext.Address
                                on customer.AddressId equals address.Id
                            where customerIds.Contains(customer.Id)
                            select new
                            {
                                customer, address, cart
                            };

                var data = query.ToList();

                return data.Select(d => d.customer).Distinct();
            }
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhereWithOperatorNOTIN()
        {
            var customerIds = new List<int>() { 100, 250, 300, 310, 400 };

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from customer in amazonCodeFirstContext.Customer
                            join cart in amazonCodeFirstContext.Cart
                                on customer.Id equals cart.CustomerId
                            join address in amazonCodeFirstContext.Address
                                on customer.AddressId equals address.Id
                            where customerIds.Contains(customer.Id) == false
                            select new
                            {
                                customer, address, cart
                            };

                var data = query.ToList();

                return data.Select(d => d.customer).Distinct();
            }
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhereWithOperatorLIKE()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from customer in amazonCodeFirstContext.Customer
                            join cart in amazonCodeFirstContext.Cart
                                on customer.Id equals cart.CustomerId
                            join address in amazonCodeFirstContext.Address
                                on customer.AddressId equals address.Id
                            where customer.Name.StartsWith("Sta") || customer.Name.Contains("wel") || customer.Name.EndsWith("nes")
                            select new
                            {
                                customer, address, cart
                            };

                var data = query.ToList();

                return data.Select(d => d.customer).Distinct();
            }
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInUnion()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = (from customer in amazonCodeFirstContext.Customer
                             join cart in amazonCodeFirstContext.Cart
                                 on customer.Id equals cart.CustomerId
                             join address in amazonCodeFirstContext.Address
                                 on customer.AddressId equals address.Id
                             where customer.Id <= 100
                             select new { customer, address, cart }
                            ).Union(from customer in amazonCodeFirstContext.Customer
                                    join cart in amazonCodeFirstContext.Cart
                                        on customer.Id equals cart.CustomerId
                                    join address in amazonCodeFirstContext.Address
                                        on customer.AddressId equals address.Id
                                    where customer.Id > 100
                                    select new { customer, address, cart });

                var data = query.ToList();

                return data.Select(d => d.customer).Distinct();
            }
        }

        public IEnumerable<string> GetCustomersNamesWithDistinct()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = (from customer in amazonCodeFirstContext.Customer
                             join cart in amazonCodeFirstContext.Cart
                                 on customer.Id equals cart.CustomerId
                             join address in amazonCodeFirstContext.Address
                                 on customer.AddressId equals address.Id
                             select new { customer.Name }).Distinct();

                var data = query.ToList();

                return data.Select(d => d.Name);
            }
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhereWithOperatorBETWEEN()
        {
            var startDate = new DateTime(2020, 03, 01);
            var endDate = new DateTime(2020, 04, 30);

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from customer in amazonCodeFirstContext.Customer
                            join cart in amazonCodeFirstContext.Cart
                                on customer.Id equals cart.CustomerId
                            join address in amazonCodeFirstContext.Address
                                on customer.AddressId equals address.Id
                            where cart.PurchaseDate >= startDate && cart.PurchaseDate <= endDate
                            select new
                            {
                                customer, address, cart
                            };

                var data = query.ToList();

                return data.Select(d => d.customer).Distinct();
            }
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsWithORDERBY()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from customer in amazonCodeFirstContext.Customer
                            join cart in amazonCodeFirstContext.Cart
                                on customer.Id equals cart.CustomerId
                            join address in amazonCodeFirstContext.Address
                                on customer.AddressId equals address.Id
                            orderby customer.Id, cart.Id
                            select new
                            {
                                customer, address, cart
                            };

                var data = query.ToList();

                return data.Select(d => d.customer).Distinct();
            }
        }

        public IEnumerable<KeyValuePair<int, int>> GetCustomersIdsAndCartsQuantityWithGROUPBY()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from customer in amazonCodeFirstContext.Customer
                            join cart in amazonCodeFirstContext.Cart
                                on customer.Id equals cart.CustomerId
                            join address in amazonCodeFirstContext.Address
                                on customer.AddressId equals address.Id
                            group customer by customer.Id into groupingCustomer
                            select new KeyValuePair<int, int>
                            (
                                groupingCustomer.Key, 
                                groupingCustomer.Count()
                            );

                var data = query.ToList();

                return data;
            }
        }

        public IEnumerable<KeyValuePair<int, int>> GetCustomersIdsAndCartsQuantityWithHAVING()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from customer in amazonCodeFirstContext.Customer
                            join cart in amazonCodeFirstContext.Cart
                                on customer.Id equals cart.CustomerId
                            join address in amazonCodeFirstContext.Address
                                on customer.AddressId equals address.Id
                            group customer by customer.Id into groupingCustomer
                            where groupingCustomer.Count() > 100
                            select new KeyValuePair<int, int>
                            (
                                groupingCustomer.Key,
                                groupingCustomer.Count()
                            );

                var data = query.ToList();

                return data;
            }
        }

        public IEnumerable<KeyValuePair<int, DateTime>> GetCustomersIdsAndCartPurchaseDateWithGROUPBYMAX()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from cart in amazonCodeFirstContext.Cart
                            group cart by cart.CustomerId into groupingCart
                            select new KeyValuePair<int, DateTime>
                            (
                                groupingCart.Key,
                                groupingCart.Max(g => g.PurchaseDate)
                            );

                var data = query.ToList();

                return data;
            }
        }

        public int GetCustomerIdWithMAX()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query =  from customer in amazonCodeFirstContext.Customer
                             join cart in amazonCodeFirstContext.Cart
                                 on customer.Id equals cart.CustomerId
                             join address in amazonCodeFirstContext.Address
                                 on customer.AddressId equals address.Id
                             select new 
                             { 
                                 customer, address, cart 
                             };

                var data = query.Max(x => x.customer.Id);

                return data;
            }
        }

        public IEnumerable<KeyValuePair<int, DateTime>> GetCustomersIdsAndCartPurchaseDateWithGROUPBYMIN()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from cart in amazonCodeFirstContext.Cart
                            group cart by cart.CustomerId into groupingCart
                            select new KeyValuePair<int, DateTime>
                            (
                                groupingCart.Key,
                                groupingCart.Min(g => g.PurchaseDate)
                            );

                var data = query.ToList();

                return data;
            }
        }

        public int GetCustomerIdWithMIN()
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

                var data = query.Min(x => x.customer.Id);

                return data;
            }
        }

        public IEnumerable<KeyValuePair<int, decimal>> GetCartIdsAndQuantityItemsWithGROUPBYAVG()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from cart in amazonCodeFirstContext.Cart
                            join cartProduct in amazonCodeFirstContext.CartProduct
                                on cart.Id equals cartProduct.CartId
                            group cartProduct by cartProduct.CartId into groupingCartProduct
                            select new KeyValuePair<int, decimal>
                            (
                                groupingCartProduct.Key,
                                (decimal)groupingCartProduct.Average(g => g.Quantity)
                            );

                var data = query.ToList();

                return data;
            }
        }

        public decimal GetQuantityItemsWithAVG()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from cartProduct in amazonCodeFirstContext.CartProduct
                            select cartProduct;

                var data = query.Average(x => x.Quantity);

                return (decimal)data;
            }
        }

        public IEnumerable<KeyValuePair<int, int>> GetCartIdsAndQuantityItemsWithGROUPBYSUM()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from cart in amazonCodeFirstContext.Cart
                            join cartProduct in amazonCodeFirstContext.CartProduct
                                on cart.Id equals cartProduct.CartId
                            group cartProduct by cartProduct.CartId into groupingCartProduct
                            select new KeyValuePair<int, int>
                            (
                                groupingCartProduct.Key,
                                groupingCartProduct.Sum(g => g.Quantity)
                            );

                var data = query.ToList();

                return data;
            }
        }

        public int GetQuantityItemsWithSUM()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from cartProduct in amazonCodeFirstContext.CartProduct
                            select cartProduct;

                var data = query.Sum(x => x.Quantity);

                return data;
            }
        }

        public int GetCartsQuantityWithCOUNT()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var query = from cart in amazonCodeFirstContext.Cart
                            select cart;

                var data = query.Count();

                return data;
            }
        }
    }
}
