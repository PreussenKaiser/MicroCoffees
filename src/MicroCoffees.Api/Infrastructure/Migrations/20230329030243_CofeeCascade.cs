﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroCoffees.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CofeeCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Coffees_CoffeeId",
                table: "Ingredients");

            migrationBuilder.AlterColumn<Guid>(
                name: "CoffeeId",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Coffees_CoffeeId",
                table: "Ingredients",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Coffees_CoffeeId",
                table: "Ingredients");

            migrationBuilder.AlterColumn<Guid>(
                name: "CoffeeId",
                table: "Ingredients",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Coffees_CoffeeId",
                table: "Ingredients",
                column: "CoffeeId",
                principalTable: "Coffees",
                principalColumn: "Id");
        }
    }
}
