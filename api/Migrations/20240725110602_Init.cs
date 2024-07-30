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
                keyValue: "4fcd3776-a248-48b2-98a9-becfa582da62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba3adf2b-d6cd-4f29-a4db-6ff5525e2a4c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50740e58-7bd6-4661-9b2e-1f3d99de20e6", null, "User", "USER" },
                    { "c0555763-8299-4eb8-8f74-5370f8f9fb40", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50740e58-7bd6-4661-9b2e-1f3d99de20e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0555763-8299-4eb8-8f74-5370f8f9fb40");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4fcd3776-a248-48b2-98a9-becfa582da62", null, "User", "USER" },
                    { "ba3adf2b-d6cd-4f29-a4db-6ff5525e2a4c", null, "Admin", "ADMIN" }
                });
        }
    }
}
