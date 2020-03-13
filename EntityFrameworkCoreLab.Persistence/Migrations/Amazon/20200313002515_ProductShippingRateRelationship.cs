using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Amazon
{
    public partial class ProductShippingRateRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductShippingRate_ShippingRateId",
                table: "ProductShippingRate",
                column: "ShippingRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShippingRate_Product_ProductId",
                table: "ProductShippingRate",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductShippingRate_ShippingRate_ShippingRateId",
                table: "ProductShippingRate",
                column: "ShippingRateId",
                principalTable: "ShippingRate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductShippingRate_Product_ProductId",
                table: "ProductShippingRate");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductShippingRate_ShippingRate_ShippingRateId",
                table: "ProductShippingRate");

            migrationBuilder.DropIndex(
                name: "IX_ProductShippingRate_ShippingRateId",
                table: "ProductShippingRate");
        }
    }
}
