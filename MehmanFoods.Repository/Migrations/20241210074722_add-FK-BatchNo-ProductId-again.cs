using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MehmanFoods.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addFKBatchNoProductIdagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "BatchesNo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BatchesNo_ProductId",
                table: "BatchesNo",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchesNo_Products_ProductId",
                table: "BatchesNo",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchesNo_Products_ProductId",
                table: "BatchesNo");

            migrationBuilder.DropIndex(
                name: "IX_BatchesNo_ProductId",
                table: "BatchesNo");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "BatchesNo");
        }
    }
}
