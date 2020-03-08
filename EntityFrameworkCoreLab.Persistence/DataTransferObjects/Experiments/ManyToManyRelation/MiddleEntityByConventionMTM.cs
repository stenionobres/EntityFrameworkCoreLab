using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation
{
    public class MiddleEntityByConventionMTM
    {
        public int Id { get; set; }
        public int PrincipalEntityByConventionMTMId { get; set; }
        public int DependentEntityByConventionMTMId { get; set; }
    }
}
