using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCCrudApplication.Migrations
{
    public partial class finalImagedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "EmpTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "EmpTable");
        }
    }
}
