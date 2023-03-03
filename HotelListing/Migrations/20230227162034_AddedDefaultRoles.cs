using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c47b8b6-a529-4c9d-aa11-023486800162", "f998eaac-25d1-4f95-8930-9d571731a30a", "administrator", "ADMINISTRATOR" },
                    { "986beeda-c68b-4001-9cda-4fa665e938d1", "f73a9a41-6795-4081-9cb6-9f7931923eb0", "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c47b8b6-a529-4c9d-aa11-023486800162");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "986beeda-c68b-4001-9cda-4fa665e938d1");
        }
    }
}
