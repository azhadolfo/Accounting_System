using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class removetheinheritofchartofaccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanceledBy",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "CanceledDate",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "IsVoided",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "PostedDate",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "ChartOfAccounts");

            migrationBuilder.DropColumn(
                name: "VoidedDate",
                table: "ChartOfAccounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CanceledBy",
                table: "ChartOfAccounts",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledDate",
                table: "ChartOfAccounts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "ChartOfAccounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "ChartOfAccounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "ChartOfAccounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVoided",
                table: "ChartOfAccounts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "ChartOfAccounts",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedDate",
                table: "ChartOfAccounts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "ChartOfAccounts",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VoidedDate",
                table: "ChartOfAccounts",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
