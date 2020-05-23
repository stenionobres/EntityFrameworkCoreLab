using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.Mappers.Views;
using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Application.Process
{
    public class SalesInsightsProcess
    {
        public IEnumerable<SalesInsights> GetSalesInsights()
        {
            var salesInsights = new SalesInsightsMapper().GetSalesInsights();

            return salesInsights;
        }
    }
}
