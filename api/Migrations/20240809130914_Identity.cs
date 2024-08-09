using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f84169f-44a4-4abb-8b9e-800e2f95e63c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1904231-27db-4bca-8213-ecd46b7a53f3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f1d53e2-391c-4816-aaa8-1bc84f007797", null, "Admin", "ADMIN" },
                    { "a60bdf23-001e-4623-a5b9-1dac6fa50478", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f1d53e2-391c-4816-aaa8-1bc84f007797");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a60bdf23-001e-4623-a5b9-1dac6fa50478");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f84169f-44a4-4abb-8b9e-800e2f95e63c", null, "Admin", "ADMIN" },
                    { "e1904231-27db-4bca-8213-ecd46b7a53f3", null, "User", "USER" }
                });
        }
    }
}
