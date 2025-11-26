using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeForeignKeyOfActivityBooked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityBooked_Bookings_BookId",
                table: "ActivityBooked");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "ActivityBooked",
                newName: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityBooked_Bookings_BookingId",
                table: "ActivityBooked",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityBooked_Bookings_BookingId",
                table: "ActivityBooked");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "ActivityBooked",
                newName: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityBooked_Bookings_BookId",
                table: "ActivityBooked",
                column: "BookId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
