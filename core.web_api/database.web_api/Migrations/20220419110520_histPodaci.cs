using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.trading.Migrations
{
    /// <inheritdoc />
    public partial class histPodaci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "histPodaci",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    high = table.Column<double>(type: "float", nullable: false),
                    low = table.Column<double>(type: "float", nullable: false),
                    close = table.Column<double>(type: "float", nullable: false),
                    volume = table.Column<int>(type: "int", nullable: false),
                    market_cap = table.Column<int>(type: "int", nullable: false),
                    valutaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_histPodaci", x => x.id);
                    table.ForeignKey(
                        name: "FK_histPodaci_valute_valutaId",
                        column: x => x.valutaId,
                        principalTable: "valute",
                        principalColumn: "valuta_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_histPodaci_valutaId",
                table: "histPodaci",
                column: "valutaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "histPodaci");
        }
    }
}
