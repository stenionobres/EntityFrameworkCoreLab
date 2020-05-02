using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreLab.Persistence.Mappers.Transaction
{
    public class EbayTransactionLabMapper
    {
        public void CleanAddressData()
        {
            using (var ebayDatabaseFirstContext = new EbayDatabaseFirstDbContext())
            {
                ebayDatabaseFirstContext.Database.ExecuteSqlInterpolated($"delete from common.Address where Id > 3");
                ebayDatabaseFirstContext.Database.ExecuteSqlInterpolated($"DBCC CHECKIDENT ('common.Address', RESEED, 3)");
            }
        }

        public void CleanCustomerData()
        {
            using (var ebayDatabaseFirstContext = new EbayDatabaseFirstDbContext())
            {
                ebayDatabaseFirstContext.Database.ExecuteSqlInterpolated($"delete from common.Customer where Id > 5");
                ebayDatabaseFirstContext.Database.ExecuteSqlInterpolated($"DBCC CHECKIDENT ('common.Customer', RESEED, 5)");
            }
        }

        public void InsertAddressWithAddWithoutTransactionSaveChangesAfter(IEnumerable<Address> addresses)
        {
            using (var ebayDatabaseFirstContext = new EbayDatabaseFirstDbContext())
            {
                foreach (var address in addresses)
                {
                    InsertAddressWithAdd(ebayDatabaseFirstContext, address);
                }
                
                ebayDatabaseFirstContext.SaveChanges();
            }
        }

        public void InsertAddressWithAddWithoutTransactionSaveChangesBefore(IEnumerable<Address> addresses)
        {
            using (var ebayDatabaseFirstContext = new EbayDatabaseFirstDbContext())
            {
                foreach (var address in addresses)
                {
                    InsertAddressWithAdd(ebayDatabaseFirstContext, address);
                    ebayDatabaseFirstContext.SaveChanges();
                }
            }
        }

        public void InsertAddressWithAddRangeWithoutTransaction(IEnumerable<Address> addresses)
        {
            using (var ebayDatabaseFirstContext = new EbayDatabaseFirstDbContext())
            {
                ebayDatabaseFirstContext.Address.AddRange(addresses);
                ebayDatabaseFirstContext.SaveChanges();
            }
        }

        private void InsertAddressWithAdd(EbayDatabaseFirstDbContext ebayDatabaseFirstContext, Address address)
        {
            ebayDatabaseFirstContext.Address.Add(address);
        }
    }
}
