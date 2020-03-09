
namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation
{
    public class MiddleEntityByDataAnnotationMTM
    {
        public int Id { get; set; }
        public int ForeignKeyToPrincipalEntity { get; set; }
        public int ForeignKeyToDependentEntity { get; set; }
    }
}
