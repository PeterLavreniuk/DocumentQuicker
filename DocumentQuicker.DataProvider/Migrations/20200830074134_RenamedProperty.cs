using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentQuicker.DataProvider.Migrations
{
    public partial class RenamedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankDescription",
                table: "Banks");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Banks",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Banks");

            migrationBuilder.AddColumn<string>(
                name: "BankDescription",
                table: "Banks",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
