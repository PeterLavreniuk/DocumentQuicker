using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentQuicker.DataProvider.Migrations
{
    public partial class RequisiteEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requisites",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    INN = table.Column<string>(nullable: true),
                    KPP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    RawAddress = table.Column<string>(nullable: true),
                    RequisiteId = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Requisites_RequisiteId",
                        column: x => x.RequisiteId,
                        principalTable: "Requisites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EditDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Account = table.Column<string>(nullable: true),
                    BankInfoId = table.Column<byte[]>(nullable: true),
                    RequisiteId = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDetails_BankInfos_BankInfoId",
                        column: x => x.BankInfoId,
                        principalTable: "BankInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankDetails_Requisites_RequisiteId",
                        column: x => x.RequisiteId,
                        principalTable: "Requisites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_RequisiteId",
                table: "Addresses",
                column: "RequisiteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_BankInfoId",
                table: "BankDetails",
                column: "BankInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_RequisiteId",
                table: "BankDetails",
                column: "RequisiteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "Requisites");
        }
    }
}
