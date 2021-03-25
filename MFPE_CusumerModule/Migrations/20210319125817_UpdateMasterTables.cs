using Microsoft.EntityFrameworkCore.Migrations;

namespace MFPE_CusumerModule.Migrations
{
    public partial class UpdateMasterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BusinessValue",
                table: "BusinessMasters",
                newName: "BussinessValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BussinessValue",
                table: "BusinessMasters",
                newName: "BusinessValue");
        }
    }
}
