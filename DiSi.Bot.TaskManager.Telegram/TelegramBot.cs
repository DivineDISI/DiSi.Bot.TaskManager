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
    public event Func<ITelegramBotClient, Update, CancellationToken, Task> UnhandledUpdate;
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
    
    private async Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        => await HandleError?.Invoke(client, exception, token);
    
    private async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
    {
        if (update.InlineQuery != null) 
            await HandleInlineQuery?.Invoke(client, update.InlineQuery, token);
        else if (update.Message != null) 
            await HandleMessage?.Invoke(client, update.Message, token);
        else if (update.CallbackQuery != null) 
            await HandleCallbackQuery?.Invoke(client, update.CallbackQuery, token);
        else 
            await UnhandledUpdate?.Invoke(client, update, token);
    }

    public TelegramMessageBuilder CreateMessage()
        => new TelegramMessageBuilder(_client);
}