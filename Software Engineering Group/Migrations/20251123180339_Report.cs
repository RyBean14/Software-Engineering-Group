using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Software_Engineering_Group.Migrations
{
    /// <inheritdoc />
    public partial class Report : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    reportInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    staffID = table.Column<int>(type: "int", nullable: true),
                    staffResponse = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");
        }
    }
}
