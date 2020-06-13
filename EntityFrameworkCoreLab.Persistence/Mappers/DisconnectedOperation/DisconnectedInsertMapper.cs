using Microsoft.EntityFrameworkCore;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation;

namespace EntityFrameworkCoreLab.Persistence.Mappers.DisconnectedOperation
{
    public class DisconnectedInsertMapper
    {
        public void CleanAllRecordsFromPrincipalAndDependentEntitiesByConventionOTO()
        {
            using (var experimentsDbContext = new ExperimentsDbContext())
            {
                experimentsDbContext.Database.ExecuteSqlInterpolated($"delete from PrincipalEntityByConventionOTO");
                experimentsDbContext.Database.ExecuteSqlInterpolated($"DBCC CHECKIDENT ('PrincipalEntityByConventionOTO', RESEED, 0)");

                experimentsDbContext.Database.ExecuteSqlInterpolated($"delete from DependentEntityByConventionOTO");
                experimentsDbContext.Database.ExecuteSqlInterpolated($"DBCC CHECKIDENT ('DependentEntityByConventionOTO', RESEED, 0)");

                experimentsDbContext.SaveChanges();
            }
        }

        public void CleanAllRecordsFromPrincipalAndDependentEntitiesByConventionOTM()
        {
            using (var experimentsDbContext = new ExperimentsDbContext())
            {
                experimentsDbContext.Database.ExecuteSqlInterpolated($"delete from PrincipalEntityByConventionOTM");
                experimentsDbContext.Database.ExecuteSqlInterpolated($"DBCC CHECKIDENT ('PrincipalEntityByConventionOTM', RESEED, 0)");

                experimentsDbContext.Database.ExecuteSqlInterpolated($"delete from DependentEntityByConventionOTM");
                experimentsDbContext.Database.ExecuteSqlInterpolated($"DBCC CHECKIDENT ('DependentEntityByConventionOTM', RESEED, 0)");

                experimentsDbContext.SaveChanges();
            }
        }

        public void InsertEntitiesWithOneToOneRelationship(PrincipalEntityByConventionOTO principalEntityByConventionOTO)
        {
            using (var experimentsDbContext = new ExperimentsDbContext())
            {
                experimentsDbContext.DependentEntityByConventionOTO.Attach(principalEntityByConventionOTO.DependentEntityByConventionOTO);
                experimentsDbContext.PrincipalEntityByConventionOTO.AddRange(principalEntityByConventionOTO);
                experimentsDbContext.SaveChanges();
            }
        }

        public void InsertEntitiesWithOneToManyRelationship(PrincipalEntityByConventionOTM principalEntityByConventionOTM)
        {
            using (var experimentsDbContext = new ExperimentsDbContext())
            {
                experimentsDbContext.PrincipalEntityByConventionOTM.AddRange(principalEntityByConventionOTM);
                experimentsDbContext.SaveChanges();
            }
        }

    }
}
