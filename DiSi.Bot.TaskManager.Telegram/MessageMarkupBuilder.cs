using Telegram.Bot.Types.ReplyMarkups;

namespace DiSi.Bot.TaskManager.Telegram;

public class MessageMarkupBuilder
{
    private TelegramMessageBuilder _messageBuilder;

    private List<IEnumerable<KeyboardButton>> _markups = new();
    
    internal MessageMarkupBuilder(TelegramMessageBuilder messageBuilder)
    {
        _messageBuilder = messageBuilder;
    }

    public MessageMarkupBuilder AddRow(IEnumerable<KeyboardButton> row)
    {
        _markups.Add(row);
        return this;
    }
    
    public MarkupRowBuilder CreateRow()
        => new MarkupRowBuilder(this);

    public TelegramMessageBuilder Build()
    {
        _messageBuilder.SetReplyMarkup(new ReplyKeyboardMarkup(_markups));
        return _messageBuilder;
    }
}