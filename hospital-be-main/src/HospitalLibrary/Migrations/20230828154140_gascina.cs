using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class gascina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropColumn(
                name: "MJAUUU",
                table: "Admins");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Reports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "Reports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AdminId",
                table: "Notifications",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DoctorId",
                table: "Reports",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_PatientId",
                table: "Reports",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AdminId",
                table: "Notifications",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Directions_PatientId",
                table: "Directions",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directions_Patients_PatientId",
                table: "Directions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Admins_AdminId",
                table: "Notifications",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Doctors_DoctorId",
                table: "Reports",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Patients_PatientId",
                table: "Reports",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directions_Patients_PatientId",
                table: "Directions");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Admins_AdminId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Doctors_DoctorId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Patients_PatientId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_DoctorId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_PatientId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_AdminId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Directions_PatientId",
                table: "Directions");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Reports",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "DoctorId",
                table: "Reports",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdminId",
                table: "Notifications",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "MJAUUU",
                table: "Admins",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Floor = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "Number" },
                values: new object[,]
                {
                    { 1, 1, "101A" },
                    { 2, 2, "204" },
                    { 3, 3, "305B" }
                });
        }
    }
}
