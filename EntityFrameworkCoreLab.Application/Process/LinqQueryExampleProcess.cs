using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.Mappers.Query;
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
    }
}
