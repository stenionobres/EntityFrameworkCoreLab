using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Ebay
{
    public partial class AddCustomerAuditing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "common",
                table: "Customer",
                nullable: false,
                defaultValue: "some_id_of_user");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "common",
                table: "Customer",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "common",
                table: "Customer",
                nullable: false,
                defaultValue: "some_id_of_user");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "common",
                table: "Customer",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "common",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                schema: "common",
                table: "Customer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "common",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "common",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "common",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "common",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "common",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                schema: "common",
                table: "Customer");
        }
    }
}
