using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation
{
    public class PrincipalEntityByDataAnnotationMTM
    {
        public int Id { get; set; }
        public int FirstProperty { get; set; }
        public string SecondProperty { get; set; }

        [ForeignKey(nameof(MiddleEntityByDataAnnotationMTM.ForeignKeyToPrincipalEntity))]
        public IList<MiddleEntityByDataAnnotationMTM> MiddleEntitiesByDataAnnotationMTM { get; set; }
    }
}
