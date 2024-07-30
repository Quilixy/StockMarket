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
                keyValue: "28d0d96d-5bca-47a9-b3d0-2dfd9e97de4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b4e42e5-b6e2-473a-b854-f703c385a893");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02e93558-cf0d-4efc-bff3-b8690626c1e3", null, "Admin", "ADMIN" },
                    { "998dccf6-abf6-47c1-b54c-cadbc1a97125", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "28d0d96d-5bca-47a9-b3d0-2dfd9e97de4f", null, "Admin", "ADMIN" },
                    { "8b4e42e5-b6e2-473a-b854-f703c385a893", null, "User", "USER" }
                });
        }
    }
}
