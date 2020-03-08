
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation
{
    public class PrincipalEntityByConventionOTO
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public string SecondProperty { get; set; }
        
        [Required]
        public DependentEntityByConventionOTO DependentEntityByConventionOTO { get; set; }
    }
}
