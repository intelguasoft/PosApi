using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class addApiKeytoCompanymodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 12, 15, 27, 719, DateTimeKind.Local).AddTicks(47), new DateTime(2022, 3, 8, 12, 15, 27, 719, DateTimeKind.Local).AddTicks(47) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 12, 15, 27, 719, DateTimeKind.Local).AddTicks(47), new DateTime(2022, 3, 8, 12, 15, 27, 719, DateTimeKind.Local).AddTicks(47) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 12, 15, 27, 719, DateTimeKind.Local).AddTicks(47), new DateTime(2022, 3, 8, 12, 15, 27, 719, DateTimeKind.Local).AddTicks(47) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 12, 4, 50, 321, DateTimeKind.Local).AddTicks(4298), new DateTime(2022, 3, 8, 12, 4, 50, 321, DateTimeKind.Local).AddTicks(4298) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 12, 4, 50, 321, DateTimeKind.Local).AddTicks(4298), new DateTime(2022, 3, 8, 12, 4, 50, 321, DateTimeKind.Local).AddTicks(4298) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 12, 4, 50, 321, DateTimeKind.Local).AddTicks(4298), new DateTime(2022, 3, 8, 12, 4, 50, 321, DateTimeKind.Local).AddTicks(4298) });
        }
    }
}
