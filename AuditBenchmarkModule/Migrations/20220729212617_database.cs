using Microsoft.EntityFrameworkCore.Migrations;

namespace AuditBenchmarkModule.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenchmarkLists",
                columns: table => new
                {
                    auditType = table.Column<string>(nullable: false),
                    benchmarkNoAnswers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenchmarkLists", x => x.auditType);
                });

            migrationBuilder.InsertData(
                table: "BenchmarkLists",
                columns: new[] { "auditType", "benchmarkNoAnswers" },
                values: new object[] { "Internal", 3 });

            migrationBuilder.InsertData(
                table: "BenchmarkLists",
                columns: new[] { "auditType", "benchmarkNoAnswers" },
                values: new object[] { "SOX", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenchmarkLists");
        }
    }
}
