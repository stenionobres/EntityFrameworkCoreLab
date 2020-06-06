using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreLab.Persistence.Auditing
{
    public abstract class Auditable
    {
        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime UpdatedOn { get; set; }

        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
