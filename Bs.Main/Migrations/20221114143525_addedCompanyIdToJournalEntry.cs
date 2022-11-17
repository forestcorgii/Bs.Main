using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bs.Main.Migrations
{
    public partial class addedCompanyIdToJournalEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "JournalEntries",
                type: "VARCHAR(45)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "JournalEntries");

 
        }
    }
}
