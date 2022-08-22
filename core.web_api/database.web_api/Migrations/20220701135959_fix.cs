using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.trading.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transakcije");

            migrationBuilder.AddColumn<DateTime>(
                name: "datum_kreiranja",
                table: "korisnici",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "datum_kreiranja",
                table: "korisnici");

            migrationBuilder.CreateTable(
                name: "transakcije",
                columns: table => new
                {
                    transakcija_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valutaId = table.Column<int>(type: "int", nullable: true),
                    walletId = table.Column<int>(type: "int", nullable: true),
                    kolicinaValute = table.Column<double>(type: "float", nullable: false),
                    placeno = table.Column<double>(type: "float", nullable: false),
                    tipTransakcijeID = table.Column<int>(type: "int", nullable: false),
                    vrijeme_obavljanja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transakcije", x => x.transakcija_id);
                    table.ForeignKey(
                        name: "FK_transakcije_valute_valutaId",
                        column: x => x.valutaId,
                        principalTable: "valute",
                        principalColumn: "valuta_id");
                    table.ForeignKey(
                        name: "FK_transakcije_walleti_walletId",
                        column: x => x.walletId,
                        principalTable: "walleti",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_transakcije_valutaId",
                table: "transakcije",
                column: "valutaId");

            migrationBuilder.CreateIndex(
                name: "IX_transakcije_walletId",
                table: "transakcije",
                column: "walletId");
        }
    }
}
