using EntityFrameworkCoreLab.Persistence.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay
{
    [Table("Address", Schema = "common")]
    public class Address : Auditable
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
