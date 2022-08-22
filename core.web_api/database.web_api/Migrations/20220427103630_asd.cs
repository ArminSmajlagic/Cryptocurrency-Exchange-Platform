using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.trading.Migrations
{
    /// <inheritdoc />
    public partial class asd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tip_transakcije_id",
                table: "transakcije",
                newName: "tipTransakcijeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tipTransakcijeID",
                table: "transakcije",
                newName: "tip_transakcije_id");
        }
    }
}
