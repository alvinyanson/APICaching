using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APICaching.Migrations
{
    /// <inheritdoc />
    public partial class SeedTodoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Completed", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, true, "Buy groceries", 1 },
                    { 2, false, "Call Mom", 1 },
                    { 3, true, "Finish project report", 1 },
                    { 4, false, "Book doctor appointment", 1 },
                    { 5, true, "Clean the house", 1 },
                    { 6, false, "Fix the leaky faucet", 2 },
                    { 7, true, "Read a book", 2 },
                    { 8, false, "Exercise for 30 minutes", 2 },
                    { 9, true, "Prepare dinner", 2 },
                    { 10, false, "Reply to emails", 2 },
                    { 11, true, "Submit tax forms", 3 },
                    { 12, false, "Pay utility bills", 3 },
                    { 13, true, "Plan vacation trip", 3 },
                    { 14, false, "Buy a gift", 3 },
                    { 15, true, "Schedule car maintenance", 3 },
                    { 16, false, "Update resume", 4 },
                    { 17, true, "Organize files", 4 },
                    { 18, false, "Practice a hobby", 4 },
                    { 19, true, "Learn a new skill", 4 },
                    { 20, false, "Visit a museum", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
