using Microsoft.EntityFrameworkCore;

namespace ApiEvaluacion.Models;

public class DbApiContext : DbContext
{
    public DbApiContext(DbContextOptions<DbApiContext> options)
        : base(options)
    {
    }

    public DbSet<User> user { get; set; } = null!;

}
