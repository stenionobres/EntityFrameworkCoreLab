using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Experiments
{
    public partial class CreatePrincipalAndDependentEntityByDataAnnotationMTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DependentEntityByDataAnnotationMTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentEntityByDataAnnotationMTM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalEntityByDataAnnotationMTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalEntityByDataAnnotationMTM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiddleEntityByDataAnnotationMTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForeignKeyToPrincipalEntity = table.Column<int>(nullable: false),
                    ForeignKeyToDependentEntity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiddleEntityByDataAnnotationMTM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiddleEntityByDataAnnotationMTM_DependentEntityByDataAnnotationMTM_ForeignKeyToDependentEntity",
                        column: x => x.ForeignKeyToDependentEntity,
                        principalTable: "DependentEntityByDataAnnotationMTM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiddleEntityByDataAnnotationMTM_PrincipalEntityByDataAnnotationMTM_ForeignKeyToPrincipalEntity",
                        column: x => x.ForeignKeyToPrincipalEntity,
                        principalTable: "PrincipalEntityByDataAnnotationMTM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiddleEntityByDataAnnotationMTM_ForeignKeyToDependentEntity",
                table: "MiddleEntityByDataAnnotationMTM",
                column: "ForeignKeyToDependentEntity");

            migrationBuilder.CreateIndex(
                name: "IX_MiddleEntityByDataAnnotationMTM_ForeignKeyToPrincipalEntity",
                table: "MiddleEntityByDataAnnotationMTM",
                column: "ForeignKeyToPrincipalEntity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiddleEntityByDataAnnotationMTM");

            migrationBuilder.DropTable(
                name: "DependentEntityByDataAnnotationMTM");

            migrationBuilder.DropTable(
                name: "PrincipalEntityByDataAnnotationMTM");
        }
    }
}
