using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Amazon
{
    public partial class CreateProductShippingRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductShippingRate",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ShippingRateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShippingRate", x => new { x.ProductId, x.ShippingRateId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductShippingRate");
        }
    }
}
