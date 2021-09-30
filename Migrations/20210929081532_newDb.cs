using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCCrudApplication.Migrations
{
    public partial class newDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "EmpTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "EmpTable",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
