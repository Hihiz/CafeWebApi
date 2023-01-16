using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypesDish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesDish", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breakfasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TypeDishId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakfasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breakfasts_TypesDish_TypeDishId",
                        column: x => x.TypeDishId,
                        principalTable: "TypesDish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TypesDish",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Мясной" },
                    { 2, "Сырный" },
                    { 3, "Зеленый" }
                });

            migrationBuilder.InsertData(
                table: "Breakfasts",
                columns: new[] { "Id", "Description", "Name", "TypeDishId" },
                values: new object[,]
                {
                    { 1, "Суп являются основным первым блюдом любого обеденного комплекса. Каждая кухня мира предлагает множество разнообразных рецептов, которые кардинально отличаются. Это позволяет не только насытить организм, но и разнообразить свой рацион, удовлетворив вкусовые предпочтения даже наиболее изысканных гурманов.", "Суп", 1 },
                    { 2, "Соус (в перевод с французского языка sauce означает «поливку») представляет собой дополнение к блюду/гарниру. С помощью него удается сделать блюдо более привлекательным и повысить его калорийность.", "Соус", 2 },
                    { 3, "Одним из наиболее любимых видов первых блюд большинства людей считается борщ.", "Борщ", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breakfasts_TypeDishId",
                table: "Breakfasts",
                column: "TypeDishId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breakfasts");

            migrationBuilder.DropTable(
                name: "TypesDish");
        }
    }
}
