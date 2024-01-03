using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class AddcolumnRemarksinalldataentrythathasnoparticularsinARmodule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "OfficialReceipts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "DebitMemos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "CreditMemos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "CollectionReceipts",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "OfficialReceipts");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "DebitMemos");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "CreditMemos");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "CollectionReceipts");
        }
    }
}
