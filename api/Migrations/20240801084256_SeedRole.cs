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
                    { "3b31eeff-1a14-4e09-84f0-b0c0360ac184", null, "User", "USER" },
                    { "ed59031e-3b0c-48d9-84ff-04e3f876f08e", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b31eeff-1a14-4e09-84f0-b0c0360ac184");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed59031e-3b0c-48d9-84ff-04e3f876f08e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "71e6a43e-6d59-4d1a-8ec3-3dab05970c83", null, "User", "USER" },
                    { "780a8bac-2df5-4e8e-b3d7-0c761bb956af", null, "Admin", "ADMIN" }
                });
        }
    }
}
