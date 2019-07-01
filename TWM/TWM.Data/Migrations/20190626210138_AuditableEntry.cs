using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TWM.Data.Migrations
{
    public partial class AuditableEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Trip",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Trip",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Trip",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Trip",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Stop",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Stop",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Stop",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Stop",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Location",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Location",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Location",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Stop");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Stop");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Stop");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Stop");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Location");
        }
    }
}
