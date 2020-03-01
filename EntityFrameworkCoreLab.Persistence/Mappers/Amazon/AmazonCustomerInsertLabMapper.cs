using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;

namespace EntityFrameworkCoreLab.Persistence.Mappers.Amazon
{
    public class AmazonCustomerInsertLabMapper
    {
        public void SaveWithDbSet(Customer customer)
        {
            // EntityState Added — The entity doesn’t yet exist in the database. SaveChanges inserts it.

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Customers.Add(customer);
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void SaveWithDbContext(Customer customer)
        {
            // EntityState Added — The entity doesn’t yet exist in the database. SaveChanges inserts it.

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Add(customer);
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void TrySaveWithStateUnchanged(Customer customer)
        {
            // EntityState Unchanged — The entity exists in the database and hasn’t been modified on the client. SaveChanges ignores it. 

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Add(customer);
                // required set id to avoid exception below 
                // Either set a permanent value explicitly or ensure that the database is configured to generate values for this property.
                customer.Id = 1;
                amazonCodeFirstContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void TrySaveWithStateDetached(Customer customer)
        {
            // EntityState Detached — The entity you provided isn’t tracked. SaveChanges doesn’t see it.

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Add(customer);
                amazonCodeFirstContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                amazonCodeFirstContext.SaveChanges();
            }
        }
    }
}
