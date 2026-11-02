using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hotel_Vilobiot.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomsToCxmori : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Floor", "Number" },
                values: new object[] { 1, 101 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Floor", "HotelId", "Number", "PricePerNight", "RoomType" },
                values: new object[,]
                {
                    { 21, 1, 15, 101, 50.0, 0 },
                    { 22, 1, 15, 102, 70.0, 1 },
                    { 23, 2, 15, 201, 120.0, 3 },
                    { 24, 2, 15, 202, 120.0, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Floor", "Number" },
                values: new object[] { 5, 501 });
        }
    }
}
