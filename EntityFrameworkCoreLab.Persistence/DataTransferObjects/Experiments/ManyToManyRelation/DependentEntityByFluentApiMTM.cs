using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation
{
    public class DependentEntityByFluentApiMTM
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public decimal SecondProperty { get; set; }
        public IList<MiddleEntityByFluentApiMTM> MiddleEntitiesByFluentApiMTM { get; set; }
    }
}
