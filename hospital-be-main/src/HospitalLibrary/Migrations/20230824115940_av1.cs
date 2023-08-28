using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class av1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_InternalDatas_InternalDataId",
                table: "Reports");

            migrationBuilder.AlterColumn<Guid>(
                name: "InternalDataId",
                table: "Reports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "InternalDatas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InternalDatas_PatientId",
                table: "InternalDatas",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_InternalDatas_Patients_PatientId",
                table: "InternalDatas",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_InternalDatas_InternalDataId",
                table: "Reports",
                column: "InternalDataId",
                principalTable: "InternalDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternalDatas_Patients_PatientId",
                table: "InternalDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_InternalDatas_InternalDataId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_InternalDatas_PatientId",
                table: "InternalDatas");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "InternalDatas");

            migrationBuilder.AlterColumn<Guid>(
                name: "InternalDataId",
                table: "Reports",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_InternalDatas_InternalDataId",
                table: "Reports",
                column: "InternalDataId",
                principalTable: "InternalDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
