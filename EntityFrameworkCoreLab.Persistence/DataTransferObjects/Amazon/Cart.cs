using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon
{
    [Table("Cart", Schema = "sales")]
    public class Cart
    {
        public int Id { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }
        public int CustomerId { get; set; }
        public IList<CartProduct> CartProducts { get; set; }
    }
}
