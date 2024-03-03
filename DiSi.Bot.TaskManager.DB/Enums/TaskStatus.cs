namespace DiSi.Bot.TaskManager.DB.Enums;
public enum TaskStatus
{
    None,
    /// <summary>
    /// Срочная задача.
    /// </summary>
    Hot,
    /// <summary>
    /// Доступная для выполнения в данный момент.
    /// </summary>
    Active,
    /// <summary>
    /// Сейчас выполняется.
    /// </summary>
    Execution,
    /// <summary>
    /// Отменена.
    /// </summary>
    Cancelled,
    /// <summary>
    /// Выполнена.
    /// </summary>
    Completed,
    /// <summary>
    /// Невыплненная задача.
    /// </summary>
    Unfulfilled
}
