using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon
{
    public class ShippingRate
    {
        public int Id { get; set; }
        public int FirstDay { get; set; }
        public int SecondDay { get; set; }

        [Column(TypeName = "decimal(3,2)")]
        public decimal Rate { get; set; }
    }
}
