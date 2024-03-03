using Telegram.Bot.Types.ReplyMarkups;

namespace DiSi.Bot.TaskManager.Telegram;

public class MarkupRowBuilder
{
    private MessageMarkupBuilder _markupBuilder;

    private List<KeyboardButton> _row = new();
    
    internal MarkupRowBuilder(MessageMarkupBuilder markupBuilder)
    {
        _markupBuilder = markupBuilder;
    }

    public MarkupRowBuilder Add(string text)
    {
        _row.Add(new KeyboardButton(text));
        return this;
    }

    public MessageMarkupBuilder Build()
    {
        return _markupBuilder;
    }
}