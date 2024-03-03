using DiSi.Bot.TaskManager.Telegram;
using DiSi.Bot.TaskManager.UI.Interfaces;
using Telegram.Bot.Types.Enums;

namespace DiSi.Bot.TaskManager.UI;

public class StartMessage : ICustomMessage
{
    public const string Title = "Hello, this is TaskManager bot.";
    public const string Desctiption = "I'm here to help you and you team deal with tasks.";
    public const string Ending = "Hope, you enjoy it!";
    
    public TelegramMessageBuilder GetMessage()
    {
        var text = MarkDownTextBuilder.Create()
            .AddBold(Title).Line(2)
            .AddText(Desctiption).Line(2)
            .AddItalic(Ending)
            .GetText();
        
        return TelegramMessageBuilder.Create()
            .UseParseMode(ParseMode.Markdown)
            .AddText(text)
            .CreateInlineMarkup()
                .AddRow("1", "2", "3", "4")
                .AddRow("4", "5", "6")
                .Use();
    }
}