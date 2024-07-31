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
                    { "4567c27b-2748-4654-836f-08f79ec6c157", null, "Admin", "ADMIN" },
                    { "d7149c30-7275-4ac3-b2fd-90051b99dc0e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4567c27b-2748-4654-836f-08f79ec6c157");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7149c30-7275-4ac3-b2fd-90051b99dc0e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ddd970e-c70f-4d33-b36f-eca0f6cf8362", null, "Admin", "ADMIN" },
                    { "a48e8e76-3838-405b-b34c-8d7f13d6696c", null, "User", "USER" }
                });
        }
    }
}
