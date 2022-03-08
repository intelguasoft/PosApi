using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class addauditfieldstocompanymodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 11, 47, 43, 314, DateTimeKind.Local).AddTicks(4635), new DateTime(2022, 3, 8, 11, 47, 43, 314, DateTimeKind.Local).AddTicks(4635) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 11, 47, 43, 314, DateTimeKind.Local).AddTicks(4635), new DateTime(2022, 3, 8, 11, 47, 43, 314, DateTimeKind.Local).AddTicks(4635) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 11, 47, 43, 314, DateTimeKind.Local).AddTicks(4635), new DateTime(2022, 3, 8, 11, 47, 43, 314, DateTimeKind.Local).AddTicks(4635) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
