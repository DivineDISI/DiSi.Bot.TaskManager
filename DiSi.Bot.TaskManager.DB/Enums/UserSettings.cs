using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiSi.Bot.TaskManager.DB.Enums;
public enum UserSettings
{
    None = 0,

    /// <summary>
    /// Разрешить уведомления о изменении статуса проектов.
    /// </summary>
    AllowProjectStatusChandjedNotification = 1 << 0,
    /// <summary>
    /// Разрешить уведомления от срочных заданий.
    /// </summary>
    AllowHotTasksNotification = 1 << 1,
    /// <summary>
    /// Разрешить уведомления от всех заданий.
    /// </summary>
    AllowTasksNotification = 1 << 2,
}
