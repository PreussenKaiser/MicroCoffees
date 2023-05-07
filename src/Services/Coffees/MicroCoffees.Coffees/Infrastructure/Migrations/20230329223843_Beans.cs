using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace MicroCoffees.Coffees.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class Beans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.AddColumn<Guid>(
                name: "BeanId",
                table: "Coffees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Beans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Roast = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beans", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Beans",
                columns: new[] { "Id", "Name", "Roast" },
                values: new object[,]
                {
                    { new Guid("591c4786-c6b5-4c88-bb89-58ffd8330340"), "Null Reference Exception", 1 },
                    { new Guid("b8554579-efa2-4262-ba85-eafdd601b443"), "The Daily Standup", 0 },
                    { new Guid("c52b2291-ff7f-48fe-a164-6b91728aef91"), "Stack Overflow Response", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coffees_BeanId",
                table: "Coffees",
                column: "BeanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coffees_Beans_BeanId",
                table: "Coffees",
                column: "BeanId",
                principalTable: "Beans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffees_Beans_BeanId",
                table: "Coffees");

            migrationBuilder.DropTable(
                name: "Beans");

            migrationBuilder.DropIndex(
                name: "IX_Coffees_BeanId",
                table: "Coffees");

            migrationBuilder.DropColumn(
                name: "BeanId",
                table: "Coffees");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Coffees_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_CoffeeId",
                table: "Ingredients",
                column: "CoffeeId");
        }
    }
}
