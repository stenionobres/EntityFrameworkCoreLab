using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Experiments
{
    public partial class CreatePrincipalAndDependentEntityByConventionMTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DependentEntityByConventionMTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentEntityByConventionMTM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalEntityByConventionMTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalEntityByConventionMTM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiddleEntityByConventionMTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrincipalEntityByConventionMTMId = table.Column<int>(nullable: false),
                    DependentEntityByConventionMTMId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiddleEntityByConventionMTM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiddleEntityByConventionMTM_DependentEntityByConventionMTM_DependentEntityByConventionMTMId",
                        column: x => x.DependentEntityByConventionMTMId,
                        principalTable: "DependentEntityByConventionMTM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiddleEntityByConventionMTM_PrincipalEntityByConventionMTM_PrincipalEntityByConventionMTMId",
                        column: x => x.PrincipalEntityByConventionMTMId,
                        principalTable: "PrincipalEntityByConventionMTM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiddleEntityByConventionMTM_DependentEntityByConventionMTMId",
                table: "MiddleEntityByConventionMTM",
                column: "DependentEntityByConventionMTMId");

            migrationBuilder.CreateIndex(
                name: "IX_MiddleEntityByConventionMTM_PrincipalEntityByConventionMTMId",
                table: "MiddleEntityByConventionMTM",
                column: "PrincipalEntityByConventionMTMId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiddleEntityByConventionMTM");

            migrationBuilder.DropTable(
                name: "DependentEntityByConventionMTM");

            migrationBuilder.DropTable(
                name: "PrincipalEntityByConventionMTM");
        }
    }
}
