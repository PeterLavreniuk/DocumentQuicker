using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentQuicker.DataProvider.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankInfos",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    BankDescription = table.Column<string>(nullable: true),
                    Bic = table.Column<string>(nullable: true),
                    CorrAccount = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankInfos");
        }
    }
}
