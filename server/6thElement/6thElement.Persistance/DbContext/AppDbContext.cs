using _6thElement.Domain;
using _6thElement.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _6thElement.Persistance.DbContext;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Module> Modules { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Module>()
            .HasMany(m => m.Chapters)
            .WithOne(c => c.Module)
            .HasForeignKey(c => c.ModuleId);

        modelBuilder.Entity<Chapter>()
            .HasMany(c => c.Questions)
            .WithOne(q => q.Chapter)
            .HasForeignKey(q => q.ChapterId);

        modelBuilder.Entity<Question>()
            .HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId);
    }
}
