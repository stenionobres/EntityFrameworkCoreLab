
namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation
{
    public class DependentEntityByConventionOTM
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public decimal SecondProperty { get; set; }
        public int PrincipalEntityByConventionOTMId { get; set; }
    }
}
