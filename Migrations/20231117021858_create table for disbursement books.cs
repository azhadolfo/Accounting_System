using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Accounting_System.Migrations
{
    /// <inheritdoc />
    public partial class createtablefordisbursementbooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisbursementBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "text", nullable: false),
                    CVNo = table.Column<string>(type: "text", nullable: false),
                    Payee = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Particulars = table.Column<string>(type: "text", nullable: false),
                    Bank = table.Column<string>(type: "text", nullable: false),
                    CheckNo = table.Column<string>(type: "text", nullable: false),
                    CheckDate = table.Column<string>(type: "text", nullable: false),
                    DateCleared = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisbursementBooks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisbursementBooks");
        }
    }
}
