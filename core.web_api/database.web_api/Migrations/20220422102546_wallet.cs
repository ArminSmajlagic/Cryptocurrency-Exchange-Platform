using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.trading.Migrations
{
    /// <inheritdoc />
    public partial class wallet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_korisnici_kreditneKartice_kreditnaId",
                table: "korisnici");

            migrationBuilder.DropForeignKey(
                name: "FK_transakcije_korisnici_userId",
                table: "transakcije");

            migrationBuilder.DropForeignKey(
                name: "FK_transakcije_tipTransakcije_tipTransakcijeID",
                table: "transakcije");

            migrationBuilder.DropTable(
                name: "tipTransakcije");

            migrationBuilder.DropIndex(
                name: "IX_transakcije_tipTransakcijeID",
                table: "transakcije");

            migrationBuilder.DropIndex(
                name: "IX_transakcije_userId",
                table: "transakcije");

            migrationBuilder.DropIndex(
                name: "IX_korisnici_kreditnaId",
                table: "korisnici");

            migrationBuilder.DropColumn(
                name: "nazivValutePlacanje",
                table: "transakcije");

            migrationBuilder.DropColumn(
                name: "tipTransakcijeID",
                table: "transakcije");

            migrationBuilder.DropColumn(
                name: "kreditnaId",
                table: "korisnici");

            migrationBuilder.DropColumn(
                name: "stanje_walleta",
                table: "korisnici");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "transakcije",
                newName: "tip_transakcije_id");

            migrationBuilder.AddColumn<int>(
                name: "walletId",
                table: "transakcije",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "walleti",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    kreditnaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_walleti", x => x.id);
                    table.ForeignKey(
                        name: "FK_walleti_korisnici_userId",
                        column: x => x.userId,
                        principalTable: "korisnici",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_walleti_kreditneKartice_kreditnaId",
                        column: x => x.kreditnaId,
                        principalTable: "kreditneKartice",
                        principalColumn: "kreditna_id");
                });

            migrationBuilder.CreateTable(
                name: "wallet_imovine",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv_valute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kolicina_valute = table.Column<double>(type: "float", nullable: false),
                    walletid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallet_imovine", x => x.id);
                    table.ForeignKey(
                        name: "FK_wallet_imovine_walleti_walletid",
                        column: x => x.walletid,
                        principalTable: "walleti",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "wallet_transakcije",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    walletId = table.Column<int>(type: "int", nullable: false),
                    vrijeme_obavljanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    kolicina_transakcije = table.Column<double>(type: "float", nullable: false),
                    naziv_valute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tip_transakcije_id = table.Column<int>(type: "int", nullable: false),
                    tip_metode_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallet_transakcije", x => x.id);
                    table.ForeignKey(
                        name: "FK_wallet_transakcije_walleti_walletId",
                        column: x => x.walletId,
                        principalTable: "walleti",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transakcije_walletId",
                table: "transakcije",
                column: "walletId");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_imovine_walletid",
                table: "wallet_imovine",
                column: "walletid");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_transakcije_walletId",
                table: "wallet_transakcije",
                column: "walletId");

            migrationBuilder.CreateIndex(
                name: "IX_walleti_kreditnaId",
                table: "walleti",
                column: "kreditnaId");

            migrationBuilder.CreateIndex(
                name: "IX_walleti_userId",
                table: "walleti",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_transakcije_walleti_walletId",
                table: "transakcije",
                column: "walletId",
                principalTable: "walleti",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transakcije_walleti_walletId",
                table: "transakcije");

            migrationBuilder.DropTable(
                name: "wallet_imovine");

            migrationBuilder.DropTable(
                name: "wallet_transakcije");

            migrationBuilder.DropTable(
                name: "walleti");

            migrationBuilder.DropIndex(
                name: "IX_transakcije_walletId",
                table: "transakcije");

            migrationBuilder.DropColumn(
                name: "walletId",
                table: "transakcije");

            migrationBuilder.RenameColumn(
                name: "tip_transakcije_id",
                table: "transakcije",
                newName: "userId");

            migrationBuilder.AddColumn<string>(
                name: "nazivValutePlacanje",
                table: "transakcije",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "tipTransakcijeID",
                table: "transakcije",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "kreditnaId",
                table: "korisnici",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "stanje_walleta",
                table: "korisnici",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "tipTransakcije",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<int>(type: "int", nullable: false),
                    opis = table.Column<int>(type: "int", nullable: false),
                    tip_placanja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipTransakcije", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transakcije_tipTransakcijeID",
                table: "transakcije",
                column: "tipTransakcijeID");

            migrationBuilder.CreateIndex(
                name: "IX_transakcije_userId",
                table: "transakcije",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_korisnici_kreditnaId",
                table: "korisnici",
                column: "kreditnaId");

            migrationBuilder.AddForeignKey(
                name: "FK_korisnici_kreditneKartice_kreditnaId",
                table: "korisnici",
                column: "kreditnaId",
                principalTable: "kreditneKartice",
                principalColumn: "kreditna_id");

            migrationBuilder.AddForeignKey(
                name: "FK_transakcije_korisnici_userId",
                table: "transakcije",
                column: "userId",
                principalTable: "korisnici",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transakcije_tipTransakcije_tipTransakcijeID",
                table: "transakcije",
                column: "tipTransakcijeID",
                principalTable: "tipTransakcije",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
