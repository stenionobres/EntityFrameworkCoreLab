using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay
{
    [Table("ProductShippingRate", Schema = "common")]
    public class ProductShippingRate
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ShippingRateId { get; set; }
        public ShippingRate ShippingRate { get; set; }
    }
}
