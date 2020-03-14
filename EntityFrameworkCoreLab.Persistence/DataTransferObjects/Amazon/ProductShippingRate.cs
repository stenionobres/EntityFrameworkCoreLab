using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon
{
    [Table("ProductShippingRate", Schema = "common")]
    public class ProductShippingRate
    {
        public int ProductId { get; set; }
        public int ShippingRateId { get; set; }
    }
}
