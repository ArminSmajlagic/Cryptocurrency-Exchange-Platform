using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.trading.Migrations
{
    /// <inheritdoc />
    public partial class narudzba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_narudzbe_userId",
                table: "narudzbe",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_narudzbe_valutaId",
                table: "narudzbe",
                column: "valutaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "narudzbe");
        }
    }
}
