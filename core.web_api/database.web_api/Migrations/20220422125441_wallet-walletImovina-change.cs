using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.trading.Migrations
{
    /// <inheritdoc />
    public partial class walletwalletImovinachange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wallet_imovine_walleti_walletid",
                table: "wallet_imovine");

            migrationBuilder.RenameColumn(
                name: "walletid",
                table: "wallet_imovine",
                newName: "walletId");

            migrationBuilder.RenameIndex(
                name: "IX_wallet_imovine_walletid",
                table: "wallet_imovine",
                newName: "IX_wallet_imovine_walletId");

            migrationBuilder.AlterColumn<int>(
                name: "walletId",
                table: "wallet_imovine",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_wallet_imovine_walleti_walletId",
                table: "wallet_imovine",
                column: "walletId",
                principalTable: "walleti",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_wallet_imovine_walleti_walletId",
                table: "wallet_imovine");

            migrationBuilder.RenameColumn(
                name: "walletId",
                table: "wallet_imovine",
                newName: "walletid");

            migrationBuilder.RenameIndex(
                name: "IX_wallet_imovine_walletId",
                table: "wallet_imovine",
                newName: "IX_wallet_imovine_walletid");

            migrationBuilder.AlterColumn<int>(
                name: "walletid",
                table: "wallet_imovine",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_wallet_imovine_walleti_walletid",
                table: "wallet_imovine",
                column: "walletid",
                principalTable: "walleti",
                principalColumn: "id");
        }
    }
}
