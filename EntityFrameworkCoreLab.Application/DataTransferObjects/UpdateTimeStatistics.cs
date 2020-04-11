
namespace EntityFrameworkCoreLab.Application.DataTransferObjects
{
    public class UpdateTimeStatistics
    {
        public double MillisecondsAverageBasedOnTenUpdatesWithEmptyTable { get; set; }
        public double MillisecondsAverageBasedOnTenUpdatesWithTableWithFiveThousandsRows { get; set; }
        public double MillisecondsAverageBasedOnTenUpdatesWithTableWithTenThousandsRows { get; set; }
        
    }
}
