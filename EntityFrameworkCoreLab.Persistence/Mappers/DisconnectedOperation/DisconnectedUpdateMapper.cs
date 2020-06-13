using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation;

namespace EntityFrameworkCoreLab.Persistence.Mappers.DisconnectedOperation
{
    public class DisconnectedUpdateMapper
    {
        public void UpdateEntitiesWithOneToOneRelationship(PrincipalEntityByConventionOTO principalEntityByConventionOTO)
        {
            using (var experimentsDbContext = new ExperimentsDbContext())
            {
                experimentsDbContext.DependentEntityByConventionOTO.Attach(principalEntityByConventionOTO.DependentEntityByConventionOTO);
                experimentsDbContext.PrincipalEntityByConventionOTO.UpdateRange(principalEntityByConventionOTO);
                experimentsDbContext.SaveChanges();
            }
        }
    }
}
