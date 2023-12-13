using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class changethedatatypefrominttostring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PONo",
                table: "ReceivingReports",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SINo",
                table: "CreditMemos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SOANo",
                table: "CreditMemos",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PONo",
                table: "ReceivingReports");

            migrationBuilder.DropColumn(
                name: "SINo",
                table: "CreditMemos");

            migrationBuilder.DropColumn(
                name: "SOANo",
                table: "CreditMemos");
        }
    }
}
