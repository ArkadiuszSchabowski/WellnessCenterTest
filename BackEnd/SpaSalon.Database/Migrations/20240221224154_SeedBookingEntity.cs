using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpaSalon.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedBookingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "Description", "Performer", "Price", "ServiceName", "ServiceTime" },
                values: new object[,]
                {
                    { 1, "Chocolate Massage - Description", 2, 199, "Chocolate Massage", 60 },
                    { 2, "Honey Massage Description", 1, 119, "Honey Massage", 45 },
                    { 3, "Clasic Massage Description", 3, 99, "Classic Massage", 60 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
