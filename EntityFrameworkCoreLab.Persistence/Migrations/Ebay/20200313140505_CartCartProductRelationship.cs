using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Ebay
{
    public partial class CartCartProductRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_CartProduct_Cart_CartId",
                table: "CartProduct",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProduct_Cart_CartId",
                table: "CartProduct");
        }
    }
}
