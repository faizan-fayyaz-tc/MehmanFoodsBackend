using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MehmanFoods.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addunitbatchIngredintsingredientstables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefaultUnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingredients_Units_DefaultUnitId",
                        column: x => x.DefaultUnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatchIngredients",
                columns: table => new
                {
                    BatchIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    QuantityUsed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceUsed = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchIngredients", x => x.BatchIngredientId);
                    table.ForeignKey(
                        name: "FK_BatchIngredients_Batches_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batches",
                        principalColumn: "BatchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatchIngredients_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatchIngredients_BatchId",
                table: "BatchIngredients",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchIngredients_IngredientId",
                table: "BatchIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchIngredients_UnitId",
                table: "BatchIngredients",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DefaultUnitId",
                table: "Ingredients",
                column: "DefaultUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchIngredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
