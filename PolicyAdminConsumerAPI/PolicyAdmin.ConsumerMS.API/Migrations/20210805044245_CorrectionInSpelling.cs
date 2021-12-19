using Microsoft.EntityFrameworkCore.Migrations;

namespace PolicyAdmin.ConsumerMS.API.Migrations
{
    public partial class CorrectionInSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumer_Business_BusinessId",
                table: "Consumer");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Business_BusinesssId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consumer",
                table: "Consumer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Business",
                table: "Business");

            migrationBuilder.RenameTable(
                name: "Consumer",
                newName: "Consumers");

            migrationBuilder.RenameTable(
                name: "Business",
                newName: "Businesses");

            migrationBuilder.RenameColumn(
                name: "BusinesssId",
                table: "Properties",
                newName: "BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_BusinesssId",
                table: "Properties",
                newName: "IX_Properties_BusinessId");

            migrationBuilder.RenameIndex(
                name: "IX_Consumer_BusinessId",
                table: "Consumers",
                newName: "IX_Consumers_BusinessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consumers",
                table: "Consumers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Businesses",
                table: "Businesses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_Businesses_BusinessId",
                table: "Consumers",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Businesses_BusinessId",
                table: "Properties",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_Businesses_BusinessId",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Businesses_BusinessId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consumers",
                table: "Consumers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Businesses",
                table: "Businesses");

            migrationBuilder.RenameTable(
                name: "Consumers",
                newName: "Consumer");

            migrationBuilder.RenameTable(
                name: "Businesses",
                newName: "Business");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Properties",
                newName: "BusinesssId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_BusinessId",
                table: "Properties",
                newName: "IX_Properties_BusinesssId");

            migrationBuilder.RenameIndex(
                name: "IX_Consumers_BusinessId",
                table: "Consumer",
                newName: "IX_Consumer_BusinessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consumer",
                table: "Consumer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Business",
                table: "Business",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumer_Business_BusinessId",
                table: "Consumer",
                column: "BusinessId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Business_BusinesssId",
                table: "Properties",
                column: "BusinesssId",
                principalTable: "Business",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
