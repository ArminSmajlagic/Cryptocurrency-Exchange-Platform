using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.trading.Migrations
{
    /// <inheritdoc />
    public partial class inheritencefix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "auth_korisnik",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    lozinka = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_korisnik", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kreditneKartice",
                columns: table => new
                {
                    kreditna_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    broj_kartice = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    naziv_izdavaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datum_isteka = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kreditneKartice", x => x.kreditna_id);
                });

            migrationBuilder.CreateTable(
                name: "ponude",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ponude", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipTransakcije",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<int>(type: "int", nullable: false),
                    opis = table.Column<int>(type: "int", nullable: false),
                    tip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipTransakcije", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "korisnici",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spol = table.Column<int>(type: "int", nullable: false),
                    ime_prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datum_rodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stanje_walleta = table.Column<double>(type: "float", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    broj_telefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kreditnaId = table.Column<int>(type: "int", nullable: true),
                    authUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_korisnici", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_korisnici_auth_korisnik_authUserId",
                        column: x => x.authUserId,
                        principalTable: "auth_korisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_korisnici_kreditneKartice_kreditnaId",
                        column: x => x.kreditnaId,
                        principalTable: "kreditneKartice",
                        principalColumn: "kreditna_id");
                });

            migrationBuilder.CreateTable(
                name: "valute",
                columns: table => new
                {
                    valuta_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    oznaka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vrijednost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    iternval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    promjena = table.Column<double>(type: "float", nullable: false),
                    logo_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rank = table.Column<int>(type: "int", nullable: false),
                    last_high = table.Column<double>(type: "float", nullable: false),
                    total_suplay = table.Column<int>(type: "int", nullable: false),
                    ponudaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valute", x => x.valuta_id);
                    table.ForeignKey(
                        name: "FK_valute_ponude_ponudaid",
                        column: x => x.ponudaid,
                        principalTable: "ponude",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tokeni",
                columns: table => new
                {
                    token_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    issued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expired = table.Column<bool>(type: "bit", nullable: false),
                    valid = table.Column<bool>(type: "bit", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokeni", x => x.token_id);
                    table.ForeignKey(
                        name: "FK_tokeni_korisnici_userId",
                        column: x => x.userId,
                        principalTable: "korisnici",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_confirmacije",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_confirmacije", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_confirmacije_korisnici_userId",
                        column: x => x.userId,
                        principalTable: "korisnici",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transakcije",
                columns: table => new
                {
                    transakcija_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijeme_obavljanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    iz_valutaId = table.Column<int>(type: "int", nullable: true),
                    u_valutaId = table.Column<int>(type: "int", nullable: true),
                    tipTransakcijeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transakcije", x => x.transakcija_id);
                    table.ForeignKey(
                        name: "FK_transakcije_korisnici_userId",
                        column: x => x.userId,
                        principalTable: "korisnici",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transakcije_tipTransakcije_tipTransakcijeID",
                        column: x => x.tipTransakcijeID,
                        principalTable: "tipTransakcije",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transakcije_valute_iz_valutaId",
                        column: x => x.iz_valutaId,
                        principalTable: "valute",
                        principalColumn: "valuta_id");
                    table.ForeignKey(
                        name: "FK_transakcije_valute_u_valutaId",
                        column: x => x.u_valutaId,
                        principalTable: "valute",
                        principalColumn: "valuta_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_korisnici_authUserId",
                table: "korisnici",
                column: "authUserId");

            migrationBuilder.CreateIndex(
                name: "IX_korisnici_kreditnaId",
                table: "korisnici",
                column: "kreditnaId");

            migrationBuilder.CreateIndex(
                name: "IX_tokeni_userId",
                table: "tokeni",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_transakcije_iz_valutaId",
                table: "transakcije",
                column: "iz_valutaId");

            migrationBuilder.CreateIndex(
                name: "IX_transakcije_tipTransakcijeID",
                table: "transakcije",
                column: "tipTransakcijeID");

            migrationBuilder.CreateIndex(
                name: "IX_transakcije_u_valutaId",
                table: "transakcije",
                column: "u_valutaId");

            migrationBuilder.CreateIndex(
                name: "IX_transakcije_userId",
                table: "transakcije",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_user_confirmacije_userId",
                table: "user_confirmacije",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_valute_ponudaid",
                table: "valute",
                column: "ponudaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tokeni");

            migrationBuilder.DropTable(
                name: "transakcije");

            migrationBuilder.DropTable(
                name: "user_confirmacije");

            migrationBuilder.DropTable(
                name: "tipTransakcije");

            migrationBuilder.DropTable(
                name: "valute");

            migrationBuilder.DropTable(
                name: "korisnici");

            migrationBuilder.DropTable(
                name: "ponude");

            migrationBuilder.DropTable(
                name: "auth_korisnik");

            migrationBuilder.DropTable(
                name: "kreditneKartice");
        }
    }
}
