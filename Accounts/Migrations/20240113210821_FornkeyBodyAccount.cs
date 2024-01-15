using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounts.Migrations
{
    /// <inheritdoc />
    public partial class FornkeyBodyAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountssId",
                table: "makeJournalBodies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CostCenterId",
                table: "makeJournalBodies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_makeJournalBodies_AccountssId",
                table: "makeJournalBodies",
                column: "AccountssId");

            migrationBuilder.CreateIndex(
                name: "IX_makeJournalBodies_CostCenterId",
                table: "makeJournalBodies",
                column: "CostCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_makeJournalBodies_accounts_AccountssId",
                table: "makeJournalBodies",
                column: "AccountssId",
                principalTable: "accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_makeJournalBodies_costCenters_CostCenterId",
                table: "makeJournalBodies",
                column: "CostCenterId",
                principalTable: "costCenters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_makeJournalBodies_accounts_AccountssId",
                table: "makeJournalBodies");

            migrationBuilder.DropForeignKey(
                name: "FK_makeJournalBodies_costCenters_CostCenterId",
                table: "makeJournalBodies");

            migrationBuilder.DropIndex(
                name: "IX_makeJournalBodies_AccountssId",
                table: "makeJournalBodies");

            migrationBuilder.DropIndex(
                name: "IX_makeJournalBodies_CostCenterId",
                table: "makeJournalBodies");

            migrationBuilder.DropColumn(
                name: "AccountssId",
                table: "makeJournalBodies");

            migrationBuilder.DropColumn(
                name: "CostCenterId",
                table: "makeJournalBodies");
        }
    }
}
