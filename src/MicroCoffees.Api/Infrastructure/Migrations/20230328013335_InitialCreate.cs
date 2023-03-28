using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroCoffees.Api.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
	/// <inheritdoc />
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.CreateTable(
			name: "Coffees",
			columns: table => new
			{
				Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
				ImageUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
				Cost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
				Quantity = table.Column<int>(type: "int", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Coffees", x => x.Id);
			});

		migrationBuilder.CreateTable(
			name: "Ingredients",
			columns: table => new
			{
				Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
				Cost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
				CoffeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Ingredients", x => x.Id);
				table.ForeignKey(
					name: "FK_Ingredients_Coffees_CoffeeId",
					column: x => x.CoffeeId,
					principalTable: "Coffees",
					principalColumn: "Id");
			});

		migrationBuilder.CreateIndex(
			name: "IX_Ingredients_CoffeeId",
			table: "Ingredients",
			column: "CoffeeId");
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropTable(
			name: "Ingredients");

		migrationBuilder.DropTable(
			name: "Coffees");
	}
}
