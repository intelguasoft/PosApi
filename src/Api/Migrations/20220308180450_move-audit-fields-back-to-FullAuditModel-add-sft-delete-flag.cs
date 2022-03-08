using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class moveauditfieldsbacktoFullAuditModeladdsftdeleteflag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Companies");

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
    }
}
