using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class audittocompanymodelchangetostringapikey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserId",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByApiKey",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedApiKey",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 1,
                columns: new[] { "CreatedByApiKey", "CreatedDate", "LastModifiedApiKey", "LastModifiedDate" },
                values: new object[] { "a2229196-5eb8-4a14-a234-b5451df0a08b", new DateTime(2022, 3, 8, 0, 47, 1, 301, DateTimeKind.Local).AddTicks(3838), "a2229196-5eb8-4a14-a234-b5451df0a08b", new DateTime(2022, 3, 8, 0, 47, 1, 301, DateTimeKind.Local).AddTicks(3838) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 2,
                columns: new[] { "CreatedByApiKey", "CreatedDate", "LastModifiedApiKey", "LastModifiedDate" },
                values: new object[] { "a2229196-5eb8-4a14-a234-b5451df0a08b", new DateTime(2022, 3, 8, 0, 47, 1, 301, DateTimeKind.Local).AddTicks(3838), "a2229196-5eb8-4a14-a234-b5451df0a08b", new DateTime(2022, 3, 8, 0, 47, 1, 301, DateTimeKind.Local).AddTicks(3838) });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3,
                columns: new[] { "CreatedByApiKey", "CreatedDate", "LastModifiedApiKey", "LastModifiedDate" },
                values: new object[] { "a2229196-5eb8-4a14-a234-b5451df0a08b", new DateTime(2022, 3, 8, 0, 47, 1, 301, DateTimeKind.Local).AddTicks(3838), "a2229196-5eb8-4a14-a234-b5451df0a08b", new DateTime(2022, 3, 8, 0, 47, 1, 301, DateTimeKind.Local).AddTicks(3838) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByApiKey",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LastModifiedApiKey",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
