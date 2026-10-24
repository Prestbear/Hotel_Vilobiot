using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotel_Vilobiot.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<double>(type: "float", nullable: false),
                    RoomType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Name", "Stars" },
                values: new object[,]
                {
                    { 1, "Tbilisi", "Vilobiot Grand Hotel", 5m },
                    { 2, "Batumi", "Vilobiot City Hotel", 4m },
                    { 3, "Gudauri", "Vilobiot Mountain Hotel", 4.5m },
                    { 4, "Kutaisi", "Vilobiot Palace", 5m },
                    { 5, "Batumi", "Vilobiot Seaside Resort", 4.5m },
                    { 6, "Tbilisi", "Vilobiot Garden Hotel", 3.5m },
                    { 7, "Tbilisi", "Vilobiot Royal Suites", 5m },
                    { 8, "Kutaisi", "Vilobiot Riverside", 4m },
                    { 9, "Bakuriani", "Vilobiot Mountain View", 4m },
                    { 10, "Kobuleti", "Vilobiot Coastline Hotel", 4m },
                    { 11, "Rustavi", "Vilobiot Central Inn", 3m },
                    { 12, "Telavi", "Vilobiot Wine Resort", 4.5m },
                    { 13, "Borjomi", "Vilobiot Forest Lodge", 4m },
                    { 14, "Batumi", "Vilobiot Black Sea Palace", 5m },
                    { 15, "Tbilisi", "Vilobiot Old Town Hotel", 4m }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "HotelId", "Number", "PricePerNight", "RoomType", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, 101, 120.0, 0, true },
                    { 2, 1, 1, 102, 150.0, 1, true },
                    { 3, 1, 1, 103, 180.0, 2, false },
                    { 4, 2, 2, 201, 100.0, 0, true },
                    { 5, 2, 2, 202, 160.0, 3, true },
                    { 6, 1, 3, 101, 200.0, 4, true },
                    { 7, 2, 3, 201, 300.0, 5, true },
                    { 8, 1, 4, 101, 250.0, 8, true },
                    { 9, 1, 4, 102, 350.0, 9, false },
                    { 10, 3, 5, 301, 400.0, 10, true },
                    { 11, 3, 5, 302, 500.0, 11, true },
                    { 12, 1, 6, 101, 80.0, 0, true },
                    { 13, 5, 7, 501, 600.0, 12, true },
                    { 14, 2, 8, 201, 140.0, 2, true },
                    { 15, 1, 9, 101, 220.0, 5, true },
                    { 16, 3, 10, 301, 190.0, 3, false },
                    { 17, 1, 11, 101, 70.0, 1, true },
                    { 18, 4, 12, 401, 320.0, 6, true },
                    { 19, 2, 13, 201, 240.0, 7, true },
                    { 20, 5, 14, 501, 550.0, 12, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
