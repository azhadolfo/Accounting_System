using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class modifythedatatypeofcolumnsinsalesinvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TinNo",
                table: "SalesInvoices",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Terms",
                table: "SalesInvoices",
                type: "varchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "SalesInvoices",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "SoldTo",
                table: "SalesInvoices",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "SINo",
                table: "SalesInvoices",
                type: "varchar(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "SalesInvoices",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ProductUnit",
                table: "SalesInvoices",
                type: "varchar(5)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ProductNo",
                table: "SalesInvoices",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "SalesInvoices",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PoNo",
                table: "SalesInvoices",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "OtherRefNo",
                table: "SalesInvoices",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerType",
                table: "SalesInvoices",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessStyle",
                table: "SalesInvoices",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "SalesInvoices",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TinNo",
                table: "SalesInvoices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Terms",
                table: "SalesInvoices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "SalesInvoices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "SoldTo",
                table: "SalesInvoices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "SINo",
                table: "SalesInvoices",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "SalesInvoices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductUnit",
                table: "SalesInvoices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductNo",
                table: "SalesInvoices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "SalesInvoices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "PoNo",
                table: "SalesInvoices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)");

            migrationBuilder.AlterColumn<string>(
                name: "OtherRefNo",
                table: "SalesInvoices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerType",
                table: "SalesInvoices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessStyle",
                table: "SalesInvoices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "SalesInvoices",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");
        }
    }
}
