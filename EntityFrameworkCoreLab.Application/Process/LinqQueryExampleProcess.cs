using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.Mappers.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreLab.Application.Process
{
    public class LinqQueryExampleProcess
    {
        public IEnumerable<Customer> GetCustomersWithAddressAndCartsBasedInInnerJoin()
        {
            var customers = new LinqQueryExampleMapper().GetCustomersWithAddressAndCartsBasedInInnerJoin();

            return customers;
        }
    }
}
