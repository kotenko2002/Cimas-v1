using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cimas.Storage.Migrations
{
    public partial class fixConnectionWorkday_Report : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Report_WorkDayId",
                table: "Report");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "SessionSeat",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Report_WorkDayId",
                table: "Report",
                column: "WorkDayId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Report_WorkDayId",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "SessionSeat");

            migrationBuilder.CreateIndex(
                name: "IX_Report_WorkDayId",
                table: "Report",
                column: "WorkDayId");
        }
    }
}
