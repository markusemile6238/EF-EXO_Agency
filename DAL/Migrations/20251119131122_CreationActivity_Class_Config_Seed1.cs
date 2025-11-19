using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreationActivity_Class_Config_Seed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.CheckConstraint("CK_Activity__Price", "[price] > 0");
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Découvre les monuments les plus célèbres sur visible depuis le bord de la Seine...", 45m, "Visite de Paris en Bateau la nuit" },
                    { 2, "Découvre les monuments tranquillement depuis nos bus a deux étages...", 35m, "Visite de Paris en Bus" },
                    { 3, "Avec notre guide découvrez l'histoire de cette villes...", 60m, "Visite de Bruxelles" }
                });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Découvrez le plat pays a travers nos activité");

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Country", "Description" },
                values: new object[] { "France", "Voyagez a travers nos régions..." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Visite de bruxelles en Bus");

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Country", "Description" },
                values: new object[] { "france", "Croisiere sur la Scène la nuit" });
        }
    }
}
