using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBTWActivityNDestination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                column: "DestinationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                column: "DestinationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3,
                column: "DestinationId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_DestinationId",
                table: "Activities",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Destinations_DestinationId",
                table: "Activities",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Destinations_DestinationId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_DestinationId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Activities");
        }
    }
}
