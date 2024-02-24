using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaSalon.Database.Migrations
{
    /// <inheritdoc />
    public partial class BookingsForMassageNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "MassageNames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MassageNames",
                table: "MassageNames",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MassageNames",
                table: "MassageNames");

            migrationBuilder.RenameTable(
                name: "MassageNames",
                newName: "Bookings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");
        }
    }
}
