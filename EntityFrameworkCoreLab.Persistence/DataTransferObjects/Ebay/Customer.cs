﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EntityFrameworkCoreLab.Persistence.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay
{
    [Table("Customer", Schema = "common")]
    public class Customer : Auditable
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

        [Required]
        public Address Address { get; set; }
        
        public int AddressId { get; set; }

        public IList<Cart> Carts { get; set; }
    }
}
