using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac252722-0222-4f95-b1f6-ab52e7d90518");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5a24abb-6af5-4c9e-9e1b-4d3423297428");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f84169f-44a4-4abb-8b9e-800e2f95e63c", null, "Admin", "ADMIN" },
                    { "e1904231-27db-4bca-8213-ecd46b7a53f3", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "ac252722-0222-4f95-b1f6-ab52e7d90518", null, "User", "USER" },
                    { "f5a24abb-6af5-4c9e-9e1b-4d3423297428", null, "Admin", "ADMIN" }
                });
        }
    }
}
