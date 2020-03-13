using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay
{
    public class Cart
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }
        public int CustomerId { get; set; }
    }
}
