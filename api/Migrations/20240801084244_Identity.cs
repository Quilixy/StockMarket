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
                    { "71e6a43e-6d59-4d1a-8ec3-3dab05970c83", null, "User", "USER" },
                    { "780a8bac-2df5-4e8e-b3d7-0c761bb956af", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71e6a43e-6d59-4d1a-8ec3-3dab05970c83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "780a8bac-2df5-4e8e-b3d7-0c761bb956af");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07e37883-9cc7-4c84-b04b-1bef060e570c", null, "Admin", "ADMIN" },
                    { "9e6b2324-0c62-47a9-adbb-d53bf8aa4543", null, "User", "USER" }
                });
        }
    }
}
