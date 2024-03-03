using DiSi.Bot.TaskManager.UI.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace DiSi.Bot.TaskManager.Telegram;

public class TelegramBot
{
    public event Func<ITelegramBotClient, InlineQuery, CancellationToken, Task> HandleInlineQuery;
    public event Func<ITelegramBotClient, Message, CancellationToken, Task> HandleMessage;
    public event Func<ITelegramBotClient, CallbackQuery, CancellationToken, Task> HandleCallbackQuery;
    public event Func<ITelegramBotClient, Exception, CancellationToken, Task> HandleError;
    
    private ITelegramBotClient _client;
    
    public ITelegramBotClient Client => _client;
    
    public TelegramBot(string token)
    {
        _client = new TelegramBotClient(token);
    }

    public void StartReceiving(CancellationToken token = default)
    {
        _client.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandleErrorAsync,
            cancellationToken: token);
    }

    public TelegramMessageBuilder CreateMessage()
        => new TelegramMessageBuilder();
    
    public async Task<Message> SendCustomMessage(ICustomMessage message, long chatId, CancellationToken token = default)
        => await message.GetMessage().SendTextMessage(_client, chatId, token);
    
    private async Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        => await HandleError?.Invoke(client, exception, token);
    
    private async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
    {
        if (update.InlineQuery != null)
            await HandleInlineQuery?.Invoke(client, update.InlineQuery, token);
        if (update.Message != null)
            await HandleMessage?.Invoke(client, update.Message, token);
        if (update.CallbackQuery != null)
            await HandleCallbackQuery?.Invoke(client, update.CallbackQuery, token);
    }
}