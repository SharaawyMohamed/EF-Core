using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMe.Migrations
{
    /// <inheritdoc />
    public partial class InitiaCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitDetails",
                columns: table => new
                {
                    UnitNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitDetails", x => x.UnitNo);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    LineNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnitNo = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    expiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitNo1 = table.Column<int>(type: "int", nullable: false),
                    UnitNo2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.LineNo);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_UnitDetails_UnitNo",
                        column: x => x.UnitNo,
                        principalTable: "UnitDetails",
                        principalColumn: "UnitNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_UnitDetails_UnitNo1",
                        column: x => x.UnitNo1,
                        principalTable: "UnitDetails",
                        principalColumn: "UnitNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_UnitNo",
                table: "InvoiceDetails",
                column: "UnitNo");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_UnitNo1",
                table: "InvoiceDetails",
                column: "UnitNo1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "UnitDetails");
        }
    }
}
