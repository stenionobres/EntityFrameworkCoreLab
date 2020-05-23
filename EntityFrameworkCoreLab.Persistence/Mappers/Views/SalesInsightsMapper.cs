using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCoreLab.Persistence.Mappers.Views
{
    public class SalesInsightsMapper
    {
        public IEnumerable<SalesInsights> GetSalesInsights()
        {
            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                return amazonCodeFirstContext.SalesInsights.ToList();
            }
        }
    }
}
