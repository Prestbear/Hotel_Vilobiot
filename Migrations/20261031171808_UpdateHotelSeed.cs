using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Vilobiot.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHotelSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "City", "Name", "Stars" },
                values: new object[] { "Oni---Cxmori", "Vilobiot Village Hotel", 5m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "City", "Name", "Stars" },
                values: new object[] { "Tbilisi", "Vilobiot Old Town Hotel", 4m });
        }
    }
}
