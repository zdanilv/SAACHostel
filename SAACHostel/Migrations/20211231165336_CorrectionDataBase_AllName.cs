using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAACHostel.Migrations
{
    public partial class CorrectionDataBase_AllName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Short_name",
                table: "Users",
                newName: "Middle_Name");

            migrationBuilder.RenameColumn(
                name: "Full_name",
                table: "Users",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "Short_name",
                table: "Students",
                newName: "Middle_Name");

            migrationBuilder.RenameColumn(
                name: "Full_name",
                table: "Students",
                newName: "Last_Name");

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "Students",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Students",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Middle_Name",
                table: "Users",
                newName: "Short_name");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "Users",
                newName: "Full_name");

            migrationBuilder.RenameColumn(
                name: "Middle_Name",
                table: "Students",
                newName: "Short_name");

            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "Students",
                newName: "Full_name");
        }
    }
}
