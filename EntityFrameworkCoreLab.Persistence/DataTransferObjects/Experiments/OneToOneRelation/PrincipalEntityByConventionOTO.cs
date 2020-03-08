
namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation
{
    public class PrincipalEntityByConventionOTO
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public string SecondProperty { get; set; }
        public int DependentEntityByConventionOTOId { get; set; }
    }
}
