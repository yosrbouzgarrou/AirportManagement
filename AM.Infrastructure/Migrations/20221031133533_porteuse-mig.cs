using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    public partial class porteusemig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    FlightFK = table.Column<int>(type: "int", nullable: false),
                    PassengerFK = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    Siege = table.Column<int>(type: "int", nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    PassengerPassportNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => new { x.PassengerFK, x.FlightFK });
                    table.ForeignKey(
                        name: "FK_Ticket_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Passengers_PassengerPassportNumber",
                        column: x => x.PassengerPassportNumber,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightId",
                table: "Ticket",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerPassportNumber",
                table: "Ticket",
                column: "PassengerPassportNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
