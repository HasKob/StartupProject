using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.Migrations
{
    /// <inheritdoc />
    public partial class checkdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c47b8b6-a529-4c9d-aa11-023486800162");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "986beeda-c68b-4001-9cda-4fa665e938d1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05b90590-b4a8-4de6-8123-7d2ee239226d", "3ae6f8a1-90b1-4289-9917-493f824e02b5", "administrator", "ADMINISTRATOR" },
                    { "b5bf486e-8b2c-4864-8f14-9e878d6033f5", "77877c13-931f-4ad8-97ee-8ebd59fcea8f", "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05b90590-b4a8-4de6-8123-7d2ee239226d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5bf486e-8b2c-4864-8f14-9e878d6033f5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c47b8b6-a529-4c9d-aa11-023486800162", "f998eaac-25d1-4f95-8930-9d571731a30a", "administrator", "ADMINISTRATOR" },
                    { "986beeda-c68b-4001-9cda-4fa665e938d1", "f73a9a41-6795-4081-9cb6-9f7931923eb0", "user", "USER" }
                });
        }
    }
}
