using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Experiments
{
    public partial class CreatePrincipalAndDependentEntityByDataAnnotationOTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrincipalEntityByDataAnnotationOTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalEntityByDataAnnotationOTM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DependentEntityByDataAnnotationOTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<decimal>(nullable: false),
                    ForeignKeyToPrincipalEntity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentEntityByDataAnnotationOTM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DependentEntityByDataAnnotationOTM_PrincipalEntityByDataAnnotationOTM_ForeignKeyToPrincipalEntity",
                        column: x => x.ForeignKeyToPrincipalEntity,
                        principalTable: "PrincipalEntityByDataAnnotationOTM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DependentEntityByDataAnnotationOTM_ForeignKeyToPrincipalEntity",
                table: "DependentEntityByDataAnnotationOTM",
                column: "ForeignKeyToPrincipalEntity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DependentEntityByDataAnnotationOTM");

            migrationBuilder.DropTable(
                name: "PrincipalEntityByDataAnnotationOTM");
        }
    }
}
