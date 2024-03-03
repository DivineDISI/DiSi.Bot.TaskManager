using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace DiSi.Bot.TaskManager.Telegram;

public class TelegramMessageBuilder
{
    private string _text = string.Empty;
    private InlineKeyboardMarkup? _markup = null;
    private int? _replyToMessageId = null;
    private ParseMode _parseMode = ParseMode.MarkdownV2;

    public static TelegramMessageBuilder Create()
        => new();
    
    public TelegramMessageBuilder UseParseMode(ParseMode mode)
    {
        _parseMode = mode;
        return this;
    }
    
    public TelegramMessageBuilder SetReplyToMessageId(int replyToMessageId)
    {
        _replyToMessageId = replyToMessageId;
        return this;
    }
    
    public TelegramMessageBuilder AddText(string text)
    {
        _text += text;
        Console.WriteLine(_text);
        return this;
    }
    public TelegramMessageBuilder SetInlineMarkup(InlineKeyboardMarkup markup)
    {
        _markup = markup;
        return this;
    }

    public InlineMarkupBuilder CreateInlineMarkup()
        => new(this);
    
    public async Task<Message> EditMessageTextAsync(ITelegramBotClient client, ChatId chatId, int messageId, CancellationToken cancellationToken = default)
        => await client.EditMessageTextAsync(
            chatId: chatId,
            messageId: messageId,
            text: _text,
            parseMode: ParseMode.MarkdownV2,
            cancellationToken: cancellationToken);
    
    public async Task<Message> EditMessageInlineMarkupAsync(ITelegramBotClient client, ChatId chatId, int messageId, CancellationToken cancellationToken = default)
        => await client.EditMessageReplyMarkupAsync(
            chatId: chatId,
            messageId: messageId,
            replyMarkup: _markup,
            cancellationToken: cancellationToken);
    
    public async Task<Message> SendTextMessage(ITelegramBotClient client, long chatId, CancellationToken cancellationToken = default)
        => await client.SendTextMessageAsync(
            chatId: chatId,
            text: _text,
            parseMode: ParseMode.Markdown,
            replyMarkup: _markup,
            cancellationToken: cancellationToken);
    
    
}