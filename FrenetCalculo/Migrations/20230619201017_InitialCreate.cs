using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrenetCalculate.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FreightQuotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FreightPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuoteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreightQuotes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreightQuotes");
        }
    }
}
