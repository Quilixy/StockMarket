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
                keyValue: "17d02036-4f48-4e42-aa90-a325053b66ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5f08e24-dd7f-4316-93b9-87e685317819");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a96f8d8-75b7-4b01-a38e-20996b85af06", null, "Admin", "ADMIN" },
                    { "9850cffa-c22f-4613-8c94-3fb807d84753", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a96f8d8-75b7-4b01-a38e-20996b85af06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9850cffa-c22f-4613-8c94-3fb807d84753");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17d02036-4f48-4e42-aa90-a325053b66ff", null, "User", "USER" },
                    { "b5f08e24-dd7f-4316-93b9-87e685317819", null, "Admin", "ADMIN" }
                });
        }
    }
}
