using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAACHostel.Migrations
{
    public partial class PreFinalCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facultys_Users_UserID",
                table: "Facultys");

            migrationBuilder.DropForeignKey(
                name: "FK_Hostels_LogEntrys_LogEntryID",
                table: "Hostels");

            migrationBuilder.DropForeignKey(
                name: "FK_Hostels_Users_UserID",
                table: "Hostels");

            migrationBuilder.DropForeignKey(
                name: "FK_LogEntrys_Users_UserID",
                table: "LogEntrys");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hostels_HostelID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_LogEntrys_LogEntryID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_UserID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialtys_Users_UserID",
                table: "Specialtys");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Facultys_FacultyID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_LogEntrys_LogEntryID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Specialtys_SpecialtyID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Faculty_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LogEntry_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Specialty_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Specialtys");

            migrationBuilder.DropColumn(
                name: "Hostel_ID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "LogEntry_ID",
                table: "Rooms");

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
                name: "Hostel_ID",
                table: "LogEntrys");

            migrationBuilder.DropColumn(
                name: "LogEntry_ID",
                table: "Hostels");

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
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Facultys");

            migrationBuilder.RenameColumn(
                name: "Short_name",
                table: "Specialtys",
                newName: "Short_Name");

            migrationBuilder.RenameColumn(
                name: "Full_name",
                table: "Specialtys",
                newName: "Full_Name");

            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "LogEntrys",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "Student_ID",
                table: "LogEntrys",
                newName: "RoomID");

            migrationBuilder.RenameColumn(
                name: "Room_ID",
                table: "LogEntrys",
                newName: "HostelID");

            migrationBuilder.RenameColumn(
                name: "Short_name",
                table: "Facultys",
                newName: "Short_Name");

            migrationBuilder.RenameColumn(
                name: "Phone_decane",
                table: "Facultys",
                newName: "Phone_Decane");

            migrationBuilder.RenameColumn(
                name: "Full_name_decan",
                table: "Facultys",
                newName: "Full_Name_Decan");

            migrationBuilder.RenameColumn(
                name: "Full_name",
                table: "Facultys",
                newName: "Full_Name");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SpecialtyID",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LogEntryID",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FacultyID",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Specialtys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Rooms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LogEntryID",
                table: "Rooms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HostelID",
                table: "Rooms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "LogEntrys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Hostels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LogEntryID",
                table: "Hostels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Facultys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Facultys_Users_UserID",
                table: "Facultys",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hostels_LogEntrys_LogEntryID",
                table: "Hostels",
                column: "LogEntryID",
                principalTable: "LogEntrys",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hostels_Users_UserID",
                table: "Hostels",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogEntrys_Users_UserID",
                table: "LogEntrys",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hostels_HostelID",
                table: "Rooms",
                column: "HostelID",
                principalTable: "Hostels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_LogEntrys_LogEntryID",
                table: "Rooms",
                column: "LogEntryID",
                principalTable: "LogEntrys",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_UserID",
                table: "Rooms",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialtys_Users_UserID",
                table: "Specialtys",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Facultys_FacultyID",
                table: "Students",
                column: "FacultyID",
                principalTable: "Facultys",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_LogEntrys_LogEntryID",
                table: "Students",
                column: "LogEntryID",
                principalTable: "LogEntrys",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Specialtys_SpecialtyID",
                table: "Students",
                column: "SpecialtyID",
                principalTable: "Specialtys",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserID",
                table: "Students",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facultys_Users_UserID",
                table: "Facultys");

            migrationBuilder.DropForeignKey(
                name: "FK_Hostels_LogEntrys_LogEntryID",
                table: "Hostels");

            migrationBuilder.DropForeignKey(
                name: "FK_Hostels_Users_UserID",
                table: "Hostels");

            migrationBuilder.DropForeignKey(
                name: "FK_LogEntrys_Users_UserID",
                table: "LogEntrys");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hostels_HostelID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_LogEntrys_LogEntryID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_UserID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialtys_Users_UserID",
                table: "Specialtys");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Facultys_FacultyID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_LogEntrys_LogEntryID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Specialtys_SpecialtyID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Short_Name",
                table: "Specialtys",
                newName: "Short_name");

            migrationBuilder.RenameColumn(
                name: "Full_Name",
                table: "Specialtys",
                newName: "Full_name");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "LogEntrys",
                newName: "User_ID");

            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "LogEntrys",
                newName: "Student_ID");

            migrationBuilder.RenameColumn(
                name: "HostelID",
                table: "LogEntrys",
                newName: "Room_ID");

            migrationBuilder.RenameColumn(
                name: "Short_Name",
                table: "Facultys",
                newName: "Short_name");

            migrationBuilder.RenameColumn(
                name: "Phone_Decane",
                table: "Facultys",
                newName: "Phone_decane");

            migrationBuilder.RenameColumn(
                name: "Full_Name_Decan",
                table: "Facultys",
                newName: "Full_name_decan");

            migrationBuilder.RenameColumn(
                name: "Full_Name",
                table: "Facultys",
                newName: "Full_name");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Students",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialtyID",
                table: "Students",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "LogEntryID",
                table: "Students",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FacultyID",
                table: "Students",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "Faculty_ID",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LogEntry_ID",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Specialty_ID",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Specialtys",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "Specialtys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Rooms",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "LogEntryID",
                table: "Rooms",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "HostelID",
                table: "Rooms",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "Hostel_ID",
                table: "Rooms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LogEntry_ID",
                table: "Rooms",
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

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "LogEntrys",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "Hostel_ID",
                table: "LogEntrys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Hostels",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "LogEntryID",
                table: "Hostels",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "LogEntry_ID",
                table: "Hostels",
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
                table: "Hostels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Facultys",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "Facultys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Facultys_Users_UserID",
                table: "Facultys",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hostels_LogEntrys_LogEntryID",
                table: "Hostels",
                column: "LogEntryID",
                principalTable: "LogEntrys",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hostels_Users_UserID",
                table: "Hostels",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LogEntrys_Users_UserID",
                table: "LogEntrys",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hostels_HostelID",
                table: "Rooms",
                column: "HostelID",
                principalTable: "Hostels",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_LogEntrys_LogEntryID",
                table: "Rooms",
                column: "LogEntryID",
                principalTable: "LogEntrys",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_UserID",
                table: "Rooms",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialtys_Users_UserID",
                table: "Specialtys",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Facultys_FacultyID",
                table: "Students",
                column: "FacultyID",
                principalTable: "Facultys",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_LogEntrys_LogEntryID",
                table: "Students",
                column: "LogEntryID",
                principalTable: "LogEntrys",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Specialtys_SpecialtyID",
                table: "Students",
                column: "SpecialtyID",
                principalTable: "Specialtys",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserID",
                table: "Students",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }
    }
}
