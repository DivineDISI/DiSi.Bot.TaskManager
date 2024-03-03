using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace DiSi.Bot.TaskManager.Telegram;

public class TelegramMessageBuilder
{
    private ITelegramBotClient _client;
    
    private string _text = "";
    private IReplyMarkup? _markup = null;
    private ChatId? _chatId = null;
    private int? _replyToMessageId = null;
    
    internal TelegramMessageBuilder(ITelegramBotClient client)
    {
        _client = client;
    }

    public TelegramMessageBuilder SetChatID(ChatId chatId)
    {
        _chatId = chatId;
        return this;
    }
    
    public TelegramMessageBuilder AddText(string text)
    {
        _text += text;
        return this;
    }

    public TelegramMessageBuilder SetReplyMarkup(IReplyMarkup markup)
    {
        _markup = markup;
        return this;
    }
    
    public TelegramMessageBuilder SetReplyToMessageId(int replyToMessageId)
    {
        _replyToMessageId = replyToMessageId;
        return this;
    }
    
    public async Task<Message> SendTextMessage(CancellationToken cancellationToken)
    {
        return await _client.SendTextMessageAsync(
            chatId: _chatId,
            text: _text,
            parseMode: ParseMode.MarkdownV2,
            replyToMessageId: _replyToMessageId,
            replyMarkup: _markup,
            cancellationToken: cancellationToken);
    }
}