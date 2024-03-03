using DiSi.Bot.TaskManager.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiSi.Bot.TaskManager.DB;

public class BotDbContextBase : DbContext
{
    public DbSet<Project> Projects { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<ProjectTask> Tasks { get; set; }

    public DbSet<ProjectUri> Uris { get; set; }

    public DbSet<ProjectParticipant> Participants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies(true);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
