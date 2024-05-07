using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerminaldotNET.Migrations
{
    /// <inheritdoc />
    public partial class KeyArchives : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Archives",
                table: "Archives");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "Archives");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Archives",
                table: "Archives",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Archives",
                table: "Archives");

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "Archives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Archives",
                table: "Archives",
                column: "Index");
        }
    }
}
