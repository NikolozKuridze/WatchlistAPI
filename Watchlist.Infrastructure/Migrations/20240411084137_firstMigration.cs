using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Watchlist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<double>(type: "float", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "watchlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    movie_id = table.Column<int>(type: "int", nullable: false),
                    is_watched = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_watchlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_watchlists_movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_watchlists_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "Id", "description", "rating", "title" },
                values: new object[,]
                {
                    { 1, "A masked vigilante battles crime and corruption in Gotham City while grappling with his own inner demons.", 9.3000000000000007, "The Batman" },
                    { 2, "Description 2", 10.0, "ცისფერი მთები" },
                    { 3, "Description 3", 9.0, "დათა თუთაშხია" },
                    { 4, "Description 4", 8.9000000000000004, "უძინართა მზე" },
                    { 5, "Description 5", 8.9000000000000004, "The GodFather" }
                });

            migrationBuilder.InsertData(
                table: "users",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5
                });

            migrationBuilder.CreateIndex(
                name: "IX_watchlists_movie_id",
                table: "watchlists",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_watchlists_UserId",
                table: "watchlists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "watchlists");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
