using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class mjau2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reports",
                newName: "PatientId");

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "Reports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Reports_AppointmentId",
                table: "Reports",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Appointments_AppointmentId",
                table: "Reports",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Appointments_AppointmentId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_AppointmentId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Reports",
                newName: "UserId");
        }
    }
}
