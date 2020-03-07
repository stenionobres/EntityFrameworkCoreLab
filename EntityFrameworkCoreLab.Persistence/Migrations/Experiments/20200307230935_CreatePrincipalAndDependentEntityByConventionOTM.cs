using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Experiments
{
    public partial class CreatePrincipalAndDependentEntityByConventionOTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrincipalEntityByConventionOTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalEntityByConventionOTM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DependentEntityByConventionOTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<decimal>(nullable: false),
                    PrincipalEntityByConventionOTMId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentEntityByConventionOTM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DependentEntityByConventionOTM_PrincipalEntityByConventionOTM_PrincipalEntityByConventionOTMId",
                        column: x => x.PrincipalEntityByConventionOTMId,
                        principalTable: "PrincipalEntityByConventionOTM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DependentEntityByConventionOTM_PrincipalEntityByConventionOTMId",
                table: "DependentEntityByConventionOTM",
                column: "PrincipalEntityByConventionOTMId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DependentEntityByConventionOTM");

            migrationBuilder.DropTable(
                name: "PrincipalEntityByConventionOTM");
        }
    }
}
