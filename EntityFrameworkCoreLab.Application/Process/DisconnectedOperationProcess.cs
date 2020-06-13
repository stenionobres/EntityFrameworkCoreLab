using EntityFrameworkCoreLab.Persistence.Mappers.DisconnectedOperation;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation;

namespace EntityFrameworkCoreLab.Application.Process
{
    public class DisconnectedOperationProcess
    {
        public void InsertEntitiesWithOneToOneRelationship()
        {
            var disconnectedInsertMapper = new DisconnectedInsertMapper();

            disconnectedInsertMapper.CleanAllRecordsFromPrincipalAndDependentEntitiesByConventionOTO();

            var firstPrincipalEntityByConventionOTO = new PrincipalEntityByConventionOTO()
            {
                FirstProperty = 100,
                SecondProperty = "example that will add the two entities",
                DependentEntityByConventionOTO = new DependentEntityByConventionOTO() { FirstProperty = 50, SecondProperty = 155.67m }
            };

            new DisconnectedInsertMapper().InsertEntitiesWithOneToOneRelationship(firstPrincipalEntityByConventionOTO);

            var secondPrincipalEntityByConventionOTO = new PrincipalEntityByConventionOTO()
            {
                FirstProperty = 200,
                SecondProperty = "example that will add the second principal entity and reuse the dependent entity existing",
                DependentEntityByConventionOTO = new DependentEntityByConventionOTO() { Id = 1 }
            };

            new DisconnectedInsertMapper().InsertEntitiesWithOneToOneRelationship(secondPrincipalEntityByConventionOTO);
        }
    }
}
