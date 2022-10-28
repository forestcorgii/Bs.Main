using Microsoft.EntityFrameworkCore.Migrations;

namespace Bs.CheckApp.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cheque",
                columns: table => new
                {
                    CheckNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ChequeBookNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    VoucherNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PayeeId = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", nullable: true),
                    IsCrossed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cheque", x => x.CheckNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cheque");
        }
    }
}
