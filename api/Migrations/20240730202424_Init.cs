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
                keyValue: "7a33dff3-3a28-4e17-a021-c7439ab4717b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da08d8dc-bd69-4325-b5e0-07e6ee7e6e6c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28d0d96d-5bca-47a9-b3d0-2dfd9e97de4f", null, "Admin", "ADMIN" },
                    { "8b4e42e5-b6e2-473a-b854-f703c385a893", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "7a33dff3-3a28-4e17-a021-c7439ab4717b", null, "Admin", "ADMIN" },
                    { "da08d8dc-bd69-4325-b5e0-07e6ee7e6e6c", null, "User", "USER" }
                });
        }
    }
}
