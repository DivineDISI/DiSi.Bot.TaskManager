using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace DiSi.Bot.TaskManager.Telegram;

public class TelegramMessageBuilder
{
    private ITelegramBotClient _client;
    
    private string _text = "";
    private IReplyMarkup? _markup;
    private ChatId? _chatId = null;
    private int? _replyToMessageId = null;
    
    internal TelegramMessageBuilder(TelegramBotClient client)
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
    
    public TelegramMessageBuilder AddButton(string content, int row, int column)
    {
        return this;
    }

    public void SetReplyMarkup(IReplyMarkup markup)
    {
        _markup = markup;
    }
    
    public TelegramMessageBuilder SetReplyToMessageId(int replyToMessageId)
    {
        return this;
    }
    
    public async Task<Message> SendTextMessage()
    {
        _client.SendTextMessageAsync(
            chatId: _chatId,
            text: _text,
            parseMode: ParseMode.MarkdownV2,
            disableNotification: true,
            replyToMessageId: _replyToMessageId,
            replyMarkup: new InlineKeyboardMarkup(
                InlineKeyboardButton.WithUrl(
                    text: "Check sendMessage method",
                    url: "https://core.telegram.org/bots/api#sendmessage")),
            cancellationToken: cancellationToken);
    }
}