using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class added_additional_seed_employees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "City", "Country", "Name", "Phone", "State", "ZipCode" },
                values: new object[] { 3, "10000 North Loop East", "Houston", "USA", "New Generation Electronics", "866-100-2000", "TX", "77002" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "Phone",
                value: "100-300-0000");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "FirstName", "LastName", "MiddleName", "Phone", "Position" },
                values: new object[,]
                {
                    { 4, 25, 2, "Michael", "Worth", "D", "200-300-0000", "Support I" },
                    { 5, 35, 2, "Nina", "Hawk", "E", "300-300-0000", "Support II" },
                    { 6, 29, 2, "John", "Spike", "F", "400-300-0000", "Support III" },
                    { 7, 20, 2, "Michael", "Fins", "G", "500-300-0000", "Support VI" },
                    { 8, 22, 2, "Martha", "Growns", "H", "500-300-0000", "Developer I" },
                    { 9, 24, 2, "Kirk", "Metha", "H", "600-300-0000", "Developer II" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "FirstName", "LastName", "MiddleName", "Phone", "Position" },
                values: new object[] { 10, 25, 3, "John", "Smith", "I", "500-300-0000", "Developer III" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "FirstName", "LastName", "MiddleName", "Phone", "Position" },
                values: new object[] { 11, 25, 3, "Walter", "White", "J", "600-300-0000", "Developer IV" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "Phone",
                value: "346-300-0000");
        }
    }
}
