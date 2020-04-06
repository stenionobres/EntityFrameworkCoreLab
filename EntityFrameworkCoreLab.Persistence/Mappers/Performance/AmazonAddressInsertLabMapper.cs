using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using Microsoft.EntityFrameworkCore;

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
    }
}
