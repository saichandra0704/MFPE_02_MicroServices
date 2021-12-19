using Microsoft.EntityFrameworkCore.Migrations;

namespace PolicyAdmin.QuotesMS.API.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuotesMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100001, 1"),
                    PropertyValueRangeFrom = table.Column<int>(type: "int", nullable: false),
                    PropertyValueRangeTo = table.Column<int>(type: "int", nullable: false),
                    BusinesssValueRangeFrom = table.Column<int>(type: "int", nullable: false),
                    BusinesssValueRangeTo = table.Column<int>(type: "int", nullable: false),
                    PropertyType = table.Column<int>(type: "int", nullable: false),
                    Quote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotesMaster", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuotesMaster");
        }
    }
}
