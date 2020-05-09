using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments
{
    public class DTOAmazonDatabaseData
    {
        public IEnumerable<Address> Adresses { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
