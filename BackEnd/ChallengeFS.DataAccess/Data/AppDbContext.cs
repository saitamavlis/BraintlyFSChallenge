using ChallengeFS.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeFS.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<ToDo> ToDos { get; set; }

    }
}