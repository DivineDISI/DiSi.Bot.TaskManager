using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiSi.Bot.TaskManager.DB.Enums;

namespace DiSi.Bot.TaskManager.DB.Entities;
public class Project
{
    public Project()
    {
        
    }

    public Project(string projName, User creator, BotDbContextBase context)
    {
        ProjectName = projName;
        
        CreatedTime = DateTime.UtcNow;
        UpdatedTime = DateTime.UtcNow;

        Status = ProjectStatus.Active;

        var part = new ProjectParticipant(this, creator, Helper.CreatorPrivilegies);
        context.Participants.Add(part);

        Participants.Add(part);

        ParticipantsAccounts.Add(creator);

    }

    public long Id { get; set; }

    public string ProjectName { get; set; } = string.Empty;

    public DateTime CreatedTime { get; set; }

    public DateTime UpdatedTime { get; set; }

    public ProjectStatus Status { get; set; }

    public virtual List<ProjectUri> ProjectUris { get; set; } = [];

    public virtual List<ProjectParticipant> Participants { get; set; } = [];

    public virtual List<User> ParticipantsAccounts { get; set; } = [];

    public virtual List<ProjectTask> Tasks { get; set; } = [];
}
