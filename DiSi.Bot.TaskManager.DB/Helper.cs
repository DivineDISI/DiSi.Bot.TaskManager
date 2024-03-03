using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiSi.Bot.TaskManager.DB.Enums;

namespace DiSi.Bot.TaskManager.DB;
internal static class Helper
{

    public static ParticipantPrivileges CreatorPrivilegies => 
        ParticipantPrivileges.AddParticipants | 
        ParticipantPrivileges.EditParticipants | 
        ParticipantPrivileges.RemoveParticipants | 
        ParticipantPrivileges.CreateTasks | 
        ParticipantPrivileges.EditTasks | 
        ParticipantPrivileges.PerformTasks | 
        ParticipantPrivileges.DeleteTasks;

    public static UserSettings DefaultUserSettings => 
        UserSettings.AllowProjectStatusChandjedNotification | 
        UserSettings.AllowHotTasksNotification | 
        UserSettings.AllowTasksNotification;

}
