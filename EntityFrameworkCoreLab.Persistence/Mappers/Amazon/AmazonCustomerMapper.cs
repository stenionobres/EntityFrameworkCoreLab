using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using System;

namespace EntityFrameworkCoreLab.Persistence.Mappers
{
    public class AmazonCustomerMapper
    {
        public void Save(Customer customer)
        {
            try
            {
                using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
                {
                    amazonCodeFirstContext.Customers.Add(customer);
                    amazonCodeFirstContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
