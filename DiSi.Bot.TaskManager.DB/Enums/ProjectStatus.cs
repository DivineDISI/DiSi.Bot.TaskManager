using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiSi.Bot.TaskManager.DB.Enums;
public enum ProjectStatus
{
    None,
    /// <summary>
    /// Активный проект.
    /// </summary>
    Active,
    /// <summary>
    /// Замороженый проект.
    /// </summary>
    Frozen,
    /// <summary>
    /// Закрытый проект.
    /// </summary>
    Closed,
}
