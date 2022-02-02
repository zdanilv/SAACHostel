using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAACHostel.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hostels_LogEntrys_LogEntryID",
                table: "Hostels");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_LogEntrys_LogEntryID",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_LogEntrys_LogEntryID",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Rooms_RoomID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_LogEntryID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_RoomID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_LogEntryID",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Hostels_LogEntryID",
                table: "Hostels");

            migrationBuilder.DropColumn(
                name: "LogEntryID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LogEntryID",
                table: "Hostels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LogEntryID",
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
                name: "LogEntryID",
                table: "Hostels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_LogEntryID",
                table: "Students",
                column: "LogEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoomID",
                table: "Students",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LogEntryID",
                table: "Rooms",
                column: "LogEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_Hostels_LogEntryID",
                table: "Hostels",
                column: "LogEntryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hostels_LogEntrys_LogEntryID",
                table: "Hostels",
                column: "LogEntryID",
                principalTable: "LogEntrys",
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
                name: "FK_Students_LogEntrys_LogEntryID",
                table: "Students",
                column: "LogEntryID",
                principalTable: "LogEntrys",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Rooms_RoomID",
                table: "Students",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID");
        }
    }
}
