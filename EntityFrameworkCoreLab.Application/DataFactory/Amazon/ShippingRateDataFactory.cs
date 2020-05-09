using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using FizzWare.NBuilder;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Application.DataFactory.Amazon
{
    public class ShippingRateDataFactory
    {
        public static IEnumerable<ShippingRate> Make()
        {
            return new List<ShippingRate>()
            {
                new ShippingRate() { FirstDay = 1, SecondDay = 2, Rate = GetRate() },
                new ShippingRate() { FirstDay = 3, SecondDay = 4, Rate = GetRate() },
                new ShippingRate() { FirstDay = 5, SecondDay = 6, Rate = GetRate() },
                new ShippingRate() { FirstDay = 7, SecondDay = 8, Rate = GetRate() },
                new ShippingRate() { FirstDay = 9, SecondDay = 10, Rate = GetRate() },
                new ShippingRate() { FirstDay = 11, SecondDay = 12, Rate = GetRate() },
                new ShippingRate() { FirstDay = 13, SecondDay = 14, Rate = GetRate() },
                new ShippingRate() { FirstDay = 15, SecondDay = 16, Rate = GetRate() },
                new ShippingRate() { FirstDay = 17, SecondDay = 18, Rate = GetRate() },
                new ShippingRate() { FirstDay = 19, SecondDay = 20, Rate = GetRate() },
                new ShippingRate() { FirstDay = 21, SecondDay = 22, Rate = GetRate() },
                new ShippingRate() { FirstDay = 23, SecondDay = 24, Rate = GetRate() },
                new ShippingRate() { FirstDay = 25, SecondDay = 26, Rate = GetRate() },
                new ShippingRate() { FirstDay = 27, SecondDay = 28, Rate = GetRate() },
                new ShippingRate() { FirstDay = 29, SecondDay = 29, Rate = GetRate() },
                new ShippingRate() { FirstDay = 30, SecondDay = 30, Rate = GetRate() },
                new ShippingRate() { FirstDay = 31, SecondDay = 31, Rate = GetRate() }
            };
        }

        private static decimal GetRate()
        {
            var random = new RandomGenerator();
            var rate = random.Next(1m, 10m);

            return Math.Round(rate, 2);
        }
    }
}
