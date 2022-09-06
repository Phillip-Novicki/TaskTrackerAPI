using Microsoft.EntityFrameworkCore;

namespace MemosBackend
{
    public class MemosContext : DbContext
    {
        public MemosContext(DbContextOptions<MemosContext> options) : base(options)
            { 
        }
        public DbSet<Memo> Memos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Memo>().ToTable("Memos");
        }


    }
}
