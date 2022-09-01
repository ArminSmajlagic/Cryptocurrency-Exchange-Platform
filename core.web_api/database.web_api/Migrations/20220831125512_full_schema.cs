using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.trading.Migrations
{
    /// <inheritdoc />
    public partial class full_schema : Migration
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
                name: "korisnici",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spol = table.Column<int>(type: "int", nullable: false),
                    ime_prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datum_rodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datum_kreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    broj_telefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ponudaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_valute", x => x.valuta_id);
                    table.ForeignKey(
                        name: "FK_valute_ponude_ponudaId",
                        column: x => x.ponudaId,
                        principalTable: "ponude",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    timeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    confirmed = table.Column<bool>(type: "bit", nullable: false)
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
                name: "walleti",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
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

                });

            migrationBuilder.CreateTable(
                name: "histPodaci",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    high = table.Column<double>(type: "float", nullable: false),
                    open = table.Column<double>(type: "float", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "narudzbe",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kreirana = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    valutaId = table.Column<int>(type: "int", nullable: false),
                    kolicina = table.Column<double>(type: "float", nullable: false),
                    cijena = table.Column<double>(type: "float", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_narudzbe", x => x.id);
                    table.ForeignKey(
                        name: "FK_narudzbe_korisnici_userId",
                        column: x => x.userId,
                        principalTable: "korisnici",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_narudzbe_valute_valutaId",
                        column: x => x.valutaId,
                        principalTable: "valute",
                        principalColumn: "valuta_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wallet_imovine",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv_valute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valuta_id = table.Column<int>(type: "int", nullable: false),
                    kolicina_valute = table.Column<double>(type: "float", nullable: false),
                    walletId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallet_imovine", x => x.id);
                    table.ForeignKey(
                        name: "FK_wallet_imovine_walleti_walletId",
                        column: x => x.walletId,
                        principalTable: "walleti",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    wcash = table.Column<double>(type: "float", nullable: false),
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
                name: "IX_histPodaci_valutaId",
                table: "histPodaci",
                column: "valutaId");

            migrationBuilder.CreateIndex(
                name: "IX_korisnici_authUserId",
                table: "korisnici",
                column: "authUserId");

            migrationBuilder.CreateIndex(
                name: "IX_narudzbe_userId",
                table: "narudzbe",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_narudzbe_valutaId",
                table: "narudzbe",
                column: "valutaId");

            migrationBuilder.CreateIndex(
                name: "IX_tokeni_userId",
                table: "tokeni",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_user_confirmacije_userId",
                table: "user_confirmacije",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_valute_ponudaId",
                table: "valute",
                column: "ponudaId");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_imovine_walletId",
                table: "wallet_imovine",
                column: "walletId");

            migrationBuilder.CreateIndex(
                name: "IX_wallet_transakcije_walletId",
                table: "wallet_transakcije",
                column: "walletId");


            migrationBuilder.CreateIndex(
                name: "IX_walleti_userId",
                table: "walleti",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "histPodaci");

            migrationBuilder.DropTable(
                name: "narudzbe");

            migrationBuilder.DropTable(
                name: "tokeni");

            migrationBuilder.DropTable(
                name: "user_confirmacije");

            migrationBuilder.DropTable(
                name: "wallet_imovine");

            migrationBuilder.DropTable(
                name: "wallet_transakcije");

            migrationBuilder.DropTable(
                name: "valute");

            migrationBuilder.DropTable(
                name: "walleti");

            migrationBuilder.DropTable(
                name: "ponude");

            migrationBuilder.DropTable(
                name: "korisnici");

            migrationBuilder.DropTable(
                name: "auth_korisnik");
        }
    }
}
