using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.Migrations
{
    /// <inheritdoc />
    public partial class checkdbagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "be1ac79d-32e8-4e68-a8e0-a9691ee0dd53", "b527d1f9-8090-43d0-94a9-dbebba0996f7", "administrator", "ADMINISTRATOR" },
                    { "d45c288a-a497-4f96-ae0e-980fdb1b5085", "39c934f4-0301-42fe-9ce4-24f86adfa998", "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be1ac79d-32e8-4e68-a8e0-a9691ee0dd53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d45c288a-a497-4f96-ae0e-980fdb1b5085");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05b90590-b4a8-4de6-8123-7d2ee239226d", "3ae6f8a1-90b1-4289-9917-493f824e02b5", "administrator", "ADMINISTRATOR" },
                    { "b5bf486e-8b2c-4864-8f14-9e878d6033f5", "77877c13-931f-4ad8-97ee-8ebd59fcea8f", "user", "USER" }
                });
        }
    }
}
