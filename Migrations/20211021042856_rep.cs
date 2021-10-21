using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalRepSchedule.Migrations
{
    public partial class rep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MedicinestockTable",
                keyColumn: "Name",
                keyValue: "Dolo 650",
                column: "DateOfExpiry",
                value: new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MedicinestockTable",
                keyColumn: "Name",
                keyValue: "Gaviscon",
                column: "DateOfExpiry",
                value: new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MedicinestockTable",
                keyColumn: "Name",
                keyValue: "Orthoherb",
                column: "DateOfExpiry",
                value: new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MedicinestockTable",
                keyColumn: "Name",
                keyValue: "Dolo 650",
                column: "DateOfExpiry",
                value: new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MedicinestockTable",
                keyColumn: "Name",
                keyValue: "Gaviscon",
                column: "DateOfExpiry",
                value: new DateTime(2022, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MedicinestockTable",
                keyColumn: "Name",
                keyValue: "Orthoherb",
                column: "DateOfExpiry",
                value: new DateTime(2021, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
