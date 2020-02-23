using EntityFrameworkCoreLab.Persistence.DataTransferObjects.Amazon;
using EntityFrameworkCoreLab.Persistence.Mappers;
using System;

namespace EntityFrameworkCoreLab.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var customer = new Customer() { Name = "Customer 01" };

            new AmazonCustomerMapper().Save(customer);
        }
    }
}
