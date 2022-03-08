using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class audittocompanymodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedUserId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                columns: new[] { "CreatedByUserId", "CreatedDate", "LastModifiedDate", "LastModifiedUserId" },
                values: new object[] { -1, new DateTime(2022, 3, 7, 23, 43, 21, 771, DateTimeKind.Local).AddTicks(4280), new DateTime(2022, 3, 7, 23, 43, 21, 771, DateTimeKind.Local).AddTicks(4280), -1 });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "CreatedByUserId", "CreatedDate", "LastModifiedDate", "LastModifiedUserId" },
                values: new object[] { -1, new DateTime(2022, 3, 7, 23, 43, 21, 771, DateTimeKind.Local).AddTicks(4280), new DateTime(2022, 3, 7, 23, 43, 21, 771, DateTimeKind.Local).AddTicks(4280), -1 });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3,
                columns: new[] { "CreatedByUserId", "CreatedDate", "LastModifiedDate", "LastModifiedUserId" },
                values: new object[] { -1, new DateTime(2022, 3, 7, 23, 43, 21, 771, DateTimeKind.Local).AddTicks(4280), new DateTime(2022, 3, 7, 23, 43, 21, 771, DateTimeKind.Local).AddTicks(4280), -1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "Companies");
        }
    }
}
