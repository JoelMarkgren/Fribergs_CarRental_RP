using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fribergs_CarRental_RP.Migrations
{
    /// <inheritdoc />
    public partial class Available : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Cars_CarId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_CustomerId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CarId",
                table: "Orders",
                newName: "IX_Orders_CarId");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cars_CarId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_CustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Order",
                newName: "IX_Order_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CarId",
                table: "Order",
                newName: "IX_Order_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Cars_CarId",
                table: "Order",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
