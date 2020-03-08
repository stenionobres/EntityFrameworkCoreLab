using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Experiments
{
    public partial class CreatePrincipalAndDependentEntityByDataAnnotationOTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DependentEntityByDataAnnotationOTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentEntityByDataAnnotationOTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalEntityByDataAnnotationOTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<string>(nullable: true),
                    ForeignKeyToDependentEntityByDataAnnotationOTO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalEntityByDataAnnotationOTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrincipalEntityByDataAnnotationOTO_DependentEntityByDataAnnotationOTO_ForeignKeyToDependentEntityByDataAnnotationOTO",
                        column: x => x.ForeignKeyToDependentEntityByDataAnnotationOTO,
                        principalTable: "DependentEntityByDataAnnotationOTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalEntityByDataAnnotationOTO_ForeignKeyToDependentEntityByDataAnnotationOTO",
                table: "PrincipalEntityByDataAnnotationOTO",
                column: "ForeignKeyToDependentEntityByDataAnnotationOTO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrincipalEntityByDataAnnotationOTO");

            migrationBuilder.DropTable(
                name: "DependentEntityByDataAnnotationOTO");
        }
    }
}
