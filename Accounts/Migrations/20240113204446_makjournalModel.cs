using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Migrations
{
    /// <inheritdoc />
    public partial class makjournalModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "makeJournalHeads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntryJournal = table.Column<int>(type: "int", nullable: false),
                    AccNumer = table.Column<int>(type: "int", nullable: false),
                    AccName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_makeJournalHeads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "makeJournalBodies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BalanceMovement = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MakeJournalHeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccNumer = table.Column<int>(type: "int", nullable: false),
                    AccName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_makeJournalBodies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_makeJournalBodies_makeJournalHeads_MakeJournalHeadId",
                        column: x => x.MakeJournalHeadId,
                        principalTable: "makeJournalHeads",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_makeJournalBodies_MakeJournalHeadId",
                table: "makeJournalBodies",
                column: "MakeJournalHeadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "makeJournalBodies");

            migrationBuilder.DropTable(
                name: "makeJournalHeads");
        }
    }
}
