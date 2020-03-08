using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation
{
    public class DependentEntityByConventionMTM
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public decimal SecondProperty { get; set; }
        public IList<MiddleEntityByConventionMTM> MiddleEntitiesByConventionMTM { get; set; }
    }
}
