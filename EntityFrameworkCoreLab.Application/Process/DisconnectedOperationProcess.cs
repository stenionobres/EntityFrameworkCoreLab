using System.Collections.Generic;
using EntityFrameworkCoreLab.Persistence.Mappers.DisconnectedOperation;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation;

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

        public void InsertEntitiesWithOneToManyRelationship()
        {
            var disconnectedInsertMapper = new DisconnectedInsertMapper();

            disconnectedInsertMapper.CleanAllRecordsFromPrincipalAndDependentEntitiesByConventionOTM();

            var firstPrincipalEntityByConventionOTM = new PrincipalEntityByConventionOTM()
            {
                FirstProperty = 100,
                SecondProperty = "example that will add the two entities"
            };

            var firstDependentEntityByConventionOTM = new DependentEntityByConventionOTM()
            {
                FirstProperty = 50,
                SecondProperty = 556.89m
            };

            var secondDependentEntityByConventionOTM = new DependentEntityByConventionOTM()
            {
                FirstProperty = 100,
                SecondProperty = 116.69m
            };

            firstPrincipalEntityByConventionOTM.DependentsEntitiesByConventionOTM = new List<DependentEntityByConventionOTM>();
            firstPrincipalEntityByConventionOTM.DependentsEntitiesByConventionOTM.Add(firstDependentEntityByConventionOTM);
            firstPrincipalEntityByConventionOTM.DependentsEntitiesByConventionOTM.Add(secondDependentEntityByConventionOTM);

            disconnectedInsertMapper.InsertEntitiesWithOneToManyRelationship(firstPrincipalEntityByConventionOTM);
        }

        public void InsertEntitiesWithManyToManyRelationship()
        {
            var disconnectedInsertMapper = new DisconnectedInsertMapper();

            disconnectedInsertMapper.CleanAllRecordsFromPrincipalAndDependentEntitiesByConventionMTM();

            var principalEntityByConventionMTM = new PrincipalEntityByConventionMTM()
            {
                FirstProperty = 100,
                SecondProperty = "example that will add the two entities"
            };

            var dependentEntityByConventionMTM = new DependentEntityByConventionMTM()
            {
                FirstProperty = 100,
                SecondProperty = 64.89m
            };

            disconnectedInsertMapper.InsertEntitiesWithManyToManyRelationship(principalEntityByConventionMTM, dependentEntityByConventionMTM);
        }

        public void UpdateEntitiesWithOneToOneRelationship()
        {
            InsertEntitiesWithOneToOneRelationship();

            var disconnectedUpdateMapper = new DisconnectedUpdateMapper();

            var firstPrincipalEntityByConventionOTO = new PrincipalEntityByConventionOTO()
            {
                Id = 1,
                FirstProperty = 100,
                SecondProperty = "example that will update the entities",
                DependentEntityByConventionOTO = new DependentEntityByConventionOTO() { FirstProperty = 85, SecondProperty = 55.22m }
            };

            disconnectedUpdateMapper.UpdateEntitiesWithOneToOneRelationship(firstPrincipalEntityByConventionOTO);
        }

        public void UpdateEntitiesWithOneToManyRelationship()
        {
            InsertEntitiesWithOneToManyRelationship();

            var disconnectedUpdateMapper = new DisconnectedUpdateMapper();

            var firstPrincipalEntityByConventionOTM = new PrincipalEntityByConventionOTM()
            {
                Id = 1,
                FirstProperty = 100,
                SecondProperty = "example that will update the entities",
                DependentsEntitiesByConventionOTM = new List<DependentEntityByConventionOTM>() 
                { 
                   new DependentEntityByConventionOTM() { Id = 1, FirstProperty = 50, SecondProperty = 12.45m }
                }
            };

            disconnectedUpdateMapper.UpdateEntitiesWithOneToManyRelationship(firstPrincipalEntityByConventionOTM);
        }
    }
}
