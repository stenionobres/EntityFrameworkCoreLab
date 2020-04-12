﻿using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using System.Collections.Generic;
using System.Diagnostics;

namespace EntityFrameworkCoreLab.Persistence.Mappers.Performance
{
    public class AmazonAddressUpdateLabMapper
    {
        public long UpdateAddressWithDbSet(Address address)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return UpdateAddressWithDbSet(amazonCodeFirstContext, address);
            }
        }

        public long UpdateAddressWithDbContext(Address address)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return UpdateAddressWithDbContext(amazonCodeFirstContext, address);
            }
        }

        public long UpdateAddressWithDbSetWithAddRange(IEnumerable<Address> address)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return UpdateAddressWithDbSetWithAddRange(amazonCodeFirstContext, address);
            }
        }

        public long UpdateAddressWithDbContextWithAddRange(IEnumerable<Address> address)
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return UpdateAddressWithDbContextWithAddRange(amazonCodeFirstContext, address);
            }
        }

        public long UpdateAddressWithDbSet(AmazonCodeFirstDbContext amazonCodeFirstContext, Address address)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            amazonCodeFirstContext.Address.Update(address);
            amazonCodeFirstContext.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public long UpdateAddressWithDbContext(AmazonCodeFirstDbContext amazonCodeFirstContext, Address address)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            amazonCodeFirstContext.Update(address);
            amazonCodeFirstContext.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public long UpdateAddressWithDbSetWithAddRange(AmazonCodeFirstDbContext amazonCodeFirstContext, IEnumerable<Address> address)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            amazonCodeFirstContext.Address.UpdateRange(address);
            amazonCodeFirstContext.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }

        public long UpdateAddressWithDbContextWithAddRange(AmazonCodeFirstDbContext amazonCodeFirstContext, IEnumerable<Address> address)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            amazonCodeFirstContext.UpdateRange(address);
            amazonCodeFirstContext.SaveChanges();

            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }
}
