using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Ebay;
using EntityFrameworkCoreLab.Persistence.Mappers.Transaction;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreLab.Application.Process
{
    public class TransactionLabProcess
    {
        public void InsertAddressWithAddWithoutTransactionSaveChangesAfter()
        {
            var ebayTransactionLabMapper = new EbayTransactionLabMapper();

            ebayTransactionLabMapper.CleanAddressData();

            var address = new List<Address>()
            {
                new Address() { Street = "5000 Gandy Street", ZipPostCode = "13057", City = "East Syracuse" },
                new Address() { Street = "354 Cemetery Street", ZipPostCode = "95004", City = "Aromas" },
                new Address() { Street = "2031 Reppert Coal Road", ZipPostCode = "45232", City = "Cincinnati" } // Street larger than the field in the database 
            };

            try
            {
                ebayTransactionLabMapper.InsertAddressWithAddWithoutTransactionSaveChangesAfter(address);
            }
            catch (Exception ex)
            {
                // The records don't be inserted because SaveChanges was used after the error record was added
                throw;
            }
            
        }

        public void InsertAddressWithAddWithoutTransactionSaveChangesBefore()
        {
            var ebayTransactionLabMapper = new EbayTransactionLabMapper();

            ebayTransactionLabMapper.CleanAddressData();

            var address = new List<Address>()
            {
                new Address() { Street = "5000 Gandy Street", ZipPostCode = "13057", City = "East Syracuse" },
                new Address() { Street = "354 Cemetery Street", ZipPostCode = "95004", City = "Aromas" },
                new Address() { Street = "2031 Reppert Coal Road", ZipPostCode = "45232", City = "Cincinnati" } // Street larger than the field in the database 
            };

            try
            {
                ebayTransactionLabMapper.InsertAddressWithAddWithoutTransactionSaveChangesBefore(address);
            }
            catch (Exception ex)
            {
                // The first two records will be inserted because SaveChanges was used before the error record was added
                throw;
            }
        }

        public void InsertAddressWithAddRangeWithoutTransaction()
        {
            var ebayTransactionLabMapper = new EbayTransactionLabMapper();

            ebayTransactionLabMapper.CleanAddressData();

            var address = new List<Address>()
            {
                new Address() { Street = "5000 Gandy Street", ZipPostCode = "13057", City = "East Syracuse" },
                new Address() { Street = "354 Cemetery Street", ZipPostCode = "95004", City = "Aromas" },
                new Address() { Street = "2031 Reppert Coal Road", ZipPostCode = "45232", City = "Cincinnati" } // Street larger than the field in the database 
            };

            try
            {
                ebayTransactionLabMapper.InsertAddressWithAddRangeWithoutTransaction(address);
            }
            catch (Exception ex)
            {
                // The records don't be inserted because SaveChanges was used after the error record was added
                throw;
            }
        }

        public void InsertAddressWithAddWithTransactionSaveChangesBefore()
        {
            var ebayTransactionLabMapper = new EbayTransactionLabMapper();

            ebayTransactionLabMapper.CleanAddressData();

            var address = new List<Address>()
            {
                new Address() { Street = "5000 Gandy Street", ZipPostCode = "13057", City = "East Syracuse" },
                new Address() { Street = "354 Cemetery Street", ZipPostCode = "95004", City = "Aromas" },
                new Address() { Street = "2031 Reppert Coal Road", ZipPostCode = "45232", City = "Cincinnati" } // Street larger than the field in the database 
            };

            try
            {
                ebayTransactionLabMapper.InsertAddressWithAddWithTransactionSaveChangesBefore(address);
            }
            catch (Exception ex)
            {
                // The records don't be inserted because the use of the transaction 
                throw;
            }
        }
    }
}
