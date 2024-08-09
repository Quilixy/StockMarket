using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "357aaa1b-087f-48a8-aedf-8e032a6a8aa3", null, "Admin", "ADMIN" },
                    { "b224a64a-3f27-4ce7-8b5e-2c1a9a10ec79", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "357aaa1b-087f-48a8-aedf-8e032a6a8aa3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b224a64a-3f27-4ce7-8b5e-2c1a9a10ec79");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f1d53e2-391c-4816-aaa8-1bc84f007797", null, "Admin", "ADMIN" },
                    { "a60bdf23-001e-4623-a5b9-1dac6fa50478", null, "User", "USER" }
                });
        }
    }
}
