using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation
{
    public class PrincipalEntityByFluentApiMTM
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public string SecondProperty { get; set; }
        public IList<MiddleEntityByFluentApiMTM> MiddleEntitiesByFluentApiMTM { get; set; }
    }
}
