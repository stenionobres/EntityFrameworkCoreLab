﻿using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments
{
    public class DTOAmazonDatabaseData
    {
        public IEnumerable<Address> Adresses { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ShippingRate> ShippingRates { get; set; }
        public IEnumerable<ProductShippingRate> ProductsShippingRates { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Cart> Carts { get; set; }
        public IEnumerable<CartProduct> CartProducts { get; set; }
    }
}
