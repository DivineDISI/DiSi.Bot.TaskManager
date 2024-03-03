using System.ComponentModel.DataAnnotations.Schema;
using DiSi.Bot.TaskManager.DB.Enums;

namespace DiSi.Bot.TaskManager.DB.Entities;
public class User
{
    public User()
    {

    }

    public User(long userId, string username, string firstName, string lastName)
    {
        RegisterTime = DateTime.UtcNow;
        LastActiveTime = DateTime.UtcNow;
        UserId = userId;
        Username = username;
        FirstName = firstName;
        LastName = lastName;

        Settings = Helper.DefaultUserSettings;
    }

    public long Id { get; set; }

    public long UserId { get; set; }

    public DateTime RegisterTime { get; set; }

    public DateTime LastActiveTime { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public virtual List<Project> Projects { get; set; } = [];


    [InverseProperty(nameof(ProjectTask.Executor))]
    public virtual List<ProjectTask> ActiveTasks { get; set; } = [];

    [InverseProperty(nameof(ProjectTask.Creator))]
    public virtual List<ProjectTask> CreatedTasks { get; set; } = [];

    public UserSettings Settings { get; set; }
}
