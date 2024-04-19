using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class _123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DepartmentList",
                keyColumn: "Id",
                keyValue: 1,
                column: "DepartmentName",
                value: "noooo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DepartmentList",
                keyColumn: "Id",
                keyValue: 1,
                column: "DepartmentName",
                value: "Neurology");
        }
    }
}
