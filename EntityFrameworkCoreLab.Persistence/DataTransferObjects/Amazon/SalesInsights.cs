using System;

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
        public decimal PurchaseValueMax { get; set; }
        public decimal PurchaseValueAverage { get; set; }
        public int TotalItemsQuantity { get; set; }
        public decimal ItemsQuantityAverage { get; set; }
        public decimal ShippingRateMax { get; set; }
        public decimal ShippingRateAverage { get; set; }
    }
}
