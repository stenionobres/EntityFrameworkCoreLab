using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon
{
    public class SalesInsights
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Street { get; set; }
        public string ZipPostCode { get; set; }
        public string City { get; set; }
        public int PurchaseQuantity { get; set; }
        
        [Column(TypeName = "decimal(7,2)")]
        public decimal PurchaseValueMax { get; set; }
        
        [Column(TypeName = "decimal(7,2)")]
        public decimal PurchaseValueAverage { get; set; }
        public int TotalItemsQuantity { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal ItemsQuantityAverage { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal ShippingRateMax { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal ShippingRateAverage { get; set; }
    }
}
