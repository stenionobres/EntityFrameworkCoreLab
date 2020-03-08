using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation
{
    public class PrincipalEntityByFluentApiOTM
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public string SecondProperty { get; set; }
        public IList<DependentEntityByFluentApiOTM> DependentsEntitiesByFluentApiOTM { get; set; }
    }
}
