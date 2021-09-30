using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCCrudApplication.Migrations
{
    public partial class FinalDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "EmpTable",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "EmpTable");
        }
    }
}
