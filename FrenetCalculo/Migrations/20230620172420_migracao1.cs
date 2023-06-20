using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FrenetCalculate.Migrations
{
    /// <inheritdoc />
    public partial class migracao1 : Migration
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

            migrationBuilder.CreateTable(
                name: "TrackingEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FreightQuoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackingEvent_FreightQuotes_FreightQuoteId",
                        column: x => x.FreightQuoteId,
                        principalTable: "FreightQuotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackingEvent_FreightQuoteId",
                table: "TrackingEvent",
                column: "FreightQuoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackingEvent");

            migrationBuilder.DropTable(
                name: "FreightQuotes");
        }
    }
}
