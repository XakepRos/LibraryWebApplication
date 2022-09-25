using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryWebApplication.Migrations
{
    public partial class ModifyDeptTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionString",
                table: "Departments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectionString",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
