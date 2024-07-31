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
                keyValue: "1a12bf3b-5dae-45d6-a981-b812a6a92dbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1ce1aa2-1838-48db-b5e1-8b5fc6d3bc67");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ddd970e-c70f-4d33-b36f-eca0f6cf8362", null, "Admin", "ADMIN" },
                    { "a48e8e76-3838-405b-b34c-8d7f13d6696c", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ddd970e-c70f-4d33-b36f-eca0f6cf8362");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a48e8e76-3838-405b-b34c-8d7f13d6696c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a12bf3b-5dae-45d6-a981-b812a6a92dbf", null, "Admin", "ADMIN" },
                    { "d1ce1aa2-1838-48db-b5e1-8b5fc6d3bc67", null, "User", "USER" }
                });
        }
    }
}
