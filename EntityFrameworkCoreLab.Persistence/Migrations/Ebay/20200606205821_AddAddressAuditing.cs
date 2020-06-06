using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Ebay
{
    public partial class AddAddressAuditing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "common",
                table: "Address",
                nullable: false,
                defaultValue: "some_id_of_user");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "common",
                table: "Address",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "common",
                table: "Address",
                nullable: false,
                defaultValue: "some_id_of_user");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                schema: "common",
                table: "Address",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "common",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                schema: "common",
                table: "Address",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "common",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "common",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "common",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                schema: "common",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "common",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                schema: "common",
                table: "Address");
        }
    }
}
