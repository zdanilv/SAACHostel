using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAACHostel.Migrations
{
    public partial class CorrectionDataBase_AddDateCreate_AddCountRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date_ext",
                table: "LogEntrys",
                newName: "Date_Ext");

            migrationBuilder.RenameColumn(
                name: "Date_ent",
                table: "LogEntrys",
                newName: "Date_Ent");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Create",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Create",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Create",
                table: "Specialtys",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Create",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Create",
                table: "LogEntrys",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Count_Room",
                table: "Hostels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Create",
                table: "Hostels",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Create",
                table: "Facultys",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date_Create",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Date_Create",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Date_Create",
                table: "Specialtys");

            migrationBuilder.DropColumn(
                name: "Date_Create",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Date_Create",
                table: "LogEntrys");

            migrationBuilder.DropColumn(
                name: "Count_Room",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "Date_Create",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "Date_Create",
                table: "Facultys");

            migrationBuilder.RenameColumn(
                name: "Date_Ext",
                table: "LogEntrys",
                newName: "Date_ext");

            migrationBuilder.RenameColumn(
                name: "Date_Ent",
                table: "LogEntrys",
                newName: "Date_ent");
        }
    }
}
