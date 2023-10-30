﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesAPI.Migrations
{
    /// <inheritdoc />
    public partial class cineandsessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CineId",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CineId",
                table: "Cines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CineId",
                table: "Sessions",
                column: "CineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Cines_CineId",
                table: "Sessions",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Cines_CineId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_CineId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "CineId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "CineId",
                table: "Cines");
        }
    }
}
