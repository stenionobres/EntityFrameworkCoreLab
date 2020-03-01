using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreLab.Persistence.Mappers.Amazon
{
    public class AmazonCustomerDeleteLabMapper
    {
        public void DeleteWithDbSet(Customer customer)
        {
            // EntityState Deleted — The entity exists in the database but should be deleted. SaveChanges deletes it.

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Customers.Remove(customer);
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void DeleteWithDbContext(Customer customer)
        {
            // EntityState Deleted — The entity exists in the database but should be deleted. SaveChanges deletes it.

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Remove(customer);
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void TryDeleteWithDbSetWithStateUnchanged(Customer customer)
        {
            // EntityState Unchanged — The entity exists in the database and hasn’t been modified on the client. SaveChanges ignores it. 

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Customers.Remove(customer);
                amazonCodeFirstContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void TryDeleteWithDbContextWithStateUnchanged(Customer customer)
        {
            // EntityState Unchanged — The entity exists in the database and hasn’t been modified on the client. SaveChanges ignores it. 

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Remove(customer);
                amazonCodeFirstContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void TryDeleteWithDbSetWithStateDetached(Customer customer)
        {
            // EntityState Detached — The entity you provided isn’t tracked. SaveChanges doesn’t see it.

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Customers.Remove(customer);
                amazonCodeFirstContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                amazonCodeFirstContext.SaveChanges();
            }
        }

        public void TryDeleteWithDbContextWithStateDetached(Customer customer)
        {
            // EntityState Detached — The entity you provided isn’t tracked. SaveChanges doesn’t see it.

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonCodeFirstContext.Remove(customer);
                amazonCodeFirstContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                amazonCodeFirstContext.SaveChanges();
            }
        }
    }
}
