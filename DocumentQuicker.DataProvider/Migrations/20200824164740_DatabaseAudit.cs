using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentQuicker.DataProvider.Migrations
{
    public partial class DatabaseAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CorrAccount",
                table: "BankInfos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bic",
                table: "BankInfos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BankDescription",
                table: "BankInfos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DatabaseAudits",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Action = table.Column<int>(nullable: false),
                    AuditDate = table.Column<DateTime>(nullable: false),
                    ItemId = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseAudits", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatabaseAudits");

            migrationBuilder.AlterColumn<string>(
                name: "CorrAccount",
                table: "BankInfos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Bic",
                table: "BankInfos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "BankDescription",
                table: "BankInfos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
