using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Experiments
{
    public partial class CreatePrincipalAndDependentEntityByFluentApiMTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DependentEntityByFluentApiMTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentEntityByFluentApiMTM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalEntityByFluentApiMTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalEntityByFluentApiMTM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiddleEntityByFluentApiMTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForeignKeyToPrincipalEntity = table.Column<int>(nullable: false),
                    ForeignKeyToDependentEntity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiddleEntityByFluentApiMTM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiddleEntityByFluentApiMTM_DependentEntityByFluentApiMTM_ForeignKeyToDependentEntity",
                        column: x => x.ForeignKeyToDependentEntity,
                        principalTable: "DependentEntityByFluentApiMTM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MiddleEntityByFluentApiMTM_PrincipalEntityByFluentApiMTM_ForeignKeyToPrincipalEntity",
                        column: x => x.ForeignKeyToPrincipalEntity,
                        principalTable: "PrincipalEntityByFluentApiMTM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiddleEntityByFluentApiMTM_ForeignKeyToDependentEntity",
                table: "MiddleEntityByFluentApiMTM",
                column: "ForeignKeyToDependentEntity");

            migrationBuilder.CreateIndex(
                name: "IX_MiddleEntityByFluentApiMTM_ForeignKeyToPrincipalEntity",
                table: "MiddleEntityByFluentApiMTM",
                column: "ForeignKeyToPrincipalEntity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiddleEntityByFluentApiMTM");

            migrationBuilder.DropTable(
                name: "DependentEntityByFluentApiMTM");

            migrationBuilder.DropTable(
                name: "PrincipalEntityByFluentApiMTM");
        }
    }
}
