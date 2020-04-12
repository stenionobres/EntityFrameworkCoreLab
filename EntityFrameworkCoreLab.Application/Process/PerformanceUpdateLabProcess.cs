using EntityFrameworkCoreLab.Application.DataTransferObjects;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using EntityFrameworkCoreLab.Persistence.Mappers.Performance;
using FizzWare.NBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkCoreLab.Application.Process
{
    public class PerformanceUpdateLabProcess
    {
        private const int _tenRegisters = 10;

        public UpdateTimeStatistics GetUpdateTimeStatistics(bool useDbSetToSave)
        {
            var updateTimeStatistics = new UpdateTimeStatistics();
            var rowsUpdated = 0;
            var fifteenThousandAddressWithoutId = MakeFifteenThousandAddress(generateIncrementalId: false);
            var fifteenThousandAddress = MakeFifteenThousandAddress(generateIncrementalId: true);
            var rowCutOffToEmptyTable = Faker.RandomNumber.Next(5, 100);
            var rowCutOffToTableWithFiveThousandRows = Faker.RandomNumber.Next(6_000, 9_000);
            var rowCutOffToTableWithTenThousandRows = Faker.RandomNumber.Next(11_000, 14_000);

            var tenUpdateTimes = new List<long>();
            var amazonAddressInsertLabMapper = new AmazonAddressInsertLabMapper();
            var amazonAddressUpdateLabMapper = new AmazonAddressUpdateLabMapper();

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonAddressInsertLabMapper.CleanAddressData(amazonCodeFirstContext);
                amazonAddressInsertLabMapper.InsertAddressWithDbSetWithAddRange(fifteenThousandAddressWithoutId);

                foreach (var address in fifteenThousandAddress)
                {
                    address.Street = "Updated Street";

                    var updateTime = useDbSetToSave
                                     ? amazonAddressUpdateLabMapper.UpdateAddressWithDbSet(amazonCodeFirstContext, address)
                                     : amazonAddressUpdateLabMapper.UpdateAddressWithDbContext(amazonCodeFirstContext, address);

                    rowsUpdated++;

                    if (IsRowToBeComputed(rowsUpdated, rowCutOffToEmptyTable))
                    {
                        tenUpdateTimes.Add(updateTime);

                        if (tenUpdateTimes.Count == _tenRegisters)
                        {
                            var updateTimesAverage = Enumerable.Average(tenUpdateTimes);
                            updateTimeStatistics.MillisecondsAverageBasedOnTenUpdatesWithEmptyTable = updateTimesAverage;
                            tenUpdateTimes.Clear();
                        }
                    }

                    if (IsRowToBeComputed(rowsUpdated, rowCutOffToTableWithFiveThousandRows))
                    {
                        tenUpdateTimes.Add(updateTime);

                        if (tenUpdateTimes.Count == _tenRegisters)
                        {
                            var updateTimesAverage = Enumerable.Average(tenUpdateTimes);
                            updateTimeStatistics.MillisecondsAverageBasedOnTenUpdatesWithTableWithFiveThousandsRows = updateTimesAverage;
                            tenUpdateTimes.Clear();
                        }
                    }

                    if (IsRowToBeComputed(rowsUpdated, rowCutOffToTableWithTenThousandRows))
                    {
                        tenUpdateTimes.Add(updateTime);

                        if (tenUpdateTimes.Count == _tenRegisters)
                        {
                            var updateTimesAverage = Enumerable.Average(tenUpdateTimes);
                            updateTimeStatistics.MillisecondsAverageBasedOnTenUpdatesWithTableWithTenThousandsRows = updateTimesAverage;
                            tenUpdateTimes.Clear();
                        }
                    }

                }
            }

            return updateTimeStatistics;
        }

        public UpdateTimeStatistics GetUpdateTimeStatisticsWithDbContextRecycle(bool useDbSetToSave)
        {
            var updateTimeStatistics = new UpdateTimeStatistics();
            var rowsUpdated = 0;
            var fifteenThousandAddressWithoutId = MakeFifteenThousandAddress(generateIncrementalId: false);
            var fifteenThousandAddress = MakeFifteenThousandAddress(generateIncrementalId: true);
            var rowCutOffToEmptyTable = Faker.RandomNumber.Next(5, 100);
            var rowCutOffToTableWithFiveThousandRows = Faker.RandomNumber.Next(6_000, 9_000);
            var rowCutOffToTableWithTenThousandRows = Faker.RandomNumber.Next(11_000, 14_000);

            var tenUpdateTimes = new List<long>();
            var amazonAddressInsertLabMapper = new AmazonAddressInsertLabMapper();
            var amazonAddressUpdateLabMapper = new AmazonAddressUpdateLabMapper();

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonAddressInsertLabMapper.CleanAddressData(amazonCodeFirstContext);
                amazonAddressInsertLabMapper.InsertAddressWithDbSetWithAddRange(fifteenThousandAddressWithoutId);

                foreach (var address in fifteenThousandAddress)
                {
                    address.Street = "Updated Street";

                    var updateTime = useDbSetToSave
                                        ? amazonAddressUpdateLabMapper.UpdateAddressWithDbSet(address)
                                        : amazonAddressUpdateLabMapper.UpdateAddressWithDbContext(address);

                    rowsUpdated++;

                    if (IsRowToBeComputed(rowsUpdated, rowCutOffToEmptyTable))
                    {
                        tenUpdateTimes.Add(updateTime);

                        if (tenUpdateTimes.Count == _tenRegisters)
                        {
                            var updateTimesAverage = Enumerable.Average(tenUpdateTimes);
                            updateTimeStatistics.MillisecondsAverageBasedOnTenUpdatesWithEmptyTable = updateTimesAverage;
                            tenUpdateTimes.Clear();
                        }
                    }

                    if (IsRowToBeComputed(rowsUpdated, rowCutOffToTableWithFiveThousandRows))
                    {
                        tenUpdateTimes.Add(updateTime);

                        if (tenUpdateTimes.Count == _tenRegisters)
                        {
                            var updateTimesAverage = Enumerable.Average(tenUpdateTimes);
                            updateTimeStatistics.MillisecondsAverageBasedOnTenUpdatesWithTableWithFiveThousandsRows = updateTimesAverage;
                            tenUpdateTimes.Clear();
                        }
                    }

                    if (IsRowToBeComputed(rowsUpdated, rowCutOffToTableWithTenThousandRows))
                    {
                        tenUpdateTimes.Add(updateTime);

                        if (tenUpdateTimes.Count == _tenRegisters)
                        {
                            var updateTimesAverage = Enumerable.Average(tenUpdateTimes);
                            updateTimeStatistics.MillisecondsAverageBasedOnTenUpdatesWithTableWithTenThousandsRows = updateTimesAverage;
                            tenUpdateTimes.Clear();
                        }
                    }

                }
            }

            return updateTimeStatistics;
        }

        public decimal GetUpdateTimeStatisticsAddRange(bool useDbSetToSave)
        {
            var fifteenThousandAddressWithoutId = MakeFifteenThousandAddress(generateIncrementalId: false);
            var fifteenThousandAddress = MakeFifteenThousandAddress(generateIncrementalId: true);

            var amazonAddressInsertLabMapper = new AmazonAddressInsertLabMapper();
            var amazonAddressUpdateLabMapper = new AmazonAddressUpdateLabMapper();

            using (var amazonCodeFirstContext = new AmazonCodeFirstDbContext())
            {
                amazonAddressInsertLabMapper.CleanAddressData(amazonCodeFirstContext);
                amazonAddressInsertLabMapper.InsertAddressWithDbSetWithAddRange(fifteenThousandAddressWithoutId);

                var updateTimeAllRecords = useDbSetToSave
                                           ? amazonAddressUpdateLabMapper.UpdateAddressWithDbSetWithAddRange(fifteenThousandAddress)
                                           : amazonAddressUpdateLabMapper.UpdateAddressWithDbContextWithAddRange(fifteenThousandAddress);

                var updateTime = decimal.Divide(updateTimeAllRecords, fifteenThousandAddress.Count());

                return updateTime;
            }

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
                                       .With(a => a.Street = "Updated Street")
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
