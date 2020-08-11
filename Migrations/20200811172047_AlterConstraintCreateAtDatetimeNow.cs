using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErrorCentralApi.Migrations
{
    public partial class AlterConstraintCreateAtDatetimeNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Errors",
                nullable: false,
                defaultValueSql: "CONVERT(datetime, GETDATE())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Errors",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "CONVERT(datetime, GETDATE())");
        }
    }
}
