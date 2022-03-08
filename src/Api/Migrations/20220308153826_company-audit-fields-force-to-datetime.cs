using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class companyauditfieldsforcetodatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Companies",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Companies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

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
    }
}
