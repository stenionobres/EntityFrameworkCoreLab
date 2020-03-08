using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation
{
    public class PrincipalEntityByDataAnnotationOTO
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public string SecondProperty { get; set; }
        public int ForeignKeyToDependentEntityByDataAnnotationOTO { get; set; }

        [ForeignKey(nameof(ForeignKeyToDependentEntityByDataAnnotationOTO))]
        public DependentEntityByDataAnnotationOTO DependentEntityByDataAnnotationOTO { get; set; }
    }
}
