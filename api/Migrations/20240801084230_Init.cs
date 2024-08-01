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
                keyValue: "da6cadbe-7c88-4e4c-89b6-6c6f2a797f3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd879d10-8220-4ad3-97fc-71e28b9c2002");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07e37883-9cc7-4c84-b04b-1bef060e570c", null, "Admin", "ADMIN" },
                    { "9e6b2324-0c62-47a9-adbb-d53bf8aa4543", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07e37883-9cc7-4c84-b04b-1bef060e570c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e6b2324-0c62-47a9-adbb-d53bf8aa4543");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "da6cadbe-7c88-4e4c-89b6-6c6f2a797f3c", null, "Admin", "ADMIN" },
                    { "fd879d10-8220-4ad3-97fc-71e28b9c2002", null, "User", "USER" }
                });
        }
    }
}
