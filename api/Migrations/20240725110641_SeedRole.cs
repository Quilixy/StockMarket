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
                keyValue: "3a803384-d1e9-479d-a51f-db36fd9b6390");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91ccd77e-b8b4-4189-890e-f79304395ea0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c5c0fc6-618f-4d02-9a04-9668e01e15b0", null, "Admin", "ADMIN" },
                    { "a08c100e-30e5-4f88-88c0-21fab1eee28d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c5c0fc6-618f-4d02-9a04-9668e01e15b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a08c100e-30e5-4f88-88c0-21fab1eee28d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a803384-d1e9-479d-a51f-db36fd9b6390", null, "User", "USER" },
                    { "91ccd77e-b8b4-4189-890e-f79304395ea0", null, "Admin", "ADMIN" }
                });
        }
    }
}
