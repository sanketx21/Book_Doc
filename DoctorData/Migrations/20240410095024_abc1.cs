using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.HospitalData.Data.Migrations
{
    /// <inheritdoc />
    public partial class abc1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Docinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialisation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docinfo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Docinfo",
                columns: new[] { "Id", "Name", "Specialisation" },
                values: new object[,]
                {
                    { 1, "test1", "neuro" },
                    { 2, "test2", "ortho" },
                    { 3, "test3", "surgeon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Docinfo");
        }
    }
}
