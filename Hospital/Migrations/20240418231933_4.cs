using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Docinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Specialisation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Hospital = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fees = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docinfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalinfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalinfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientsList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Record = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsList", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DepartmentList",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Neurology" },
                    { 2, "Bones and Joints" },
                    { 3, "Women's Health" },
                    { 4, "General physician" }
                });

            migrationBuilder.InsertData(
                table: "Docinfo",
                columns: new[] { "Id", "Fees", "Hospital", "Name", "Specialisation" },
                values: new object[,]
                {
                    { 1, 500.0, "Appolo", "test1", "neuro" },
                    { 2, 1000.0, "United", "test2", "ortho" },
                    { 3, 700.0, "Narayana", "test3", "surgeon" }
                });

            migrationBuilder.InsertData(
                table: "Hospitalinfo",
                columns: new[] { "Id", "Address", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Appolo", "neuro", "", "test1" },
                    { 2, "United", "ortho", "", "test2" },
                    { 3, "Narayana", "surgeon", "", "test3" }
                });

            migrationBuilder.InsertData(
                table: "PatientsList",
                columns: new[] { "Id", "Age", "BloodGroup", "City", "Name", "PhoneNumber", "Problem", "Record" },
                values: new object[,]
                {
                    { 1, 21, "O+", "Nyc", "xyz", "9876567657", "Throat", "" },
                    { 2, 22, "ab+", "Del", "xyz1", "9876567657", "skin", "" },
                    { 3, 23, "b+", "Blr", "xyz2", "9876567657", "hair", "" },
                    { 4, 24, "a+", "Hyd", "xyz3", "9876567657", "joint", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentList");

            migrationBuilder.DropTable(
                name: "Docinfo");

            migrationBuilder.DropTable(
                name: "Hospitalinfo");

            migrationBuilder.DropTable(
                name: "PatientsList");
        }
    }
}
