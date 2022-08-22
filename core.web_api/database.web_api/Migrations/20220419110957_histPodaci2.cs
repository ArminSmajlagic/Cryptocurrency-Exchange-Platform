using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace database.trading.Migrations
{
    /// <inheritdoc />
    public partial class histPodaci2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "open",
                table: "histPodaci",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "open",
                table: "histPodaci");
        }
    }
}
