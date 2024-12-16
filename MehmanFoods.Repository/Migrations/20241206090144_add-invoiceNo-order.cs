using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MehmanFoods.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addinvoiceNoorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNo",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices",
                column: "OrderId",
                unique: true);
        }
    }
}
