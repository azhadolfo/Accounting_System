using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class implementforeignkeycollectionreceipttosalesinvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CRNo",
                table: "CollectionReceipts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionReceipts_SalesInvoiceId",
                table: "CollectionReceipts",
                column: "SalesInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionReceipts_SalesInvoices_SalesInvoiceId",
                table: "CollectionReceipts",
                column: "SalesInvoiceId",
                principalTable: "SalesInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionReceipts_SalesInvoices_SalesInvoiceId",
                table: "CollectionReceipts");

            migrationBuilder.DropIndex(
                name: "IX_CollectionReceipts_SalesInvoiceId",
                table: "CollectionReceipts");

            migrationBuilder.AlterColumn<string>(
                name: "CRNo",
                table: "CollectionReceipts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
