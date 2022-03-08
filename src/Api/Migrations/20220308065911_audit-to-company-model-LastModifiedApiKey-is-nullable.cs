using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class audittocompanymodelLastModifiedApiKeyisnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedApiKey",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 0, 59, 10, 846, DateTimeKind.Local).AddTicks(5514), new DateTime(2022, 3, 8, 0, 59, 10, 846, DateTimeKind.Local).AddTicks(5514) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 0, 59, 10, 846, DateTimeKind.Local).AddTicks(5514), new DateTime(2022, 3, 8, 0, 59, 10, 846, DateTimeKind.Local).AddTicks(5514) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 0, 59, 10, 846, DateTimeKind.Local).AddTicks(5514), new DateTime(2022, 3, 8, 0, 59, 10, 846, DateTimeKind.Local).AddTicks(5514) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedApiKey",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 0, 47, 1, 301, DateTimeKind.Local).AddTicks(3838), new DateTime(2022, 3, 8, 0, 47, 1, 301, DateTimeKind.Local).AddTicks(3838) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 0, 47, 1, 301, DateTimeKind.Local).AddTicks(3838), new DateTime(2022, 3, 8, 0, 47, 1, 301, DateTimeKind.Local).AddTicks(3838) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 3, 8, 0, 47, 1, 301, DateTimeKind.Local).AddTicks(3838), new DateTime(2022, 3, 8, 0, 47, 1, 301, DateTimeKind.Local).AddTicks(3838) });
        }
    }
}
