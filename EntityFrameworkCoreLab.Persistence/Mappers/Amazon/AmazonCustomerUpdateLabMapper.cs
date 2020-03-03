using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using System.Linq;

namespace EntityFrameworkCoreLab.Persistence.Mappers.Amazon
{
    public class AmazonCustomerUpdateLabMapper
    {

        public void UpdateWithDbSet(Customer customer)
        {
            // EntityState Modified — The entity exists in the database and has been modified on the client. SaveChanges updates it.
            // update all columns in database

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                // if id of Entity is 0, the EntityState will be Added and data will inserted in database

                amazonCodeFirstContext.Customer.Update(customer);
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void UpdateWithDbContext(Customer customer)
        {
            // EntityState Modified — The entity exists in the database and has been modified on the client. SaveChanges updates it.
            // update all columns in database

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                // if id of Entity is 0, the EntityState will be Added and data will inserted in database

                amazonCodeFirstContext.Update(customer);
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void UpdateNameWithDbSet(int customerId, string newCustomerName)
        {
            // EntityState Modified — The entity exists in the database and has been modified on the client. SaveChanges updates it.
            // update only the name column

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var customer = amazonCodeFirstContext.Customer.FirstOrDefault(c => c.Id.Equals(customerId));
                customer.Name = newCustomerName;
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void UpdateNameWithoutQueryDatabase(int customerId, string newCustomerName)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var customer = new Customer() { Id = customerId, Name = newCustomerName };
                amazonCodeFirstContext.Entry(customer).Property(p => p.Name).IsModified = true;
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void TryUpdateWithDbSetWithStateUnchanged(Customer customer)
        {
            // EntityState Unchanged — The entity exists in the database and hasn’t been modified on the client. SaveChanges ignores it. 

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Customer.Update(customer);
                amazonCodeFirstContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void TryUpdateWithDbContextWithStateUnchanged(Customer customer)
        {
            // EntityState Unchanged — The entity exists in the database and hasn’t been modified on the client. SaveChanges ignores it.

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Update(customer);
                amazonCodeFirstContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void TryUpdateWithDbSetWithStateDetached(Customer customer)
        {
            // EntityState Detached — The entity you provided isn’t tracked. SaveChanges doesn’t see it.

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Customer.Update(customer);
                amazonCodeFirstContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void TryUpdateWithDbContextWithStateDetached(Customer customer)
        {
            // EntityState Detached — The entity you provided isn’t tracked. SaveChanges doesn’t see it.

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Update(customer);
                amazonCodeFirstContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                amazonCodeFirstContext.SaveChanges();
            }
        }

    }
}
