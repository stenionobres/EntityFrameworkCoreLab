using EntityFrameworkCoreLab.Application.Process;

namespace EntityFrameworkCoreLab.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            new DisconnectedOperationProcess().UpdateEntitiesWithManyToManyRelationship();
        }
    }
}
