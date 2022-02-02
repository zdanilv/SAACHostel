using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAACHostel.Migrations
{
    public partial class CorrectionModelTablesDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facultys_Users_User_ID",
                table: "Facultys");

            migrationBuilder.DropForeignKey(
                name: "FK_Hostels_Users_User_ID",
                table: "Hostels");

            migrationBuilder.DropForeignKey(
                name: "FK_LogEntrys_Hostels_Hostel_ID",
                table: "LogEntrys");

            migrationBuilder.DropForeignKey(
                name: "FK_LogEntrys_Rooms_Room_ID",
                table: "LogEntrys");

            migrationBuilder.DropForeignKey(
                name: "FK_LogEntrys_Students_Student_ID",
                table: "LogEntrys");

            migrationBuilder.DropForeignKey(
                name: "FK_LogEntrys_Users_User_ID",
                table: "LogEntrys");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_User_ID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialtys_Users_User_ID",
                table: "Specialtys");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Facultys_Faculty_ID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Specialtys_Specialty_ID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_User_ID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Faculty_ID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_Specialty_ID",
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
                name: "IX_LogEntrys_Hostel_ID",
                table: "LogEntrys");

            migrationBuilder.DropIndex(
                name: "IX_LogEntrys_Room_ID",
                table: "LogEntrys");

            migrationBuilder.DropIndex(
                name: "IX_LogEntrys_Student_ID",
                table: "LogEntrys");

            migrationBuilder.DropIndex(
                name: "IX_LogEntrys_User_ID",
                table: "LogEntrys");

            migrationBuilder.DropIndex(
                name: "IX_Hostels_User_ID",
                table: "Hostels");

            migrationBuilder.DropIndex(
                name: "IX_Facultys_User_ID",
                table: "Facultys");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "Users",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "Pasport_ID",
                table: "Students",
                newName: "Passport_ID");

            migrationBuilder.AddColumn<int>(
                name: "FacultyID",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogEntryID",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogEntry_ID",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomID",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyID",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Specialtys",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HostelID",
                table: "Rooms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogEntryID",
                table: "Rooms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogEntry_ID",
                table: "Rooms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Rooms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "LogEntrys",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogEntryID",
                table: "Hostels",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogEntry_ID",
                table: "Hostels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Hostels",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Facultys",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacultyID",
                table: "Students",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_LogEntryID",
                table: "Students",
                column: "LogEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoomID",
                table: "Students",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SpecialtyID",
                table: "Students",
                column: "SpecialtyID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserID",
                table: "Students",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Specialtys_UserID",
                table: "Specialtys",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HostelID",
                table: "Rooms",
                column: "HostelID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LogEntryID",
                table: "Rooms",
                column: "LogEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserID",
                table: "Rooms",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntrys_UserID",
                table: "LogEntrys",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Hostels_LogEntryID",
                table: "Hostels",
                column: "LogEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_Hostels_UserID",
                table: "Hostels",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Facultys_UserID",
                table: "Facultys",
                column: "UserID");

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
                name: "FK_Students_Rooms_RoomID",
                table: "Students",
                column: "RoomID",
                principalTable: "Rooms",
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
                name: "FK_Students_Rooms_RoomID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Specialtys_SpecialtyID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_FacultyID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_LogEntryID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_RoomID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SpecialtyID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Specialtys_UserID",
                table: "Specialtys");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HostelID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_LogEntryID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_UserID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_LogEntrys_UserID",
                table: "LogEntrys");

            migrationBuilder.DropIndex(
                name: "IX_Hostels_LogEntryID",
                table: "Hostels");

            migrationBuilder.DropIndex(
                name: "IX_Hostels_UserID",
                table: "Hostels");

            migrationBuilder.DropIndex(
                name: "IX_Facultys_UserID",
                table: "Facultys");

            migrationBuilder.DropColumn(
                name: "FacultyID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LogEntryID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LogEntry_ID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SpecialtyID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Specialtys");

            migrationBuilder.DropColumn(
                name: "HostelID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "LogEntryID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "LogEntry_ID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "LogEntrys");

            migrationBuilder.DropColumn(
                name: "LogEntryID",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "LogEntry_ID",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Facultys");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Users",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "Passport_ID",
                table: "Students",
                newName: "Pasport_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Faculty_ID",
                table: "Students",
                column: "Faculty_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Specialty_ID",
                table: "Students",
                column: "Specialty_ID",
                unique: true);

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
                name: "IX_LogEntrys_Hostel_ID",
                table: "LogEntrys",
                column: "Hostel_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogEntrys_Room_ID",
                table: "LogEntrys",
                column: "Room_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogEntrys_Student_ID",
                table: "LogEntrys",
                column: "Student_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogEntrys_User_ID",
                table: "LogEntrys",
                column: "User_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hostels_User_ID",
                table: "Hostels",
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
                name: "FK_Hostels_Users_User_ID",
                table: "Hostels",
                column: "User_ID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogEntrys_Hostels_Hostel_ID",
                table: "LogEntrys",
                column: "Hostel_ID",
                principalTable: "Hostels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogEntrys_Rooms_Room_ID",
                table: "LogEntrys",
                column: "Room_ID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogEntrys_Students_Student_ID",
                table: "LogEntrys",
                column: "Student_ID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogEntrys_Users_User_ID",
                table: "LogEntrys",
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
                name: "FK_Students_Facultys_Faculty_ID",
                table: "Students",
                column: "Faculty_ID",
                principalTable: "Facultys",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Specialtys_Specialty_ID",
                table: "Students",
                column: "Specialty_ID",
                principalTable: "Specialtys",
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
    }
}
