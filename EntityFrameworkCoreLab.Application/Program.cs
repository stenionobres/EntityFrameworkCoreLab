using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.Mappers.Amazon;
using EntityFrameworkCoreLab.Persistence.Mappers.Ebay;
using EbayCustomer = EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay.Customer;

namespace EntityFrameworkCoreLab.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var useAmazon = true;

            if (useAmazon)
            {
                var customer = new Customer() { Name = "Customer 01" };
                new AmazonCustomerMapper().Save(customer);
            }
            else
            {
                var ebayCustomer = new EbayCustomer() { Name = "Customer 03" };
                new EbayCustomerMapper().Save(ebayCustomer);
            }
            
        }
    }
}
