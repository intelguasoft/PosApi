using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class companyauditfieldsforcetovarchar100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedApiKey",
                table: "Companies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByApiKey",
                table: "Companies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 11, 13, 24, 892, DateTimeKind.Local).AddTicks(8510), new DateTime(2022, 3, 8, 11, 13, 24, 892, DateTimeKind.Local).AddTicks(8510) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 11, 13, 24, 892, DateTimeKind.Local).AddTicks(8510), new DateTime(2022, 3, 8, 11, 13, 24, 892, DateTimeKind.Local).AddTicks(8510) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 11, 13, 24, 892, DateTimeKind.Local).AddTicks(8510), new DateTime(2022, 3, 8, 11, 13, 24, 892, DateTimeKind.Local).AddTicks(8510) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedApiKey",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByApiKey",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 9, 38, 25, 905, DateTimeKind.Local).AddTicks(6910), new DateTime(2022, 3, 8, 9, 38, 25, 905, DateTimeKind.Local).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 9, 38, 25, 905, DateTimeKind.Local).AddTicks(6910), new DateTime(2022, 3, 8, 9, 38, 25, 905, DateTimeKind.Local).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 9, 38, 25, 905, DateTimeKind.Local).AddTicks(6910), new DateTime(2022, 3, 8, 9, 38, 25, 905, DateTimeKind.Local).AddTicks(6910) });
        }
    }
}
