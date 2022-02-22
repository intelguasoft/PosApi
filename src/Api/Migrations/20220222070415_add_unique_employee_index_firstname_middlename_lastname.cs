using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class add_unique_employee_index_firstname_middlename_lastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_LastName",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FirstName_MiddleName_LastName",
                table: "Employees",
                columns: new[] { "FirstName", "MiddleName", "LastName" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_FirstName_MiddleName_LastName",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LastName",
                table: "Employees",
                column: "LastName",
                unique: true);
        }
    }
}
