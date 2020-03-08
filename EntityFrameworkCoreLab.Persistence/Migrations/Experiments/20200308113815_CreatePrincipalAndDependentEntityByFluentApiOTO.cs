using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Experiments
{
    public partial class CreatePrincipalAndDependentEntityByFluentApiOTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DependentEntityByFluentApiOTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentEntityByFluentApiOTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalEntityByFluentApiOTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProperty = table.Column<int>(nullable: false),
                    SecondProperty = table.Column<string>(nullable: true),
                    DependentEntityByFluentApiOTOId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalEntityByFluentApiOTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrincipalEntityByFluentApiOTO_DependentEntityByFluentApiOTO_DependentEntityByFluentApiOTOId",
                        column: x => x.DependentEntityByFluentApiOTOId,
                        principalTable: "DependentEntityByFluentApiOTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalEntityByFluentApiOTO_DependentEntityByFluentApiOTOId",
                table: "PrincipalEntityByFluentApiOTO",
                column: "DependentEntityByFluentApiOTOId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrincipalEntityByFluentApiOTO");

            migrationBuilder.DropTable(
                name: "DependentEntityByFluentApiOTO");
        }
    }
}
