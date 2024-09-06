using APICaching.Models;
using Microsoft.EntityFrameworkCore;

namespace APICaching.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Todo[] seedTodos =
            {
                new() { UserId = 1, Id = 1, Title = "Buy groceries", Completed = true },
                new() { UserId = 1, Id = 2, Title = "Call Mom", Completed = false },
                new() { UserId = 1, Id = 3, Title = "Finish project report", Completed = true },
                new() { UserId = 1, Id = 4, Title = "Book doctor appointment", Completed = false },
                new() { UserId = 1, Id = 5, Title = "Clean the house", Completed = true },
                new() { UserId = 2, Id = 6, Title = "Fix the leaky faucet", Completed = false },
                new() { UserId = 2, Id = 7, Title = "Read a book", Completed = true },
                new() { UserId = 2, Id = 8, Title = "Exercise for 30 minutes", Completed = false },
                new() { UserId = 2, Id = 9, Title = "Prepare dinner", Completed = true },
                new() { UserId = 2, Id = 10, Title = "Reply to emails", Completed = false },
                new() { UserId = 3, Id = 11, Title = "Submit tax forms", Completed = true },
                new() { UserId = 3, Id = 12, Title = "Pay utility bills", Completed = false },
                new() { UserId = 3, Id = 13, Title = "Plan vacation trip", Completed = true },
                new() { UserId = 3, Id = 14, Title = "Buy a gift", Completed = false },
                new() { UserId = 3, Id = 15, Title = "Schedule car maintenance", Completed = true },
                new() { UserId = 4, Id = 16, Title = "Update resume", Completed = false },
                new() { UserId = 4, Id = 17, Title = "Organize files", Completed = true },
                new() { UserId = 4, Id = 18, Title = "Practice a hobby", Completed = false },
                new() { UserId = 4, Id = 19, Title = "Learn a new skill", Completed = true },
                new() { UserId = 4, Id = 20, Title = "Visit a museum", Completed = false }
            };


            modelBuilder.Entity<Todo>().HasData(seedTodos);
        }
    }
}
