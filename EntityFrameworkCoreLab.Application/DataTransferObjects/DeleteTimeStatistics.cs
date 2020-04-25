using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreLab.Application.DataTransferObjects
{
    public class DeleteTimeStatistics
    {
        public double MillisecondsAverageBasedOnTenDeletesWithEmptyTable { get; set; }
        public double MillisecondsAverageBasedOnTenDeletesWithTableWithFiveThousandsRows { get; set; }
        public double MillisecondsAverageBasedOnTenDeletesWithTableWithTenThousandsRows { get; set; }
    }
}
