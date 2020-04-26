using EFCore.BulkExtensions;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EntityFrameworkCoreLab.Persistence.Mappers.Performance
{
    public class AmazonAddressDeleteLabMapper
    {
        public long DeleteAddressWithDbSet(Address address)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return DeleteAddressWithDbSet(amazonCodeFirstContext, address);
            }
        }

        public long DeleteAddressWithDbContext(Address address)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return DeleteAddressWithDbContext(amazonCodeFirstContext, address);
            }
        }

        public long DeleteAddressWithDbSetWithAddRange(IEnumerable<Address> address)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return DeleteAddressWithDbSetWithAddRange(amazonCodeFirstContext, address);
            }
        }

        public long DeleteAddressWithDbContextWithAddRange(IEnumerable<Address> address)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return DeleteAddressWithDbContextWithAddRange(amazonCodeFirstContext, address);
            }
        }

        public long DeleteAddressWithExecuteSqlInterpolated(Address address)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return DeleteAddressWithExecuteSqlInterpolated(amazonCodeFirstContext, address);
            }
        }

        public long DeleteAddressWithBulkOperation(IList<Address> addresses)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                var stopwatch = new Stopwatch();

                stopwatch.Start();

                amazonCodeFirstContext.BulkDelete(addresses);

                stopwatch.Stop();

                return stopwatch.ElapsedMilliseconds;
            }
        }

        public long DeleteAddressWithDbSet(AmazonCodeFirstDbContext amazonCodeFirstContext, Address address)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            amazonCodeFirstContext.Address.Remove(address);
            amazonCodeFirstContext.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public long DeleteAddressWithDbContext(AmazonCodeFirstDbContext amazonCodeFirstContext, Address address)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            amazonCodeFirstContext.Remove(address);
            amazonCodeFirstContext.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public long DeleteAddressWithDbSetWithAddRange(AmazonCodeFirstDbContext amazonCodeFirstContext, IEnumerable<Address> address)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            amazonCodeFirstContext.Address.RemoveRange(address);
            amazonCodeFirstContext.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public long DeleteAddressWithDbContextWithAddRange(AmazonCodeFirstDbContext amazonCodeFirstContext, IEnumerable<Address> address)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            amazonCodeFirstContext.RemoveRange(address);
            amazonCodeFirstContext.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public long DeleteAddressWithExecuteSqlInterpolated(AmazonCodeFirstDbContext amazonCodeFirstContext, Address address)
        {
            var deleteAddressSql = GetDeleteAddressSql(address);
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            amazonCodeFirstContext.Database.ExecuteSqlInterpolated(deleteAddressSql);

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        private FormattableString GetDeleteAddressSql(Address address)
        {
            return $@"delete from common.Address where Id={address.Id}";
        }
    }
}
