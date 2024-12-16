using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MehmanFoods.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addingdecimalconfilctmodelbuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ProductWholeSalePrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductWholeSalePrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "OrderDetails");
        }
    }
}
