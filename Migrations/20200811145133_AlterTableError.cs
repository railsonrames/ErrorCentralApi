using Microsoft.EntityFrameworkCore.Migrations;

namespace ErrorCentralApi.Migrations
{
    public partial class AlterTableError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LevelType",
                table: "Errors",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Environment",
                table: "Errors",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Errors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Errors");

            migrationBuilder.AlterColumn<string>(
                name: "LevelType",
                table: "Errors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Environment",
                table: "Errors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
