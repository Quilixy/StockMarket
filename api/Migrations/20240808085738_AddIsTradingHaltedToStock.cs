using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddIsTradingHaltedToStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b31eeff-1a14-4e09-84f0-b0c0360ac184");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed59031e-3b0c-48d9-84ff-04e3f876f08e");

            migrationBuilder.AddColumn<bool>(
                name: "IsTradingHalted",
                table: "Stocks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86a3d13d-e0b6-4315-b5ea-139c3dfda6b9", null, "User", "USER" },
                    { "af97165f-d258-4e17-a8d5-ebfc2b672a7b", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86a3d13d-e0b6-4315-b5ea-139c3dfda6b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af97165f-d258-4e17-a8d5-ebfc2b672a7b");

            migrationBuilder.DropColumn(
                name: "IsTradingHalted",
                table: "Stocks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b31eeff-1a14-4e09-84f0-b0c0360ac184", null, "User", "USER" },
                    { "ed59031e-3b0c-48d9-84ff-04e3f876f08e", null, "Admin", "ADMIN" }
                });
        }
    }
}
