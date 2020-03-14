using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Ebay
{
    public partial class ChangeCartSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sales");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "Cart",
                newSchema: "sales");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Cart",
                schema: "sales",
                newName: "Cart");
        }
    }
}
