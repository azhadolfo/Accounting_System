using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class RevisefieldsinformofpaymentinCRARmodule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bank",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "CollectionReceipts");

            migrationBuilder.RenameColumn(
                name: "FormOfPayment",
                table: "CollectionReceipts",
                newName: "ManagerCheckNo");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "CollectionReceipts",
                newName: "ManagerCheckAmount");

            migrationBuilder.AlterColumn<string>(
                name: "CheckNo",
                table: "CollectionReceipts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CashAmount",
                table: "CollectionReceipts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CheckAmount",
                table: "CollectionReceipts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CheckBank",
                table: "CollectionReceipts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CheckBranch",
                table: "CollectionReceipts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManagerCheckBank",
                table: "CollectionReceipts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManagerCheckBranch",
                table: "CollectionReceipts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ManagerCheckDate",
                table: "CollectionReceipts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashAmount",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "CheckAmount",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "CheckBank",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "CheckBranch",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "ManagerCheckBank",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "ManagerCheckBranch",
                table: "CollectionReceipts");

            migrationBuilder.DropColumn(
                name: "ManagerCheckDate",
                table: "CollectionReceipts");

            migrationBuilder.RenameColumn(
                name: "ManagerCheckNo",
                table: "CollectionReceipts",
                newName: "FormOfPayment");

            migrationBuilder.RenameColumn(
                name: "ManagerCheckAmount",
                table: "CollectionReceipts",
                newName: "Amount");

            migrationBuilder.AlterColumn<string>(
                name: "CheckNo",
                table: "CollectionReceipts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Bank",
                table: "CollectionReceipts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "CollectionReceipts",
                type: "text",
                nullable: true);
        }
    }
}
