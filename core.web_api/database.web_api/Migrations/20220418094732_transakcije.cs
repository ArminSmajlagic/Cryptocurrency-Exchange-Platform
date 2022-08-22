using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.trading.Migrations
{
    /// <inheritdoc />
    public partial class transakcije : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transakcije_valute_iz_valutaId",
                table: "transakcije");

            migrationBuilder.DropForeignKey(
                name: "FK_transakcije_valute_u_valutaId",
                table: "transakcije");

            migrationBuilder.DropForeignKey(
                name: "FK_valute_ponude_ponudaid",
                table: "valute");

            migrationBuilder.DropIndex(
                name: "IX_transakcije_iz_valutaId",
                table: "transakcije");

            migrationBuilder.DropColumn(
                name: "iz_valutaId",
                table: "transakcije");

            migrationBuilder.RenameColumn(
                name: "ponudaid",
                table: "valute",
                newName: "ponudaId");

            migrationBuilder.RenameIndex(
                name: "IX_valute_ponudaid",
                table: "valute",
                newName: "IX_valute_ponudaId");

            migrationBuilder.RenameColumn(
                name: "u_valutaId",
                table: "transakcije",
                newName: "valutaId");

            migrationBuilder.RenameIndex(
                name: "IX_transakcije_u_valutaId",
                table: "transakcije",
                newName: "IX_transakcije_valutaId");

            migrationBuilder.RenameColumn(
                name: "tip",
                table: "tipTransakcije",
                newName: "tip_placanja");

            migrationBuilder.AlterColumn<int>(
                name: "ponudaId",
                table: "valute",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "kolicinaValute",
                table: "transakcije",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "placeno",
                table: "transakcije",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_transakcije_valute_valutaId",
                table: "transakcije",
                column: "valutaId",
                principalTable: "valute",
                principalColumn: "valuta_id");

            migrationBuilder.AddForeignKey(
                name: "FK_valute_ponude_ponudaId",
                table: "valute",
                column: "ponudaId",
                principalTable: "ponude",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transakcije_valute_valutaId",
                table: "transakcije");

            migrationBuilder.DropForeignKey(
                name: "FK_valute_ponude_ponudaId",
                table: "valute");

            migrationBuilder.DropColumn(
                name: "kolicinaValute",
                table: "transakcije");

            migrationBuilder.DropColumn(
                name: "placeno",
                table: "transakcije");

            migrationBuilder.RenameColumn(
                name: "ponudaId",
                table: "valute",
                newName: "ponudaid");

            migrationBuilder.RenameIndex(
                name: "IX_valute_ponudaId",
                table: "valute",
                newName: "IX_valute_ponudaid");

            migrationBuilder.RenameColumn(
                name: "valutaId",
                table: "transakcije",
                newName: "u_valutaId");

            migrationBuilder.RenameIndex(
                name: "IX_transakcije_valutaId",
                table: "transakcije",
                newName: "IX_transakcije_u_valutaId");

            migrationBuilder.RenameColumn(
                name: "tip_placanja",
                table: "tipTransakcije",
                newName: "tip");

            migrationBuilder.AlterColumn<int>(
                name: "ponudaid",
                table: "valute",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "iz_valutaId",
                table: "transakcije",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_transakcije_iz_valutaId",
                table: "transakcije",
                column: "iz_valutaId");

            migrationBuilder.AddForeignKey(
                name: "FK_transakcije_valute_iz_valutaId",
                table: "transakcije",
                column: "iz_valutaId",
                principalTable: "valute",
                principalColumn: "valuta_id");

            migrationBuilder.AddForeignKey(
                name: "FK_transakcije_valute_u_valutaId",
                table: "transakcije",
                column: "u_valutaId",
                principalTable: "valute",
                principalColumn: "valuta_id");

            migrationBuilder.AddForeignKey(
                name: "FK_valute_ponude_ponudaid",
                table: "valute",
                column: "ponudaid",
                principalTable: "ponude",
                principalColumn: "id");
        }
    }
}
