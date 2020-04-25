using EntityFrameworkCoreLab.Application.DataTransferObjects;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using EntityFrameworkCoreLab.Persistence.Mappers.Performance;
using FizzWare.NBuilder;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCoreLab.Application.Process
{
    public class PerformanceDeleteLabProcess
    {
        private const int _tenRegisters = 10;

        public DeleteTimeStatistics GetDeleteTimeStatistics(bool useDbSetToSave)
        {
            var deleteTimeStatistics = new DeleteTimeStatistics();
            var rowsDeleted = 0;
            var fifteenThousandAddressWithoutId = MakeFifteenThousandAddress(generateIncrementalId: false);
            var fifteenThousandAddress = MakeFifteenThousandAddress(generateIncrementalId: true);
            var rowCutOffToEmptyTable = Faker.RandomNumber.Next(5, 100);
            var rowCutOffToTableWithFiveThousandRows = Faker.RandomNumber.Next(6_000, 9_000);
            var rowCutOffToTableWithTenThousandRows = Faker.RandomNumber.Next(11_000, 14_000);

            var tenUpdateTimes = new List<long>();
            var amazonAddressInsertLabMapper = new AmazonAddressInsertLabMapper();
            var amazonAddressDeleteLabMapper = new AmazonAddressDeleteLabMapper();


            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonAddressInsertLabMapper.CleanAddressData(amazonCodeFirstContext);
                amazonAddressInsertLabMapper.InsertAddressWithDbSetWithAddRange(fifteenThousandAddressWithoutId);

                foreach (var address in fifteenThousandAddress)
                {
                    var updateTime = useDbSetToSave
                                     ? amazonAddressDeleteLabMapper.DeleteAddressWithDbSet(amazonCodeFirstContext, address)
                                     : amazonAddressDeleteLabMapper.DeleteAddressWithDbContext(amazonCodeFirstContext, address);

                    rowsDeleted++;

                    if (IsRowToBeComputed(rowsDeleted, rowCutOffToEmptyTable))
                    {
                        tenUpdateTimes.Add(updateTime);

                        if (tenUpdateTimes.Count == _tenRegisters)
                        {
                            var deleteTimesAverage = Enumerable.Average(tenUpdateTimes);
                            deleteTimeStatistics.MillisecondsAverageBasedOnTenDeletesWithEmptyTable = deleteTimesAverage;
                            tenUpdateTimes.Clear();
                        }
                    }

                    if (IsRowToBeComputed(rowsDeleted, rowCutOffToTableWithFiveThousandRows))
                    {
                        tenUpdateTimes.Add(updateTime);

                        if (tenUpdateTimes.Count == _tenRegisters)
                        {
                            var deleteTimesAverage = Enumerable.Average(tenUpdateTimes);
                            deleteTimeStatistics.MillisecondsAverageBasedOnTenDeletesWithTableWithFiveThousandsRows = deleteTimesAverage;
                            tenUpdateTimes.Clear();
                        }
                    }

                    if (IsRowToBeComputed(rowsDeleted, rowCutOffToTableWithTenThousandRows))
                    {
                        tenUpdateTimes.Add(updateTime);

                        if (tenUpdateTimes.Count == _tenRegisters)
                        {
                            var deleteTimesAverage = Enumerable.Average(tenUpdateTimes);
                            deleteTimeStatistics.MillisecondsAverageBasedOnTenDeletesWithTableWithTenThousandsRows = deleteTimesAverage;
                            tenUpdateTimes.Clear();
                        }
                    }
                }
            }

            return deleteTimeStatistics;
        }

        public DeleteTimeStatistics GetDeleteTimeStatisticsWithDbContextRecycle(bool useDbSetToSave)
        {
            var deleteTimeStatistics = new DeleteTimeStatistics();
            var rowsDeleted = 0;
            var fifteenThousandAddressWithoutId = MakeFifteenThousandAddress(generateIncrementalId: false);
            var fifteenThousandAddress = MakeFifteenThousandAddress(generateIncrementalId: true);
            var rowCutOffToEmptyTable = Faker.RandomNumber.Next(5, 100);
            var rowCutOffToTableWithFiveThousandRows = Faker.RandomNumber.Next(6_000, 9_000);
            var rowCutOffToTableWithTenThousandRows = Faker.RandomNumber.Next(11_000, 14_000);

            var tenDeleteTimes = new List<long>();
            var amazonAddressInsertLabMapper = new AmazonAddressInsertLabMapper();
            var amazonAddressDeleteLabMapper = new AmazonAddressDeleteLabMapper();

            amazonAddressInsertLabMapper.CleanAddressData();
            amazonAddressInsertLabMapper.InsertAddressWithDbSetWithAddRange(fifteenThousandAddressWithoutId);

            foreach (var address in fifteenThousandAddress)
            {
                var deleteTime = useDbSetToSave
                                 ? amazonAddressDeleteLabMapper.DeleteAddressWithDbSet(address)
                                 : amazonAddressDeleteLabMapper.DeleteAddressWithDbContext(address);

                rowsDeleted++;

                if (IsRowToBeComputed(rowsDeleted, rowCutOffToEmptyTable))
                {
                    tenDeleteTimes.Add(deleteTime);

                    if (tenDeleteTimes.Count == _tenRegisters)
                    {
                        var deleteTimesAverage = Enumerable.Average(tenDeleteTimes);
                        deleteTimeStatistics.MillisecondsAverageBasedOnTenDeletesWithEmptyTable = deleteTimesAverage;
                        tenDeleteTimes.Clear();
                    }
                }

                if (IsRowToBeComputed(rowsDeleted, rowCutOffToTableWithFiveThousandRows))
                {
                    tenDeleteTimes.Add(deleteTime);

                    if (tenDeleteTimes.Count == _tenRegisters)
                    {
                        var deleteTimesAverage = Enumerable.Average(tenDeleteTimes);
                        deleteTimeStatistics.MillisecondsAverageBasedOnTenDeletesWithTableWithFiveThousandsRows = deleteTimesAverage;
                        tenDeleteTimes.Clear();
                    }
                }

                if (IsRowToBeComputed(rowsDeleted, rowCutOffToTableWithTenThousandRows))
                {
                    tenDeleteTimes.Add(deleteTime);

                    if (tenDeleteTimes.Count == _tenRegisters)
                    {
                        var deleteTimesAverage = Enumerable.Average(tenDeleteTimes);
                        deleteTimeStatistics.MillisecondsAverageBasedOnTenDeletesWithTableWithTenThousandsRows = deleteTimesAverage;
                        tenDeleteTimes.Clear();
                    }
                }
            }

            return deleteTimeStatistics;
        }

        private IEnumerable<Address> MakeFifteenThousandAddress(bool generateIncrementalId)
        {
            if (generateIncrementalId)
            {
                var generator = new SequentialGenerator<int>();

                generator.StartingWith(nextValueToGenerate: 4);

                return Builder<Address>.CreateListOfSize(15_000)
                                       .All()
                                       .With(a => a.Id = GetId(generator))
                                       .With(a => a.Street = GetStreet())
                                       .With(a => a.ZipPostCode = GetZipCode())
                                       .With(a => a.City = GetCity())
                                       .Build();
            }


            return Builder<Address>.CreateListOfSize(15_000)
                                   .All()
                                   .With(a => a.Id = 0)
                                   .With(a => a.Street = GetStreet())
                                   .With(a => a.ZipPostCode = GetZipCode())
                                   .With(a => a.City = GetCity())
                                   .Build();
        }

        private int GetId(SequentialGenerator<int> generator)
        {
            return generator.Generate();
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
