using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }
        
        [Required]
        [MaxLength(60)]
        public string Email { get; set; }

        [Required]
        public string Cpf { get; set; }
    }
}
