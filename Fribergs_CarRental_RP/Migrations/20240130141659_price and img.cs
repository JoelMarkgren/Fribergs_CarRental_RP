using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fribergs_CarRental_RP.Migrations
{
    /// <inheritdoc />
    public partial class priceandimg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarImageUrl",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PricePerDay",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarImageUrl",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "Cars");
        }
    }
}
