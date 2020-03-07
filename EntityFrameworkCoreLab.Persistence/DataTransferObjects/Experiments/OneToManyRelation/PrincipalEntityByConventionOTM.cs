using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation
{
    public class PrincipalEntityByConventionOTM
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public string SecondProperty { get; set; }
        public IList<DependentEntityByConventionOTM> DependentsEntitiesByConventionOTM { get; set; }
    }
}
