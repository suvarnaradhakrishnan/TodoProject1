using Microsoft.EntityFrameworkCore;
using TodoProject.Models;

namespace TodoProject.Data
{
    public class TodoDbContext:DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Todos> todos { get; set; }
    }
}
