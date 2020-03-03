using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        [Required]
        [MaxLength(60)]
        public string Email { get; set; }

        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }
    }
}
