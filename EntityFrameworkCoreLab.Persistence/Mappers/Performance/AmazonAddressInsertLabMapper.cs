using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace EntityFrameworkCoreLab.Persistence.Mappers.Performance
{
    public class AmazonAddressInsertLabMapper
    {
        public void CleanAddressData()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                CleanAddressData(amazonCodeFirstContext);
            }
        }

        public void CleanAddressData(AmazonCodeFirstDbContext amazonCodeFirstContext)
        {
            amazonCodeFirstContext.Database.ExecuteSqlInterpolated($"delete from common.Address where Id > 3");
            amazonCodeFirstContext.Database.ExecuteSqlInterpolated($"DBCC CHECKIDENT ('common.Address', RESEED, 3)");
        }

        public long InsertAddressWithDbSet(Address address)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return InsertAddressWithDbSet(amazonCodeFirstContext, address);
            }
        }

        public long InsertAddressWithDbSetWithAddRange(IEnumerable<Address> addresses)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return InsertAddressWithDbSetWithAddRange(amazonCodeFirstContext, addresses);
            }
        }

        public long InsertAddressWithDbSet(AmazonCodeFirstDbContext amazonCodeFirstContext, Address address)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            amazonCodeFirstContext.Address.Add(address);
            amazonCodeFirstContext.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public long InsertAddressWithDbSetWithAddRange(AmazonCodeFirstDbContext amazonCodeFirstContext, IEnumerable<Address> addresses)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            amazonCodeFirstContext.Address.AddRange(addresses);
            amazonCodeFirstContext.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public long InsertAddressWithDbContext(Address address)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return InsertAddressWithDbContext(amazonCodeFirstContext, address);
            }
        }

        public long InsertAddressWithDbContextWithAddRange(IEnumerable<Address> addresses)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return InsertAddressWithDbContextWithAddRange(amazonCodeFirstContext, addresses);
            }
        }

        public long InsertAddressWithDbContext(AmazonCodeFirstDbContext amazonCodeFirstContext, Address address)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            amazonCodeFirstContext.Add(address);
            amazonCodeFirstContext.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public long InsertAddressWithDbContextWithAddRange(AmazonCodeFirstDbContext amazonCodeFirstContext, IEnumerable<Address> addresses)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            amazonCodeFirstContext.AddRange(addresses);
            amazonCodeFirstContext.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }
}
