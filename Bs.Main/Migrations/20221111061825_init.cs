using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Bs.Main.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Acronym = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Tin = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    BranchCode = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    BankName = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    Code = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    AccountNumber = table.Column<string>(type: "VARCHAR(25)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Rate = table.Column<double>(type: "DOUBLE(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayeeAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PayeeId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    AccountNumber = table.Column<string>(type: "VARCHAR(25)", nullable: true),
                    DefaultParticulars = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayeeAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payees",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    PayeeName = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    OwnerName = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Tin = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    PayeeId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    UseOwnerName = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PayeeAccountId = table.Column<int>(type: "INT", nullable: false),
                    CompanyId = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    CompanyAccountCode = table.Column<string>(type: "VARCHAR(10)", nullable: true),
                    VoucherNumber = table.Column<string>(type: "VARCHAR(20)", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DateModified = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vouchers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vouchers_PayeeAccounts_PayeeAccountId",
                        column: x => x.PayeeAccountId,
                        principalTable: "PayeeAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vouchers_Payees_PayeeId",
                        column: x => x.PayeeId,
                        principalTable: "Payees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VoucherId = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    JournalAccountName = table.Column<string>(type: "VARCHAR(45)", nullable: true),
                    Amount = table.Column<double>(type: "DOUBLE(10,2)", nullable: false),
                    WithholdingTaxRate = table.Column<double>(type: "DOUBLE(4,2)", nullable: false),
                    Particulars = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalEntries_Vouchers_VoucherId",
                        column: x => x.VoucherId,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_VoucherId",
                table: "JournalEntries",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_CompanyId",
                table: "Vouchers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_PayeeAccountId",
                table: "Vouchers",
                column: "PayeeAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Vouchers_PayeeId",
                table: "Vouchers",
                column: "PayeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyAccounts");

            migrationBuilder.DropTable(
                name: "JournalAccounts");

            migrationBuilder.DropTable(
                name: "JournalEntries");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "PayeeAccounts");

            migrationBuilder.DropTable(
                name: "Payees");
        }
    }
}
