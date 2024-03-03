using DiSi.Bot.TaskManager.DB.Enums;

namespace DiSi.Bot.TaskManager.DB.Entities;
public class ProjectParticipant
{
    public ProjectParticipant()
    {

    }

    public ProjectParticipant(Project proj, User user, ParticipantPrivileges privilegies = ParticipantPrivileges.None)
    {
        Privileges = privilegies;
        Project = proj;
        User = user;
    }

    public long Id { get; set; }

    public ParticipantPrivileges Privileges { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
