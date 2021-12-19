using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PolicyAdmin.ConsumerMS.API.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100001, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessType = table.Column<int>(type: "int", nullable: false),
                    AnnualTurnOver = table.Column<double>(type: "float", nullable: false),
                    CapitalInvested = table.Column<double>(type: "float", nullable: false),
                    BusinesIncorporation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalEmployees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessesMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100001, 1"),
                    BusinessType = table.Column<int>(type: "int", nullable: false),
                    MinimumAnnualTurnOver = table.Column<double>(type: "float", nullable: false),
                    MinimumCapitalInvested = table.Column<double>(type: "float", nullable: false),
                    MinimumBusinessAgeInYears = table.Column<int>(type: "int", nullable: false),
                    MinimumTotalEmployees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessesMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertiesMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100001, 1"),
                    PropertyType = table.Column<int>(type: "int", nullable: false),
                    MinimumCostOfAsset = table.Column<int>(type: "int", nullable: false),
                    MaximumCostOfAsset = table.Column<int>(type: "int", nullable: false),
                    MinimumArea = table.Column<int>(type: "int", nullable: false),
                    MaximumArea = table.Column<int>(type: "int", nullable: false),
                    PropertyAgeMin = table.Column<int>(type: "int", nullable: false),
                    PropertyAgeMax = table.Column<int>(type: "int", nullable: false),
                    EstimatedLife = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consumer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100000, 1"),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsumerDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsumerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsumerPan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumer_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100001, 1"),
                    BusinesssId = table.Column<int>(type: "int", nullable: false),
                    PropertyType = table.Column<int>(type: "int", nullable: false),
                    BuildingSqFt = table.Column<double>(type: "float", nullable: false),
                    Storeys = table.Column<int>(type: "int", nullable: false),
                    PropertyAge = table.Column<int>(type: "int", nullable: false),
                    CostOfAsset = table.Column<double>(type: "float", nullable: false),
                    SalvageValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Business_BusinesssId",
                        column: x => x.BusinesssId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_BusinessId",
                table: "Consumer",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_BusinesssId",
                table: "Properties",
                column: "BusinesssId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessesMaster");

            migrationBuilder.DropTable(
                name: "Consumer");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "PropertiesMaster");

            migrationBuilder.DropTable(
                name: "Business");
        }
    }
}
