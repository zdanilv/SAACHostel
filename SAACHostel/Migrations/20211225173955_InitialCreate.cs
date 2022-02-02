using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAACHostel.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facultys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Full_name = table.Column<string>(type: "TEXT", nullable: true),
                    Short_name = table.Column<string>(type: "TEXT", nullable: true),
                    Full_name_decan = table.Column<string>(type: "TEXT", nullable: true),
                    Phone_decane = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Specialtys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Full_name = table.Column<string>(type: "TEXT", nullable: true),
                    Short_name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialtys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    login = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true),
                    Full_name = table.Column<string>(type: "TEXT", nullable: true),
                    Short_name = table.Column<string>(type: "TEXT", nullable: true),
                    Pasport_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Home_address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Full_name = table.Column<string>(type: "TEXT", nullable: true),
                    Short_name = table.Column<string>(type: "TEXT", nullable: true),
                    Faculty_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Specialty_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Pasport_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Home_address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_Facultys_Faculty_ID",
                        column: x => x.Faculty_ID,
                        principalTable: "Facultys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Specialtys_Specialty_ID",
                        column: x => x.Specialty_ID,
                        principalTable: "Specialtys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hostels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Home_address = table.Column<string>(type: "TEXT", nullable: true),
                    User_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hostels_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogEntrys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    User_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Room_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Student_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Hostel_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Date_ent = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Date_ext = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Pay = table.Column<int>(type: "INTEGER", nullable: false),
                    State = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntrys", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LogEntrys_Hostels_Hostel_ID",
                        column: x => x.Hostel_ID,
                        principalTable: "Hostels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogEntrys_Rooms_Room_ID",
                        column: x => x.Room_ID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogEntrys_Students_Student_ID",
                        column: x => x.Student_ID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogEntrys_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hostels_User_ID",
                table: "Hostels",
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
                name: "IX_Students_Faculty_ID",
                table: "Students",
                column: "Faculty_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_Specialty_ID",
                table: "Students",
                column: "Specialty_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogEntrys");

            migrationBuilder.DropTable(
                name: "Hostels");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Facultys");

            migrationBuilder.DropTable(
                name: "Specialtys");
        }
    }
}
