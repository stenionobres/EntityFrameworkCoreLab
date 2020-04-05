
namespace EntityFrameworkCoreLab.Application.DataTransferObjects
{
    public class InsertTimeStatistics
    {
        public double MillisecondsAverageBasedOnTenInsertsWithEmptyTable { get; set; }
        public double MillisecondsAverageBasedOnTenInsertsWithTableWithFiveThousandsRows { get; set; }
        public double MillisecondsAverageBasedOnTenInsertsWithTableWithTenThousandsRows { get; set; }
        
    }
}
