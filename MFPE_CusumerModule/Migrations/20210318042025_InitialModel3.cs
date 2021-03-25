using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MFPE_CusumerModule.Migrations
{
    public partial class InitialModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessMasters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasBusinessTypes = table.Column<bool>(type: "bit", nullable: false),
                    AnnualTurnover = table.Column<int>(type: "int", nullable: false),
                    capitalInvested = table.Column<int>(type: "int", nullable: false),
                    BusinessValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessMasters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyMasters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasPropertyTypes = table.Column<bool>(type: "bit", nullable: false),
                    CostofAsset = table.Column<int>(type: "int", nullable: false),
                    SalvageValue = table.Column<int>(type: "int", nullable: false),
                    UsefulLifeOfAsset = table.Column<int>(type: "int", nullable: false),
                    PropertyValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyMasters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BussinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BussinessType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalEmployees = table.Column<int>(type: "int", nullable: false),
                    BussinessMasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Businesses_BusinessMasters_BussinessMasterId",
                        column: x => x.BussinessMasterId,
                        principalTable: "BusinessMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidityOfConsumer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BussinessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Consumers_Businesses_BussinessId",
                        column: x => x.BussinessId,
                        principalTable: "Businesses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingAge = table.Column<int>(type: "int", nullable: false),
                    PropertMasterId = table.Column<int>(type: "int", nullable: false),
                    BussinessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.id);
                    table.ForeignKey(
                        name: "FK_Properties_Businesses_BussinessId",
                        column: x => x.BussinessId,
                        principalTable: "Businesses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyMasters_PropertMasterId",
                        column: x => x.PropertMasterId,
                        principalTable: "PropertyMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_BussinessMasterId",
                table: "Businesses",
                column: "BussinessMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumers_BussinessId",
                table: "Consumers",
                column: "BussinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_BussinessId",
                table: "Properties",
                column: "BussinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertMasterId",
                table: "Properties",
                column: "PropertMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumers");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "PropertyMasters");

            migrationBuilder.DropTable(
                name: "BusinessMasters");
        }
    }
}
