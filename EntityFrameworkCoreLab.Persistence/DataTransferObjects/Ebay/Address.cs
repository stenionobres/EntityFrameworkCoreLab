using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay
{
    public class Address
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Street { get; set; }

        [Required]
        [MaxLength(8)]
        public string ZipPostCode { get; set; }

        [Required]
        [MaxLength(20)]
        public string City { get; set; }
    }
}
