using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using FizzWare.NBuilder;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Application.DataFactory.Amazon
{
    public class ProductDataFactory
    {
        private static Dictionary<int, string> _partialDescriptions = new Dictionary<int, string>()
        {
            {1, "Eye liner"},
            {2, "Highlighter"},
            {3, "Lip liner"},
            {4, "Bronzer"},
            {5, "Eye brow pencil"},
            {6, "Eye shadow"},
            {7, "False eye lashes"},
            {8, "Eye lash curler"},
            {9, "Makeup brushes"},
            {10, "Makeup Base"},
            {11, "Tweezers"},
            {12, "Lip stain"},
            {13, "Hair color"},
            {14, "Baby Shampoo"},
            {15, "Eye Makeup Remover"},
            {16, "Hair Spray"},
            {17, "Hair Bleaches"},
            {18, "Deodorant"},
            {19, "Aftershave Lotion"},
            {20, "Face Powders"}
        };

        private static Dictionary<int, string> _brands = new Dictionary<int, string>()
        {
            {1, "L'Oreal"},
            {2, "Gillette"},
            {3, "Johnson & Johnson"},
            {4, "Pantene"},
            {5, "Nivea"},
            {6, "Avon"},
            {7, "Colgate"},
            {8, "Head & Shoulders"},
            {9, "Clean & Clear"},
            {10, "Neutrogena"},
            {11, "Natura"},
            {12, "Johnson's"},
            {13, "Lux"},
            {14, "Softsoap"},
            {15, "Revlon"}
        };

        public static IEnumerable<Product> Make(int quantity)
        {
            var products = Builder<Product>.CreateListOfSize(quantity)
                                           .All()
                                           .With(p => p.Id = 0)
                                           .With(p => p.Description = GetDescription())
                                           .With(p => p.BrandName = GetBrandName())
                                           .With(p => p.Price = GetPrice())
                                           .Build();

            return products;
        }

        private static string GetDescription()
        {
            var random = new RandomGenerator();
            var descriptionId = random.Next(1, 20);
            var factorNumber = random.Next(10, 99);

            return $"{_partialDescriptions[descriptionId]} - Factor {factorNumber}";
        } 

        private static string GetBrandName()
        {
            var random = new RandomGenerator();
            var brandId = random.Next(1, 15);

            return _brands[brandId];
        }

        private static decimal GetPrice()
        {
            var random = new RandomGenerator();
            var price = random.Next(50m, 100m);

            return Math.Round(price, 2);
        }
    }
}
