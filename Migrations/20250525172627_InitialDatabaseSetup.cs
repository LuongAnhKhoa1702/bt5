using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KTGK.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeName", "ImagePath" },
                values: new object[,]
                {
                    { 1, "21DTHA1", "/images/grades/lop1.png" },
                    { 2, "21DTHA2", "/images/grades/lop2.png" },
                    { 3, "21DTHA3", "/images/grades/lop3.png" },
                    { 4, "21DTHA4", "/images/grades/lop4.png" },
                    { 5, "21DTHA5", "/images/grades/lop4.png" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "FirstName", "GradeId", "LastName" },
                values: new object[,]
                {
                    { 1, "Khuyên", 1, "Bùi" },
                    { 2, "Toàn", 1, "Nguyễn" },
                    { 3, "Hương", 2, "Trần" },
                    { 4, "Quang", 2, "Lê" },
                    { 5, "Mai", 3, "Phạm" },
                    { 6, "Long", 3, "Đỗ" },
                    { 7, "Thanh", 4, "Hoàng" },
                    { 8, "Vân", 4, "Ngô" },
                    { 9, "Minh", 5, "Vũ" },
                    { 10, "Anh", 5, "Đặng" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeId",
                table: "Students",
                column: "GradeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
