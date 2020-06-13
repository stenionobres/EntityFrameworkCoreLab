using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation;

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

        public void UpdateEntitiesWithOneToManyRelationship(PrincipalEntityByConventionOTM principalEntityByConventionOTM)
        {
            using (var experimentsDbContext = new ExperimentsDbContext())
            {
                experimentsDbContext.PrincipalEntityByConventionOTM.UpdateRange(principalEntityByConventionOTM);
                experimentsDbContext.SaveChanges();
            }
        }

        public void UpdateEntitiesWithManyToManyRelationship(MiddleEntityByConventionMTM middleEntityByConventionMTM)
        {
            using (var experimentsDbContext = new ExperimentsDbContext())
            {
                experimentsDbContext.MiddleEntityByConventionMTM.UpdateRange(middleEntityByConventionMTM);
                experimentsDbContext.SaveChanges();
            }
        }
    }
}
