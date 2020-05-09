using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Application.DataFactory.Amazon
{
    public class ProductShippingRateDataFactory
    {
        public static IEnumerable<ProductShippingRate> Make(int quantityOfProducts, int quantityOfShippingRates)
        {
            var productsShippingRates = new List<ProductShippingRate>();

            for (int productId = 1; productId <= quantityOfProducts; productId++)
            {
                for (int shippingRateId = 1; shippingRateId <= quantityOfShippingRates; shippingRateId++)
                {
                    productsShippingRates.Add(new ProductShippingRate() { ProductId = productId, ShippingRateId = shippingRateId });
                }
            }

            return productsShippingRates;
        }
    }
}
