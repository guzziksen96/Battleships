using Microsoft.EntityFrameworkCore.Migrations;

namespace Battleships.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<int>(nullable: false),
                    Column = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerBoardId = table.Column<int>(nullable: false),
                    ComputerBoardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Boards_ComputerBoardId",
                        column: x => x.ComputerBoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Boards_PlayerBoardId",
                        column: x => x.PlayerBoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BoardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HitShots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardId = table.Column<int>(nullable: false),
                    CoordinateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HitShots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HitShots_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HitShots_Coordinates_CoordinateId",
                        column: x => x.CoordinateId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissShots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardId = table.Column<int>(nullable: false),
                    CoordinateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissShots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissShots_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MissShots_Coordinates_CoordinateId",
                        column: x => x.CoordinateId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipId = table.Column<int>(nullable: false),
                    CoordinateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipPositions_Coordinates_CoordinateId",
                        column: x => x.CoordinateId,
                        principalTable: "Coordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipPositions_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Coordinates",
                columns: new[] { "Id", "Column", "Row" },
                values: new object[,]
                {
                    { 1, "a", 1 },
                    { 73, "c", 8 },
                    { 72, "b", 8 },
                    { 71, "a", 8 },
                    { 70, "j", 7 },
                    { 69, "i", 7 },
                    { 68, "h", 7 },
                    { 67, "g", 7 },
                    { 66, "f", 7 },
                    { 65, "e", 7 },
                    { 64, "d", 7 },
                    { 63, "c", 7 },
                    { 62, "b", 7 },
                    { 61, "a", 7 },
                    { 60, "j", 6 },
                    { 59, "i", 6 },
                    { 58, "h", 6 },
                    { 57, "g", 6 },
                    { 56, "f", 6 },
                    { 55, "e", 6 },
                    { 54, "d", 6 },
                    { 53, "c", 6 },
                    { 74, "d", 8 },
                    { 52, "b", 6 },
                    { 75, "e", 8 },
                    { 77, "g", 8 },
                    { 98, "h", 10 },
                    { 97, "g", 10 },
                    { 96, "f", 10 },
                    { 95, "e", 10 },
                    { 94, "d", 10 },
                    { 93, "c", 10 },
                    { 92, "b", 10 },
                    { 91, "a", 10 },
                    { 90, "j", 9 },
                    { 89, "i", 9 },
                    { 88, "h", 9 },
                    { 87, "g", 9 },
                    { 86, "f", 9 },
                    { 85, "e", 9 },
                    { 84, "d", 9 },
                    { 83, "c", 9 },
                    { 82, "b", 9 },
                    { 81, "a", 9 },
                    { 80, "j", 8 },
                    { 79, "i", 8 },
                    { 78, "h", 8 },
                    { 76, "f", 8 },
                    { 51, "a", 6 },
                    { 50, "j", 5 },
                    { 49, "i", 5 },
                    { 22, "b", 3 },
                    { 21, "a", 3 },
                    { 20, "j", 2 },
                    { 19, "i", 2 },
                    { 18, "h", 2 },
                    { 17, "g", 2 },
                    { 16, "f", 2 },
                    { 15, "e", 2 },
                    { 14, "d", 2 },
                    { 13, "c", 2 },
                    { 12, "b", 2 },
                    { 11, "a", 2 },
                    { 10, "j", 1 },
                    { 9, "i", 1 },
                    { 8, "h", 1 },
                    { 7, "g", 1 },
                    { 6, "f", 1 },
                    { 5, "e", 1 },
                    { 4, "d", 1 },
                    { 3, "c", 1 },
                    { 2, "b", 1 },
                    { 23, "c", 3 },
                    { 24, "d", 3 },
                    { 25, "e", 3 },
                    { 26, "f", 3 },
                    { 48, "h", 5 },
                    { 47, "g", 5 },
                    { 46, "f", 5 },
                    { 45, "e", 5 },
                    { 44, "d", 5 },
                    { 43, "c", 5 },
                    { 42, "b", 5 },
                    { 41, "a", 5 },
                    { 40, "j", 4 },
                    { 39, "i", 4 },
                    { 99, "i", 10 },
                    { 38, "h", 4 },
                    { 36, "f", 4 },
                    { 35, "e", 4 },
                    { 34, "d", 4 },
                    { 33, "c", 4 },
                    { 32, "b", 4 },
                    { 31, "a", 4 },
                    { 30, "j", 3 },
                    { 29, "i", 3 },
                    { 28, "h", 3 },
                    { 27, "g", 3 },
                    { 37, "g", 4 },
                    { 100, "j", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_ComputerBoardId",
                table: "Games",
                column: "ComputerBoardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlayerBoardId",
                table: "Games",
                column: "PlayerBoardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HitShots_BoardId",
                table: "HitShots",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_HitShots_CoordinateId",
                table: "HitShots",
                column: "CoordinateId");

            migrationBuilder.CreateIndex(
                name: "IX_MissShots_BoardId",
                table: "MissShots",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_MissShots_CoordinateId",
                table: "MissShots",
                column: "CoordinateId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipPositions_CoordinateId",
                table: "ShipPositions",
                column: "CoordinateId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipPositions_ShipId",
                table: "ShipPositions",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_BoardId",
                table: "Ships",
                column: "BoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "HitShots");

            migrationBuilder.DropTable(
                name: "MissShots");

            migrationBuilder.DropTable(
                name: "ShipPositions");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
