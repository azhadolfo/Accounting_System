using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class modifythedatatypeofcolumnsincollectionreceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preference",
                table: "CollectionReceipts");

            migrationBuilder.AlterColumn<string>(
                name: "SINo",
                table: "CollectionReceipts",
                type: "varchar(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "CollectionReceipts",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceNo",
                table: "CollectionReceipts",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerCheckNo",
                table: "CollectionReceipts",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManagerCheckBranch",
                table: "CollectionReceipts",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManagerCheckBank",
                table: "CollectionReceipts",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CheckNo",
                table: "CollectionReceipts",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CheckBranch",
                table: "CollectionReceipts",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CheckBank",
                table: "CollectionReceipts",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CRNo",
                table: "CollectionReceipts",
                type: "varchar(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SINo",
                table: "CollectionReceipts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "CollectionReceipts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReferenceNo",
                table: "CollectionReceipts",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerCheckNo",
                table: "CollectionReceipts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManagerCheckBranch",
                table: "CollectionReceipts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManagerCheckBank",
                table: "CollectionReceipts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CheckNo",
                table: "CollectionReceipts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CheckBranch",
                table: "CollectionReceipts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CheckBank",
                table: "CollectionReceipts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CRNo",
                table: "CollectionReceipts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Preference",
                table: "CollectionReceipts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
