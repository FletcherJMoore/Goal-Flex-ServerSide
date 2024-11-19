using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Goal_Flex_ServerSide.Migrations
{
    public partial class FixUserForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Calories = table.Column<string>(type: "text", nullable: true),
                    Recipe = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<string>(type: "text", nullable: true),
                    Difficulty = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workouts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Instructions = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    WorkoutId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Strength Training" },
                    { 2, "Cardio" },
                    { 3, "Flexibility" },
                    { 4, "Endurance" },
                    { 5, "HIIT" },
                    { 6, "Core" },
                    { 7, "Plyometrics" },
                    { 8, "Weight Loss" },
                    { 9, "Mobility" },
                    { 10, "Rehabilitation" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Uid", "Username" },
                values: new object[,]
                {
                    { 1, "phellier0@technorati.com", "Pansy", "http://dummyimage.com/249x100.png/cc0000/ffffff", "Hellier", "1", "phellier0" },
                    { 2, "jgandey1@jigsy.com", "Judah", "http://dummyimage.com/174x100.png/cc0000/ffffff", "Gandey", "2", "jgandey1" },
                    { 3, "jgeddis2@topsy.com", "Jesse", "http://dummyimage.com/185x100.png/cc0000/ffffff", "Geddis", "3", "jgeddis2" },
                    { 4, "aantram3@quantcast.com", "Archambault", "http://dummyimage.com/223x100.png/dddddd/000000", "Antram", "4", "aantram3" },
                    { 5, "nalyokhin4@alexa.com", "Nolan", "http://dummyimage.com/227x100.png/ff4444/ffffff", "Alyokhin", "5", "nalyokhin4" },
                    { 6, "beves5@japanpost.jp", "Blaine", "http://dummyimage.com/153x100.png/ff4444/ffffff", "Eves", "6", "beves5" },
                    { 7, "aaronovich6@google.cn", "Amelita", "http://dummyimage.com/168x100.png/dddddd/000000", "Aronovich", "7", "aaronovich6" },
                    { 8, "nfalla7@ezinearticles.com", "Nicko", "http://dummyimage.com/225x100.png/cc0000/ffffff", "Falla", "8", "nfalla7" },
                    { 9, "tmacewan8@berkeley.edu", "Trever", "http://dummyimage.com/218x100.png/ff4444/ffffff", "Macewan", "9", "tmacewan8" },
                    { 10, "kenglefield9@jiathis.com", "Karoly", "http://dummyimage.com/110x100.png/dddddd/000000", "Englefield", "10", "kenglefield9" },
                    { 11, "joeaverage@example.com", "Joe", "http://dummyimage.com/110x100.png/dddddd/000000", "Average", "11", "joeaverage9" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Image", "Instructions", "Title", "UserId", "WorkoutId" },
                values: new object[,]
                {
                    { 1, "http://dummyimage.com/250x150.png/ff0000/ffffff", "Start in a plank position, lower your chest to the ground, and push back up.", "Push-Ups", 1, null },
                    { 2, "http://dummyimage.com/250x150.png/00ff00/ffffff", "Stand with feet shoulder-width apart, bend your knees, and lower your hips.", "Squats", 2, null },
                    { 3, "http://dummyimage.com/250x150.png/0000ff/ffffff", "Hold your body in a straight line with your forearms and toes on the ground.", "Plank", 3, null },
                    { 4, "http://dummyimage.com/250x150.png/ffff00/000000", "Hold weights in each hand and curl them toward your shoulders.", "Bicep Curls", 4, null },
                    { 5, "http://dummyimage.com/250x150.png/ff00ff/ffffff", "Step forward with one leg, bend both knees, and lower your body.", "Lunges", 5, null },
                    { 6, "http://dummyimage.com/250x150.png/00ffff/000000", "Jump with your legs apart and your arms overhead, then return to the starting position.", "Jumping Jacks", 6, null },
                    { 7, "http://dummyimage.com/250x150.png/800080/ffffff", "Lift a barbell or weights from the ground to your thighs while keeping your back straight.", "Deadlifts", 7, null },
                    { 8, "http://dummyimage.com/250x150.png/ffa500/000000", "Start in a plank position and alternate bringing your knees toward your chest.", "Mountain Climbers", 8, null },
                    { 9, "http://dummyimage.com/250x150.png/008080/ffffff", "From a standing position, drop to a squat, kick your legs back into a plank, and then jump back up.", "Burpees", 9, null },
                    { 10, "http://dummyimage.com/250x150.png/c0c0c0/000000", "Lie on a bench, lower the barbell to your chest, and press it back up.", "Bench Press", 10, null }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Calories", "Image", "Recipe", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "350 kcal", "http://dummyimage.com/250x150.png/ff5733/ffffff", "Grill chicken breast and serve with mixed greens, cherry tomatoes, and vinaigrette.", "Grilled Chicken Salad", 1 },
                    { 2, "200 kcal", "http://dummyimage.com/250x150.png/33ff57/ffffff", "Sauté mixed vegetables in olive oil with soy sauce and garlic.", "Vegetable Stir-Fry", 2 },
                    { 3, "250 kcal", "http://dummyimage.com/250x150.png/3357ff/ffffff", "Toast whole-grain bread and top with mashed avocado and a sprinkle of salt.", "Avocado Toast", 3 },
                    { 4, "300 kcal", "http://dummyimage.com/250x150.png/ffff33/000000", "Blend protein powder, banana, almond milk, and spinach.", "Protein Smoothie", 4 },
                    { 5, "400 kcal", "http://dummyimage.com/250x150.png/ff33ff/ffffff", "Cook quinoa and top with black beans, corn, avocado, and salsa.", "Quinoa Bowl", 5 },
                    { 6, "350 kcal", "http://dummyimage.com/250x150.png/33ffff/000000", "Cook oats and top with fresh berries and a drizzle of honey.", "Oatmeal with Berries", 6 },
                    { 7, "450 kcal", "http://dummyimage.com/250x150.png/663399/ffffff", "Season salmon fillet with olive oil, lemon, and dill, then grill until cooked.", "Grilled Salmon", 7 },
                    { 8, "300 kcal", "http://dummyimage.com/250x150.png/cc0000/ffffff", "Wrap turkey slices, lettuce, and hummus in a whole-grain tortilla.", "Turkey Wrap", 8 },
                    { 9, "250 kcal", "http://dummyimage.com/250x150.png/66ff33/000000", "Simmer lentils with carrots, celery, onion, and vegetable broth.", "Lentil Soup", 9 },
                    { 10, "200 kcal", "http://dummyimage.com/250x150.png/ff9933/000000", "Layer Greek yogurt with granola and fresh fruit in a glass.", "Greek Yogurt Parfait", 10 }
                });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "Id", "CategoryId", "Difficulty", "Image", "Time", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Medium", "http://dummyimage.com/200x200.png/5fa2dd/ffffff", "30 mins", "Morning Cardio", 1 },
                    { 2, 2, "Easy", "http://dummyimage.com/200x200.png/ff4444/ffffff", "45 mins", "Yoga Session", 2 },
                    { 3, 1, "Hard", "http://dummyimage.com/200x200.png/dddddd/000000", "20 mins", "HIIT Training", 3 },
                    { 4, 3, "Hard", "http://dummyimage.com/200x200.png/cc0000/ffffff", "60 mins", "Strength Training", 4 },
                    { 5, 2, "Easy", "http://dummyimage.com/200x200.png/00ff00/000000", "15 mins", "Evening Stretching", 5 },
                    { 6, 3, "Medium", "http://dummyimage.com/200x200.png/0000ff/ffffff", "50 mins", "Full Body Workout", 6 },
                    { 7, 1, "Medium", "http://dummyimage.com/200x200.png/ffcc00/000000", "25 mins", "Core Blast", 7 },
                    { 8, 2, "Easy", "http://dummyimage.com/200x200.png/ff6666/ffffff", "35 mins", "Pilates Basics", 8 },
                    { 9, 3, "Hard", "http://dummyimage.com/200x200.png/333333/ffffff", "40 mins", "Upper Body Burn", 9 },
                    { 10, 3, "Medium", "http://dummyimage.com/200x200.png/ff00ff/ffffff", "30 mins", "Lower Body Focus", 10 },
                    { 11, 1, "Medium", "http://dummyimage.com/200x200.png/ff5733/ffffff", "40 mins", "Cardio Blast", 10 },
                    { 12, 2, "Easy", "http://dummyimage.com/200x200.png/33ff57/ffffff", "20 mins", "Stretch and Flex", 2 },
                    { 13, 3, "Hard", "http://dummyimage.com/200x200.png/3357ff/ffffff", "75 mins", "Power Lifting", 3 },
                    { 14, 1, "Hard", "http://dummyimage.com/200x200.png/ffff33/000000", "15 mins", "Quick HIIT", 4 },
                    { 15, 2, "Easy", "http://dummyimage.com/200x200.png/ff33ff/ffffff", "30 mins", "Balance Training", 5 },
                    { 16, 1, "Medium", "http://dummyimage.com/200x200.png/33ffff/000000", "60 mins", "Endurance Run", 6 },
                    { 17, 3, "Medium", "http://dummyimage.com/200x200.png/663399/ffffff", "25 mins", "Core Strength", 7 },
                    { 18, 3, "Hard", "http://dummyimage.com/200x200.png/cc0000/ffffff", "50 mins", "Arm and Shoulder Routine", 8 },
                    { 19, 2, "Medium", "http://dummyimage.com/200x200.png/66ff33/000000", "45 mins", "Pilates Pro", 9 },
                    { 20, 2, "Easy", "http://dummyimage.com/200x200.png/ff9933/000000", "60 mins", "Evening Yoga", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_UserId",
                table: "Exercises",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_UserId",
                table: "Meals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_CategoryId",
                table: "Workouts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
