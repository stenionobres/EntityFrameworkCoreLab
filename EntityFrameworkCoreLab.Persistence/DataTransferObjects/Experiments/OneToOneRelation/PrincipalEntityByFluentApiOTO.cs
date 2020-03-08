
namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation
{
    public class PrincipalEntityByFluentApiOTO
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public string SecondProperty { get; set; }
        public DependentEntityByFluentApiOTO DependentEntityByFluentApiOTO { get; set; }
    }
}
