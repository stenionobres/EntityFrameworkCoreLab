using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation
{
    public class DependentEntityByDataAnnotationMTM
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public decimal SecondProperty { get; set; }

        [ForeignKey(nameof(MiddleEntityByDataAnnotationMTM.ForeignKeyToDependentEntity))]
        public IList<MiddleEntityByDataAnnotationMTM> MiddleEntitiesByDataAnnotationMTM { get; set; }
    }
}
