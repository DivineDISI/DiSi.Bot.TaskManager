using DiSi.Bot.TaskManager.DB;
using Microsoft.EntityFrameworkCore;

namespace DiSi.Bot.TaskManager;
public class BotDbContext : BotDbContextBase
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dir = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DiSi", "TaskManagerBot");
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        var path = Path.Join(dir, "bot.db");
        optionsBuilder.UseSqlite($"Data Source={path}");

        base.OnConfiguring(optionsBuilder);
    }
}
