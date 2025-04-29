using Microsoft.EntityFrameworkCore;
using backend.Controllers;

namespace backend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Expense> Expense { get; set; } = null!;
}