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
                keyValue: "02e93558-cf0d-4efc-bff3-b8690626c1e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "998dccf6-abf6-47c1-b54c-cadbc1a97125");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0940d1fb-6c5c-490b-b2eb-5057187984ab", null, "User", "USER" },
                    { "195983d7-fc96-4d81-bc61-c9acfdda88bc", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0940d1fb-6c5c-490b-b2eb-5057187984ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "195983d7-fc96-4d81-bc61-c9acfdda88bc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02e93558-cf0d-4efc-bff3-b8690626c1e3", null, "Admin", "ADMIN" },
                    { "998dccf6-abf6-47c1-b54c-cadbc1a97125", null, "User", "USER" }
                });
        }
    }
}
