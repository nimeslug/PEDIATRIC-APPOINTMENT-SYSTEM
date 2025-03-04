using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webOdev.Migrations
{
    /// <inheritdoc />
    public partial class CalenderEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "CalenderEvent",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Time = table.Column<TimeSpan>(type: "time", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_CalenderEvents", x => x.Id);
               });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "CalenderEvents");
        }
    }
}
