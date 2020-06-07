using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay;

namespace EntityFrameworkCoreLab.Persistence.Mappers.Auditing
{
    public class EbayAddressAuditingMapper
    {
        public void CleanAddressData()
        {
            using (var ebayDatabaseFirstDbContext = new EbayDatabaseFirstDbContext())
            {
                ebayDatabaseFirstDbContext.Database.ExecuteSqlInterpolated($"delete from common.Address where Id > 3");
                ebayDatabaseFirstDbContext.Database.ExecuteSqlInterpolated($"DBCC CHECKIDENT ('common.Address', RESEED, 3)");
            }
        }

        public void InsertAddressesWithAuditing(IEnumerable<Address> addresses)
        {
            using (var ebayDatabaseFirstDbContext = new EbayDatabaseFirstDbContext())
            {
                ebayDatabaseFirstDbContext.Address.AddRange(addresses);
                ebayDatabaseFirstDbContext.SaveChanges();
            }
        }

        public void UpdateAddressesWithAuditing(IEnumerable<Address> addresses)
        {
            using (var ebayDatabaseFirstDbContext = new EbayDatabaseFirstDbContext())
            {
                ebayDatabaseFirstDbContext.Address.UpdateRange(addresses);
                ebayDatabaseFirstDbContext.SaveChanges();
            }
        }

        public void DeleteAddressesWithAuditing(IEnumerable<Address> addresses)
        {
            using (var ebayDatabaseFirstDbContext = new EbayDatabaseFirstDbContext())
            {
                ebayDatabaseFirstDbContext.Address.RemoveRange(addresses);
                ebayDatabaseFirstDbContext.SaveChanges();
            }
        }
    }
}
