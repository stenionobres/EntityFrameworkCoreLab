using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Amazon
{
    public partial class DatabaseSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(table: "Address",
                                        columns: new[] { "Street", "ZipPostCode", "City" },
                                        values: new object[] { "2775 Jerry Dove", "29555", "Johnsonville" },
                                        schema: "common");

            migrationBuilder.InsertData(table: "Address",
                                        columns: new[] { "Street", "ZipPostCode", "City" },
                                        values: new object[] { "2445 Romano Street", "81505", "Grand Junction" },
                                        schema: "common");

            migrationBuilder.InsertData(table: "Address",
                                        columns: new[] { "Street", "ZipPostCode", "City" },
                                        values: new object[] { "2104 Peck Street", "03079", "Salem" },
                                        schema: "common");


            migrationBuilder.InsertData(table: "Customer",
                                        columns: new[] { "Name", "Birthday", "Email", "Cpf", "AddressId" },
                                        values: new object[] { "Brett N. Young", new DateTime(1963, 06, 12), "brettnyoung@gmail.com", "90106817000", 2 },
                                        schema: "common");

            migrationBuilder.InsertData(table: "Customer",
                                        columns: new[] { "Name", "Birthday", "Email", "Cpf", "AddressId" },
                                        values: new object[] { "Joseph M. Bassler", new DateTime(1997, 07, 13), "josephmbassler@outlook.com", "83221575092", 3 },
                                        schema: "common");

            migrationBuilder.InsertData(table: "Customer",
                                        columns: new[] { "Name", "Birthday", "Email", "Cpf", "AddressId" },
                                        values: new object[] { "Adriana A. Braswell", new DateTime(1991, 12, 28), "adrianaabraswell@yahoo.com", "24663893040", 1 },
                                        schema: "common");

            migrationBuilder.InsertData(table: "Customer",
                                        columns: new[] { "Name", "Birthday", "Email", "Cpf", "AddressId" },
                                        values: new object[] { "Hazel D. Vazquez", new DateTime(1981, 01, 25), "hazeldvazquez@gmail.com", "68256878088", 2 },
                                        schema: "common");

            migrationBuilder.InsertData(table: "Customer",
                                        columns: new[] { "Name", "Birthday", "Email", "Cpf", "AddressId" },
                                        values: new object[] { "Stacy J. Morgan", new DateTime(1972, 11, 12), "stacyjmorgan@gmail.com", "05016804036", 1 },
                                        schema: "common");

            /***** An example of migrationBuilder.UpdateData operation *****/

            migrationBuilder.UpdateData(table: "Customer",
                                        keyColumn: "Id",
                                        keyValue: 5,
                                        column: "Birthday",
                                        value: new DateTime(1972, 11, 30),
                                        schema: "common");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Customer",
                                        keyColumn: "Id",
                                        keyValues: new object[] { 5 },
                                        schema: "common");

            migrationBuilder.DeleteData(table: "Customer",
                                        keyColumn: "Id",
                                        keyValues: new object[] { 4 },
                                        schema: "common");

            migrationBuilder.DeleteData(table: "Customer",
                                        keyColumn: "Id",
                                        keyValues: new object[] { 3 },
                                        schema: "common");

            migrationBuilder.DeleteData(table: "Customer",
                                        keyColumn: "Id",
                                        keyValues: new object[] { 2 },
                                        schema: "common");

            migrationBuilder.DeleteData(table: "Customer",
                                        keyColumn: "Id",
                                        keyValues: new object[] { 1 },
                                        schema: "common");

            migrationBuilder.Sql("DBCC CHECKIDENT ('common.Customer', RESEED, 0)");

            migrationBuilder.DeleteData(table: "Address",
                                        keyColumn: "Id",
                                        keyValues: new object[] { 3 },
                                        schema: "common");

            migrationBuilder.DeleteData(table: "Address",
                                        keyColumn: "Id",
                                        keyValues: new object[] { 2 },
                                        schema: "common");

            migrationBuilder.DeleteData(table: "Address",
                                        keyColumn: "Id",
                                        keyValues: new object[] { 1 },
                                        schema: "common");

            migrationBuilder.Sql("DBCC CHECKIDENT ('common.Address', RESEED, 0)");
        }
    }
}
