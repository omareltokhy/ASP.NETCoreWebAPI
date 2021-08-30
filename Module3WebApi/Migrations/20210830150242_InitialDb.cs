using Microsoft.EntityFrameworkCore.Migrations;

namespace Module3WebApi.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trailer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesCharacters",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesCharacters", x => new { x.MovieId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_MoviesCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesCharacters_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "Picture" },
                values: new object[,]
                {
                    { 1, "Elessar", "Aragorn II", "Male", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ-nmKWSWArrznZJ6k4_fxgROIXe-PJzM5ftA&usqp=CAU" },
                    { 2, "Lockbearer", "Gimli", "Male", "https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars/de/de43f55bd8eae369bbfe24e828a76295e9445126_full.jpg" },
                    { 3, null, "Bilbo Baggins", "Male", "https://steamuserimages-a.akamaihd.net/ugc/795385183690202105/14AD7025C102913BB7E86371F8678B915F057B16/?imw=512&&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false" },
                    { 4, "The boy who lived", "Harry Potter", "Male", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQkJe2TpGHZYj-yLDZw-rstQfMA61hs6OEutw&usqp=CAU" },
                    { 5, null, "Hermione Granger", "Female", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSrFSwIAz5GfZVSgi2Z_2r3oVfCkM_PYp1bTg&usqp=CAU" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The Lord of the Rings is a series of three epic fantasy adventure films directed by Peter Jackson, based on the novel written by J. R. R. Tolkien.", "The Lord of the Rings" },
                    { 2, "Harry Potter is a film series based on the eponymous novels by J. K. Rowling.", "Harry Potter" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "Picture", "ReleaseYear", "Title", "Trailer" },
                values: new object[] { 1, "Peter Jackson", 1, "Epic, Fantasy, Adventure", "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Lord_of_the_Rings_The_Fellowship_of_the_Ring_%282001%29.jpg", 2001, "The Lord of the Rings: The Fellowship of the Ring", "https://www.youtube.com/watch?v=V75dMMIW2B4&ab_channel=Movieclips" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "Picture", "ReleaseYear", "Title", "Trailer" },
                values: new object[] { 3, "Peter Jackson", 1, "Fantasy, Adventure", "https://www.discshop.fi/img/front_large/125948/the_hobbit_an_unexpected_journey_blu_ray.jpg", 2012, "The Hobbit", "https://www.youtube.com/watch?v=JTSoD4BBCJc&t=18s&ab_channel=MovieclipsComingSoon" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "Picture", "ReleaseYear", "Title", "Trailer" },
                values: new object[] { 2, "Chris Columbus", 2, "Fantasy, Adventure", "https://static.wikia.nocookie.net/harrypotter/images/c/c5/Harry_Potter_and_the_Chamber_of_Secrets_UK_Poster.jpg/revision/latest?cb=20150209181936", 2002, "Harry Potter and the Chamber of Secrets", "https://www.youtube.com/watch?v=jBltxS8HfQ4&ab_channel=KinoCheckInternational" });

            migrationBuilder.InsertData(
                table: "MoviesCharacters",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 3 },
                    { 4, 2 },
                    { 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FranchiseId",
                table: "Movies",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesCharacters_CharacterId",
                table: "MoviesCharacters",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviesCharacters");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
