using System.Collections.Generic;
using EntityFrameworkCoreLab.Persistence.Mappers.Auditing;
using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay;

namespace EntityFrameworkCoreLab.Application.Process
{
    public class AuditingProcess
    {
        public void InsertAddressesWithAuditing()
        {
            var ebayAddressAuditingMapper = new EbayAddressAuditingMapper();
            var addresses = new List<Address>();

            ebayAddressAuditingMapper.CleanAddressData();

            var address01 = new Address()
            {
                Street = "4035 Hermiston Vista",
                ZipPostCode = "04826-03",
                City = "South Monserrate"
            };

            var address02 = new Address()
            {
                Street = "00886 Klein Road",
                ZipPostCode = "66822-01",
                City = "Lake Dave"
            };

            addresses.Add(address01);
            addresses.Add(address02);

            ebayAddressAuditingMapper.InsertAddressesWithAuditing(addresses);
        }
    }
}
