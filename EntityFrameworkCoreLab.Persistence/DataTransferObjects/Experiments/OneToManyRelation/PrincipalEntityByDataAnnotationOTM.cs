using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation
{
    public class PrincipalEntityByDataAnnotationOTM
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public string SecondProperty { get; set; }

        [ForeignKey(nameof(DependentEntityByDataAnnotationOTM.ForeignKeyToPrincipalEntity))]
        public IList<DependentEntityByDataAnnotationOTM> DependentsEntitiesByDataAnnotationOTM { get; set; }
    }
}
