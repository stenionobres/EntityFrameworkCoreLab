using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Ebay
{
    public partial class ChangeCustomerSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "common");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customer",
                newSchema: "common");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Customer",
                schema: "common",
                newName: "Customer");
        }
    }
}
