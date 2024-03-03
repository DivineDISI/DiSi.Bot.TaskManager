using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiSi.Bot.TaskManager.DB.Enums;
public enum ParticipantPrivileges
{
    None = 0,
    /// <summary>
    /// Добавлять участников.
    /// </summary>
    AddParticipants = 1 << 0,
    /// <summary>
    /// Редактировать привелегии участников.
    /// </summary>
    EditParticipants = 1 << 1,
    /// <summary>
    /// Удалять участников.
    /// </summary>
    RemoveParticipants = 1 << 2,

    /// <summary>
    /// Создавать задачи.
    /// </summary>
    CreateTasks = 1 << 3,
    /// <summary>
    /// Изменять задачи.
    /// </summary>
    EditTasks = 1 << 4,
    /// <summary>
    /// Выполнять задачи.
    /// </summary>
    PerformTasks = 1 << 5,
    /// <summary>
    /// Удалать задачи
    /// </summary>
    DeleteTasks = 1 << 6,
}
