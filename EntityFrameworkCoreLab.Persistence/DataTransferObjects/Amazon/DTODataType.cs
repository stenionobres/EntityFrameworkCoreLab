using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon
{
    public class DTODataType
    {
        public int Id { get; set; }
        public int IntProperty { get; set; }
        public int? IntPropertyNullable { get; set; }
        
        public string StringPropertyMaxLength { get; set; }

        [StringLength(50)]
        public string StringPropertyLimitedLength { get; set; }
        
        [Required]
        public string StringPropertyRequired { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateProperty { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatePropertyNullable { get; set; }

        public DateTime DateTimeProperty { get; set; }
        public DateTime? DateTimePropertyNullable { get; set; }

        public TimeSpan TimeSpanProperty { get; set; }
        public TimeSpan? TimeSpanPropertyNullable { get; set; }

        public float FloatProperty { get; set; }
        public float? FloatPropertyNullable { get; set; }

        public double DoubleProperty { get; set; }
        public double? DoublePropertyNullable { get; set; }

        public long LongProperty { get; set; }
        public long? LongPropertyNullable { get; set; }

        public decimal DecimalProperty { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal DecimalLowerPrecisionProperty { get; set; }
        public decimal? DecimalPropertyNullable { get; set; }

        public bool BoolProperty { get; set; }
        public bool? BoolPropertyNullable { get; set; }

        public char CharProperty { get; set; }
        public char? CharPropertyNullable { get; set; }

        public byte[] ArrayBytesProperty { get; set; }

        // The nullable type enables to work with null columns in the database. 

        // Another option to create a null column is override the OnModelCreating method
        // in DbContext class (AmazonCodeFirstDbContext) and use the code instruction below
        // modelBuilder.Entity<DTODataType>().Property(m => m.LongProperty).IsRequired(false);

        // The [Column(TypeName = "")] annotation enables change the type of column

        // Another option to change a column type is override the OnModelCreating method
        // in DbContext class (AmazonCodeFirstDbContext) and use the code instruction below
        // modelBuilder.Entity<DTODataType>().Property(p => p.DateProperty).HasColumnType("date");
    }
}
