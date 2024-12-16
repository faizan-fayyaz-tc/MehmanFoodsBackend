using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MehmanFoods.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addinvoicetoorderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvoiceNo",
                table: "Orders",
                newName: "InvoiceId");

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InvoiceId",
                table: "Orders",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Invoice_InvoiceId",
                table: "Orders",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Invoice_InvoiceId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Orders_InvoiceId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "Orders",
                newName: "InvoiceNo");
        }
    }
}
