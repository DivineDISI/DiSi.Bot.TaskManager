using Telegram.Bot.Types.ReplyMarkups;

namespace DiSi.Bot.TaskManager.Telegram;

public class InlineMarkupBuilder
{
    private TelegramMessageBuilder _messageBuilder;

    private List<IEnumerable<InlineKeyboardButton>> _buttonTable = new();

    public InlineMarkupBuilder(){ }
    public InlineMarkupBuilder(TelegramMessageBuilder messageBuilder)
    {
        _messageBuilder = messageBuilder;
    }

    public InlineMarkupBuilder AddRow(params string[] contents)
    {
        _buttonTable.Add(contents.Select(x=>InlineKeyboardButton.WithCallbackData(x, x)));
        return this;
    }

    public InlineKeyboardMarkup GetInlineKeyboardMarkup()
        => new InlineKeyboardMarkup(_buttonTable);

    public TelegramMessageBuilder? Use()
    {
        _messageBuilder.SetInlineMarkup(GetInlineKeyboardMarkup());
        return _messageBuilder;
    }
}