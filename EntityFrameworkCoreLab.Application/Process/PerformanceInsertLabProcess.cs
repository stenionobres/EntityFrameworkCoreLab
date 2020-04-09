using EntityFrameworkCoreLab.Application.DataTransferObjects;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using EntityFrameworkCoreLab.Persistence.Mappers.Performance;
using FizzWare.NBuilder;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCoreLab.Application.Process
{
    public class PerformanceInsertLabProcess
    {
        private const int _tenRegisters = 10;

        public InsertTimeStatistics GetInsertTimeStatistics(bool useDbSetToSave)
        {
            var insertTimeStatistics = new InsertTimeStatistics();
            var rowsInserted = 0;
            var fifteenThousandAddress = MakeFifteenThousandAddress();
            var rowCutOffToEmptyTable = Faker.RandomNumber.Next(5, 100);
            var rowCutOffToTableWithFiveThousandRows = Faker.RandomNumber.Next(6_000, 9_000);
            var rowCutOffToTableWithTenThousandRows = Faker.RandomNumber.Next(11_000, 14_000);
            
            var tenInsertTimes = new List<long>();
            var amazonAddressInsertLabMapper = new AmazonAddressInsertLabMapper();

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonAddressInsertLabMapper.CleanAddressData(amazonCodeFirstContext);

                foreach (var address in fifteenThousandAddress)
                {
                    var insertTime = useDbSetToSave
                                     ? amazonAddressInsertLabMapper.InsertAddressWithDbSet(amazonCodeFirstContext, address)
                                     : amazonAddressInsertLabMapper.InsertAddressWithDbContext(amazonCodeFirstContext, address);

                    rowsInserted++;

                    if (IsRowToBeComputed(rowsInserted, rowCutOffToEmptyTable))
                    {
                        tenInsertTimes.Add(insertTime);

                        if (tenInsertTimes.Count == _tenRegisters)
                        {
                            var insertTimesAverage = Enumerable.Average(tenInsertTimes);
                            insertTimeStatistics.MillisecondsAverageBasedOnTenInsertsWithEmptyTable = insertTimesAverage;
                            tenInsertTimes.Clear();
                        }
                    }

                    if (IsRowToBeComputed(rowsInserted, rowCutOffToTableWithFiveThousandRows))
                    {
                        tenInsertTimes.Add(insertTime);

                        if (tenInsertTimes.Count == _tenRegisters)
                        {
                            var insertTimesAverage = Enumerable.Average(tenInsertTimes);
                            insertTimeStatistics.MillisecondsAverageBasedOnTenInsertsWithTableWithFiveThousandsRows = insertTimesAverage;
                            tenInsertTimes.Clear();
                        }
                    }

                    if (IsRowToBeComputed(rowsInserted, rowCutOffToTableWithTenThousandRows))
                    {
                        tenInsertTimes.Add(insertTime);

                        if (tenInsertTimes.Count == _tenRegisters)
                        {
                            var insertTimesAverage = Enumerable.Average(tenInsertTimes);
                            insertTimeStatistics.MillisecondsAverageBasedOnTenInsertsWithTableWithTenThousandsRows = insertTimesAverage;
                            tenInsertTimes.Clear();
                        }
                    }
                    
                }
            }

            return insertTimeStatistics;
        }

        public InsertTimeStatistics GetInsertTimeStatisticsWithDbContextRecycle(bool useDbSetToSave)
        {
            var insertTimeStatistics = new InsertTimeStatistics();
            var rowsInserted = 0;
            var fifteenThousandAddress = MakeFifteenThousandAddress();
            var rowCutOffToEmptyTable = Faker.RandomNumber.Next(5, 100);
            var rowCutOffToTableWithFiveThousandRows = Faker.RandomNumber.Next(6_000, 9_000);
            var rowCutOffToTableWithTenThousandRows = Faker.RandomNumber.Next(11_000, 14_000);

            var tenInsertTimes = new List<long>();
            var amazonAddressInsertLabMapper = new AmazonAddressInsertLabMapper();

            amazonAddressInsertLabMapper.CleanAddressData();

            foreach (var address in fifteenThousandAddress)
            {
                var insertTime = useDbSetToSave
                                 ? amazonAddressInsertLabMapper.InsertAddressWithDbSet(address)
                                 : amazonAddressInsertLabMapper.InsertAddressWithDbContext(address);

                rowsInserted++;

                if (IsRowToBeComputed(rowsInserted, rowCutOffToEmptyTable))
                {
                    tenInsertTimes.Add(insertTime);

                    if (tenInsertTimes.Count == _tenRegisters)
                    {
                        var insertTimesAverage = Enumerable.Average(tenInsertTimes);
                        insertTimeStatistics.MillisecondsAverageBasedOnTenInsertsWithEmptyTable = insertTimesAverage;
                        tenInsertTimes.Clear();
                    }
                }

                if (IsRowToBeComputed(rowsInserted, rowCutOffToTableWithFiveThousandRows))
                {
                    tenInsertTimes.Add(insertTime);

                    if (tenInsertTimes.Count == _tenRegisters)
                    {
                        var insertTimesAverage = Enumerable.Average(tenInsertTimes);
                        insertTimeStatistics.MillisecondsAverageBasedOnTenInsertsWithTableWithFiveThousandsRows = insertTimesAverage;
                        tenInsertTimes.Clear();
                    }
                }

                if (IsRowToBeComputed(rowsInserted, rowCutOffToTableWithTenThousandRows))
                {
                    tenInsertTimes.Add(insertTime);

                    if (tenInsertTimes.Count == _tenRegisters)
                    {
                        var insertTimesAverage = Enumerable.Average(tenInsertTimes);
                        insertTimeStatistics.MillisecondsAverageBasedOnTenInsertsWithTableWithTenThousandsRows = insertTimesAverage;
                        tenInsertTimes.Clear();
                    }
                }

            }
            

            return insertTimeStatistics;
        }

        public decimal GetInsertTimeStatisticsAddRange(bool useDbSetToSave)
        {
            var fifteenThousandAddress = MakeFifteenThousandAddress();
            var amazonAddressInsertLabMapper = new AmazonAddressInsertLabMapper();

            amazonAddressInsertLabMapper.CleanAddressData();

            var insertTimeAllRecords = useDbSetToSave
                                       ? amazonAddressInsertLabMapper.InsertAddressWithDbSetWithAddRange(fifteenThousandAddress)
                                       : amazonAddressInsertLabMapper.InsertAddressWithDbContextWithAddRange(fifteenThousandAddress);

            var insertTime = decimal.Divide(insertTimeAllRecords, fifteenThousandAddress.Count());

            return insertTime;
        }

        public decimal GetInsertTimeStatisticsAddRangeWithDbContextRecycle(bool useDbSetToSave)
        {
            var amazonAddressInsertLabMapper = new AmazonAddressInsertLabMapper();
            var fiveThousandInsertTimes = new List<decimal>();
            
            amazonAddressInsertLabMapper.CleanAddressData();

            for (int i = 0; i < 3; i++)
            {
                var fiveThousandAddress = MakeFiveThousandAddress();

                using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
                {
                    var fiveThousandInsertTime = useDbSetToSave
                                                ? amazonAddressInsertLabMapper.InsertAddressWithDbSetWithAddRange(amazonCodeFirstContext, fiveThousandAddress)
                                                : amazonAddressInsertLabMapper.InsertAddressWithDbContextWithAddRange(amazonCodeFirstContext, fiveThousandAddress);

                    fiveThousandInsertTimes.Add(fiveThousandInsertTime);
                }
            }

            var fiveThousandInsertTimeAverage = Enumerable.Average(fiveThousandInsertTimes);
            var insertTime = decimal.Divide(fiveThousandInsertTimeAverage, 5_000);

            return insertTime;
        }

        private IEnumerable<Address> MakeFifteenThousandAddress()
        {
            var address = Builder<Address>.CreateListOfSize(15_000)
                                          .All()
                                          .With(a => a.Id = 0)
                                          .With(a => a.Street = GetStreet())
                                          .With(a => a.ZipPostCode = GetZipCode())
                                          .With(a => a.City = GetCity())
                                          .Build();
            return address;
        }

        private IEnumerable<Address> MakeFiveThousandAddress()
        {
            var address = Builder<Address>.CreateListOfSize(5_000)
                                          .All()
                                          .With(a => a.Id = 0)
                                          .With(a => a.Street = GetStreet())
                                          .With(a => a.ZipPostCode = GetZipCode())
                                          .With(a => a.City = GetCity())
                                          .Build();
            return address;
        }

        private string GetStreet()
        {
            var street = Faker.Address.StreetAddress();
            
            if (street.Length > 20)
            {
                return street.Substring(0, 20);
            }

            return street;
        }

        private string GetZipCode()
        {
            var zipCode = Faker.Address.ZipCode();

            if (zipCode.Length > 8)
            {
                return zipCode.Substring(0, 8);
            }

            return zipCode;
        }

        private string GetCity()
        {
            var city = Faker.Address.City();

            if (city.Length > 20)
            {
                return city.Substring(0, 8);
            }

            return city;
        }

        private bool IsRowToBeComputed(int rowNumberInserted, int rowCutOff)
        {
            return rowNumberInserted >= rowCutOff && rowNumberInserted <= rowCutOff + _tenRegisters;
        }
    }
}
