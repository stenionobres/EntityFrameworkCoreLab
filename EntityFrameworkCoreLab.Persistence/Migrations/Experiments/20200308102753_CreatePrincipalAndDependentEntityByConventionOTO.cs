using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Experiments
{
    public partial class CreatePrincipalAndDependentEntityByConventionOTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DependentEntityByConventionOTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentEntityByConventionOTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalEntityByConventionOTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<string>(nullable: true),
                    DependentEntityByConventionOTOId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalEntityByConventionOTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrincipalEntityByConventionOTO_DependentEntityByConventionOTO_DependentEntityByConventionOTOId",
                        column: x => x.DependentEntityByConventionOTOId,
                        principalTable: "DependentEntityByConventionOTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalEntityByConventionOTO_DependentEntityByConventionOTOId",
                table: "PrincipalEntityByConventionOTO",
                column: "DependentEntityByConventionOTOId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrincipalEntityByConventionOTO");

            migrationBuilder.DropTable(
                name: "DependentEntityByConventionOTO");
        }
    }
}
