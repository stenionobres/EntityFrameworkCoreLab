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

        public void UpdateAddressesWithAuditing()
        {
            var ebayAddressAuditingMapper = new EbayAddressAuditingMapper();
            var addresses = new List<Address>();

            InsertAddressesWithAuditing();

            var address01 = new Address()
            {
                Id = 4,
                Street = "4035 updated",
                ZipPostCode = "04826-03",
                City = "South Monserrate"
            };

            var address02 = new Address()
            {
                Id = 5,
                Street = "00886 updated",
                ZipPostCode = "66822-01",
                City = "Lake Dave"
            };

            addresses.Add(address01);
            addresses.Add(address02);

            ebayAddressAuditingMapper.UpdateAddressesWithAuditing(addresses);
        }

        public void DeleteAddressesWithAuditing()
        {
            var ebayAddressAuditingMapper = new EbayAddressAuditingMapper();
            var addresses = new List<Address>();

            InsertAddressesWithAuditing();

            var address01 = new Address() { Id = 4 };
            var address02 = new Address() { Id = 5 };

            addresses.Add(address01);
            addresses.Add(address02);

            ebayAddressAuditingMapper.DeleteAddressesWithAuditing(addresses);
        }
    }
}
