using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using FizzWare.NBuilder;
using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Application.DataFactory.Amazon
{
    public class CartProductDataFactory
    {
        public static IEnumerable<CartProduct> Make(int quantityOfCarts, int quantityOfProducts)
        {
            const int firstCartIdOfDatabase = 10000;
            var cartProducts = new List<CartProduct>();
            var random = new RandomGenerator();

            for (int cartId = firstCartIdOfDatabase; cartId < quantityOfCarts + firstCartIdOfDatabase; cartId++)
            {
                var maxQuantityOfItems = random.Next(1, 4);
                var productIdsUsed = new List<int>();

                for (int quantityOfItems = 1; quantityOfItems <= maxQuantityOfItems; quantityOfItems++)
                {
                    var productId = 0;
                    var quantity = random.Next(1, 3);

                    do
                    {
                        productId = random.Next(1, quantityOfProducts);

                    } while (productIdsUsed.Exists(id => id.Equals(productId)));

                    cartProducts.Add(new CartProduct() { CartId = cartId, ProductId = productId, Quantity = quantity });
                    productIdsUsed.Add(productId);
                }
            }

            return cartProducts;
        }
    }
}
