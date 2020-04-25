using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
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
    }
}
