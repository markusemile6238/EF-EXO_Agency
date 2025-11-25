using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDestinationConfigUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Destinations_Country",
                table: "Destinations");

            migrationBuilder.CreateIndex(
                name: "IX_Destination_Country_City",
                table: "Destinations",
                columns: new[] { "Country", "City" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Destination_Country_City",
                table: "Destinations");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_Country",
                table: "Destinations",
                column: "Country",
                unique: true);
        }
    }
}
