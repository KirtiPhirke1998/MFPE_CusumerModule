using Microsoft.EntityFrameworkCore.Migrations;

namespace MFPE_CusumerModule.Migrations
{
    public partial class UpdateTableMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessValue",
                table: "BusinessMasters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessValue",
                table: "BusinessMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
