using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class RemovethefullpartialandoffsettingandcommentthefunctioncodeoftypeofcollectioninModelCR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfCollection",
                table: "CollectionReceipts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeOfCollection",
                table: "CollectionReceipts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
