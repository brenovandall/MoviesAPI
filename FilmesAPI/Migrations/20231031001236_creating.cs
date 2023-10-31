using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesAPI.Migrations
{
    /// <inheritdoc />
    public partial class creating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Cines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Cines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
