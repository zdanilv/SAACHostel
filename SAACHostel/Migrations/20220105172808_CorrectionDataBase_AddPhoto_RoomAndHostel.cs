using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAACHostel.Migrations
{
    public partial class CorrectionDataBase_AddPhoto_RoomAndHostel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "Specialtys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo_1",
                table: "Rooms",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo_2",
                table: "Rooms",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo_3",
                table: "Rooms",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo_4",
                table: "Rooms",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo_5",
                table: "Rooms",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "Rooms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo_1",
                table: "Hostels",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo_2",
                table: "Hostels",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo_3",
                table: "Hostels",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo_4",
                table: "Hostels",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo_5",
                table: "Hostels",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "Facultys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_User_ID",
                table: "Students",
                column: "User_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialtys_User_ID",
                table: "Specialtys",
                column: "User_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_User_ID",
                table: "Rooms",
                column: "User_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facultys_User_ID",
                table: "Facultys",
                column: "User_ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Facultys_Users_User_ID",
                table: "Facultys",
                column: "User_ID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_User_ID",
                table: "Rooms",
                column: "User_ID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialtys_Users_User_ID",
                table: "Specialtys",
                column: "User_ID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_User_ID",
                table: "Students",
                column: "User_ID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facultys_Users_User_ID",
                table: "Facultys");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_User_ID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialtys_Users_User_ID",
                table: "Specialtys");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_User_ID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_User_ID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Specialtys_User_ID",
                table: "Specialtys");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_User_ID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Facultys_User_ID",
                table: "Facultys");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Specialtys");

            migrationBuilder.DropColumn(
                name: "Photo_1",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Photo_2",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Photo_3",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Photo_4",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Photo_5",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Photo_1",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "Photo_2",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "Photo_3",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "Photo_4",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "Photo_5",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Facultys");
        }
    }
}
