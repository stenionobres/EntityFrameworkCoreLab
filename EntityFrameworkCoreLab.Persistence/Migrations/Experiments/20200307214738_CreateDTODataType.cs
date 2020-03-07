using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Experiments
{
    public partial class CreateDTODataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DTODataType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntProperty = table.Column<int>(nullable: false),
                    IntPropertyNullable = table.Column<int>(nullable: true),
                    StringPropertyMaxLength = table.Column<string>(nullable: true),
                    StringPropertyLimitedLength = table.Column<string>(maxLength: 50, nullable: true),
                    StringPropertyRequired = table.Column<string>(nullable: false),
                    DateProperty = table.Column<DateTime>(type: "date", nullable: false),
                    DatePropertyNullable = table.Column<DateTime>(type: "date", nullable: true),
                    DateTimeProperty = table.Column<DateTime>(nullable: false),
                    DateTimePropertyNullable = table.Column<DateTime>(nullable: true),
                    TimeSpanProperty = table.Column<TimeSpan>(nullable: false),
                    TimeSpanPropertyNullable = table.Column<TimeSpan>(nullable: true),
                    FloatProperty = table.Column<float>(nullable: false),
                    FloatPropertyNullable = table.Column<float>(nullable: true),
                    DoubleProperty = table.Column<double>(nullable: false),
                    DoublePropertyNullable = table.Column<double>(nullable: true),
                    LongProperty = table.Column<long>(nullable: false),
                    LongPropertyNullable = table.Column<long>(nullable: true),
                    DecimalProperty = table.Column<decimal>(nullable: false),
                    DecimalLowerPrecisionProperty = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    DecimalPropertyNullable = table.Column<decimal>(nullable: true),
                    BoolProperty = table.Column<bool>(nullable: false),
                    BoolPropertyNullable = table.Column<bool>(nullable: true),
                    CharProperty = table.Column<string>(nullable: false),
                    CharPropertyNullable = table.Column<string>(nullable: true),
                    ArrayBytesProperty = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTODataType", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DTODataType");
        }
    }
}
