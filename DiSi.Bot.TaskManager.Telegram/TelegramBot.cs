using DiSi.Bot.TaskManager.UI.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DiSi.Bot.TaskManager.Telegram;

public class TelegramBot(string token)
{
    public event Func<ITelegramBotClient, InlineQuery, CancellationToken, Task>? HandleInlineQuery;
    public event Func<ITelegramBotClient, Message, CancellationToken, Task>? HandleMessage;
    public event Func<ITelegramBotClient, CallbackQuery, CancellationToken, Task>? HandleCallbackQuery;
    public event Func<ITelegramBotClient, Exception, CancellationToken, Task>? HandleError;

    private ITelegramBotClient _client = new TelegramBotClient(token);

    public ITelegramBotClient Client => _client;

    public void StartReceiving(CancellationToken token = default)
    {
        _client.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandleErrorAsync,
            cancellationToken: token);
    }

    public TelegramMessageBuilder CreateMessage()
        => new();

    public async Task<Message> SendCustomMessage(ICustomMessage message, long chatId, CancellationToken token = default)
        => await message.GetMessage().SendTextMessage(_client, chatId, token);

    private async Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        => await HandleError?.Invoke(client, exception, token)!;

    private async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
    {
        if (update.InlineQuery != null && 
            update.InlineQuery.ChatType == ChatType.Private &&
            HandleInlineQuery is not null)
            await HandleInlineQuery?.Invoke(client, update.InlineQuery, token)!;

        if (update.Message != null && 
            update.Message.Chat.Type == ChatType.Private &&
            HandleMessage is not null)
            await HandleMessage?.Invoke(client, update.Message, token)!;

        if (update.CallbackQuery != null && 
            HandleCallbackQuery is not null)
            await HandleCallbackQuery?.Invoke(client, update.CallbackQuery, token)!;
    }
}