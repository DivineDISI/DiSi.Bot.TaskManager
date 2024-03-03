using DiSi.Bot.TaskManager.Telegram;

namespace DiSi.Bot.TaskManager.UI.Interfaces;

public interface ICustomMessage
{
    public TelegramMessageBuilder GetMessage();
}