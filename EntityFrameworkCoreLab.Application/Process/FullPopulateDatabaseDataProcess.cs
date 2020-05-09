using EntityFrameworkCoreLab.Persistence.Mappers.PopulateData;

namespace EntityFrameworkCoreLab.Application.Process
{
    public class FullPopulateDatabaseDataProcess
    {
        public void FullPopulateDatabaseWithFakeData()
        {
            new FullPopulateDatabaseDataMapper().CleanDataOfAllTables();
        }
    }
}
