using Microsoft.EntityFrameworkCore.Migrations;

namespace Bs.CheckApp.Persistence.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PayeeId",
                table: "cheque",
                newName: "PayeeLine2");

            migrationBuilder.AddColumn<string>(
                name: "Endorsement",
                table: "cheque",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayeeLine1",
                table: "cheque",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "cheque_book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChequeCode = table.Column<string>(type: "TEXT", nullable: true),
                    FirstChequeNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalCheque = table.Column<int>(type: "INTEGER", nullable: false),
                    LeadingZeros = table.Column<string>(type: "TEXT", nullable: true),
                    Complete = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cheque_book", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cheque_book");

            migrationBuilder.DropColumn(
                name: "Endorsement",
                table: "cheque");

            migrationBuilder.DropColumn(
                name: "PayeeLine1",
                table: "cheque");

            migrationBuilder.RenameColumn(
                name: "PayeeLine2",
                table: "cheque",
                newName: "PayeeId");
        }
    }
}
