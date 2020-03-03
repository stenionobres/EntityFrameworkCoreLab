using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreLab.Persistence.Mappers.Ebay
{
    public class EbayCustomerMapper
    {
        public void Save(Customer customer)
        {
            try
            {
                using (var ebayDatabaseFirstContext = new EbayDatabaseFirstDbContext())
                {
                    ebayDatabaseFirstContext.Customer.Add(customer);
                    ebayDatabaseFirstContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
