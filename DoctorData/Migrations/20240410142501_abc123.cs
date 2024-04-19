using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.HospitalData.Data.Migrations
{
    /// <inheritdoc />
    public partial class abc123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Fees",
                table: "Docinfo",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Hospital",
                table: "Docinfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Docinfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fees", "Hospital" },
                values: new object[] { 500.0, "Appolo" });

            migrationBuilder.UpdateData(
                table: "Docinfo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Fees", "Hospital" },
                values: new object[] { 1000.0, "United" });

            migrationBuilder.UpdateData(
                table: "Docinfo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Fees", "Hospital" },
                values: new object[] { 700.0, "Narayana" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fees",
                table: "Docinfo");

            migrationBuilder.DropColumn(
                name: "Hospital",
                table: "Docinfo");
        }
    }
}
