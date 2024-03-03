using System.Text;
using DiSi.Bot.TaskManager.Telegram;
using DiSi.Bot.TaskManager.UI.Interfaces;
using Telegram.Bot.Types.Enums;

namespace DiSi.Bot.TaskManager.UI;
internal class WelcomeMessage(string username) : ICustomMessage
{
    private string _username = username;
    public TelegramMessageBuilder GetMessage()
    {
        var text = MarkDownTextBuilder.Create()
            .AddBold($"Welcome back, {_username}").Line(2)
            .GetText();

        return TelegramMessageBuilder.Create()
            .UseParseMode(ParseMode.Markdown)
            .AddText(text)
            .CreateInlineMarkup()
                .AddRow("New project", "My Projects")
                .AddRow("Settings")
                .Use()!;
    }
}
