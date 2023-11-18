using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class Updatetablecollectionreceiptname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectionReceipt",
                table: "CollectionReceipt");

            migrationBuilder.RenameTable(
                name: "CollectionReceipt",
                newName: "CollectionReceipts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectionReceipts",
                table: "CollectionReceipts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectionReceipts",
                table: "CollectionReceipts");

            migrationBuilder.RenameTable(
                name: "CollectionReceipts",
                newName: "CollectionReceipt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectionReceipt",
                table: "CollectionReceipt",
                column: "Id");
        }
    }
}
