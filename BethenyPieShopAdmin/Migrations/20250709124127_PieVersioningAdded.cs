using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BethenyPieShopAdmin.Migrations
{
    /// <inheritdoc />
    public partial class PieVersioningAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Pies",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Pies");
        }
    }
}
