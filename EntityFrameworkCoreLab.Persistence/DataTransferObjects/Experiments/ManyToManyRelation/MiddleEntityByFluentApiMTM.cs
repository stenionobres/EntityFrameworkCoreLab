
namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation
{
    public class MiddleEntityByFluentApiMTM
    {
        public int Id { get; set; }
        public int ForeignKeyToPrincipalEntity { get; set; }
        public PrincipalEntityByFluentApiMTM PrincipalEntityByFluentApiMTM { get; set; }
        public int ForeignKeyToDependentEntity { get; set; }
        public DependentEntityByFluentApiMTM DependentEntityByFluentApiMTM { get; set; }
    }
}
