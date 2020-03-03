﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string BrandName { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
    }
}