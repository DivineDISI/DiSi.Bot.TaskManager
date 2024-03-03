namespace DiSi.Bot.TaskManager.DB.Entities;
public class ProjectTask
{
    public ProjectTask()
    {

    }

    public ProjectTask(Project proj, User creator, string title, string description, Enums.TaskStatus status = Enums.TaskStatus.Active)
    {
        Title = title;
        Description = description;
        Project = proj;
        Creator = creator;
        Status = status;
    }

    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedTime { get; set; }

    public DateTime UpdatedTime { get; set; }

    public Enums.TaskStatus Status { get; set; }

    public virtual Project Project { get; set; } = null!;


    public virtual User Creator { get; set; } = null!;

    public virtual User? Executor { get; set; } = null!;
}
