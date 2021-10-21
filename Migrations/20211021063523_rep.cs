using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalRepSchedule.Migrations
{
    public partial class rep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorDatas",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatingAilment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDatas", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "MedicinestockTable",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChemicalComposition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfTabletsInStock = table.Column<int>(type: "int", nullable: false),
                    TargetAilment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinestockTable", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "RepresentativeSchedule",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingSlot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfMeeting = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatingAilment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepresentativeSchedule", x => x.ScheduleId);
                });

            migrationBuilder.InsertData(
                table: "DoctorDatas",
                columns: new[] { "DoctorId", "DoctorContactNumber", "DoctorName", "TreatingAilment" },
                values: new object[,]
                {
                    { 100, "9884122113", "D1", "Orthopaedics" },
                    { 101, "9876543210", "D2", "General" },
                    { 102, "9876543211", "D3", "General" },
                    { 103, "9876543212", "D4", "Orthopaedics" },
                    { 104, "9876543213", "D5", "Gynaecology" }
                });

            migrationBuilder.InsertData(
                table: "MedicinestockTable",
                columns: new[] { "Name", "ChemicalComposition", "DateOfExpiry", "NumberOfTabletsInStock", "TargetAilment" },
                values: new object[,]
                {
                    { "Dolo 650", "Paracetamol,Acetaminophen", new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 300, "General" },
                    { "Orthoherb", "Castor Plant,Adulsa,Neem,Guggul", new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 190, "Orthopaedics" },
                    { "Cholecalciferol", "Ergocalciferol,Cholecalciferol,22-DiHydroergoCalciferol", new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, "Orthopaedics" },
                    { "Gaviscon", "Magnesium,Oxide,Silicon,Sodium", new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, "General" },
                    { "Hilact", "Pancreatin,Dimethicone,Polydimethylsiloxane", new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 400, "Gynaecology" },
                    { "Cyclopam", "Dicyclomine,Hydrochloride,Paracetamol", new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 500, "Gynaecology" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorDatas");

            migrationBuilder.DropTable(
                name: "MedicinestockTable");

            migrationBuilder.DropTable(
                name: "RepresentativeSchedule");
        }
    }
}
