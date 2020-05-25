﻿using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.Mappers.Query;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Application.Process
{
    public class LinqQueryExampleProcess
    {
        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInInnerJoin()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersWithAddressAndCartsBasedInInnerJoin();

            return customers;
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInLeftJoin()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersWithAddressAndCartsBasedInLeftJoin();

            return customers;
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhere()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersWithAddressAndCartsBasedInWhere();

            return customers;
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhereWithOperatorAND()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersWithAddressAndCartsBasedInWhereWithOperatorAND();

            return customers;
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhereWithOperatorOR()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersWithAddressAndCartsBasedInWhereWithOperatorOR();

            return customers;
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhereWithOperatorIN()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersWithAddressAndCartsBasedInWhereWithOperatorIN();

            return customers;
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhereWithOperatorNOTIN()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersWithAddressAndCartsBasedInWhereWithOperatorNOTIN();

            return customers;
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhereWithOperatorLIKE()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersWithAddressAndCartsBasedInWhereWithOperatorLIKE();

            return customers;
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInUnion()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersWithAddressAndCartsBasedInUnion();

            return customers;
        }

        public IEnumerable<string> GetCustomersNamesWithDistinct()
        {
            var customersNames = new LinqQueryExampleMapper().GetCustomersNamesWithDistinct();

            return customersNames;
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInWhereWithOperatorBETWEEN()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersWithAddressAndCartsBasedInWhereWithOperatorBETWEEN();

            return customers;
        }

        public IEnumerable<Customer> GetCustomersWithAddressAndCartsWithORDERBY()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersWithAddressAndCartsWithORDERBY();

            return customers;
        }

        public IEnumerable<KeyValuePair<int, int>> GetCustomersIdsAndCartsQuantityWithGROUPBY()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersIdsAndCartsQuantityWithGROUPBY();

            return customers;
        }

        public IEnumerable<KeyValuePair<int, int>> GetCustomersIdsAndCartsQuantityWithHAVING()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersIdsAndCartsQuantityWithHAVING();

            return customers;
        }

        public IEnumerable<KeyValuePair<int, DateTime>> GetCustomersIdsAndCartPurchaseDateWithGROUPBYMAX()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersIdsAndCartPurchaseDateWithGROUPBYMAX();

            return customers;
        }
    }
}
