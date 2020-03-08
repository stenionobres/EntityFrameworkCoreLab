using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Experiments
{
    public partial class CreatePrincipalAndDependentEntityByFluentApiOTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrincipalEntityByFluentApiOTM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalEntityByFluentApiOTM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DependentEntityByFluentApiOTM",
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
                    table.PrimaryKey("PK_DependentEntityByFluentApiOTM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DependentEntityByFluentApiOTM_PrincipalEntityByFluentApiOTM_ForeignKeyToPrincipalEntity",
                        column: x => x.ForeignKeyToPrincipalEntity,
                        principalTable: "PrincipalEntityByFluentApiOTM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DependentEntityByFluentApiOTM_ForeignKeyToPrincipalEntity",
                table: "DependentEntityByFluentApiOTM",
                column: "ForeignKeyToPrincipalEntity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DependentEntityByFluentApiOTM");

            migrationBuilder.DropTable(
                name: "PrincipalEntityByFluentApiOTM");
        }
    }
}
