using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation
{
    public class PrincipalEntityByConventionMTM
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public string SecondProperty { get; set; }
        public IList<MiddleEntityByConventionMTM> MiddleEntitiesByConventionMTM { get; set; }
    }
}
