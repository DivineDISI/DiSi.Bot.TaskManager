using DiSi.Bot.TaskManager.Telegram;
using DiSi.Bot.TaskManager.UI;
using Telegram.Bot;

var botclient = new TelegramBot("1716341609:AAHasnF3rPIIPd9iURhqBG3w7obzXsepPy4");

botclient.StartReceiving();

botclient.HandleMessage += async (client, message, token) =>
{
    await Console.Out.WriteLineAsync(message.Text + message.Chat.Id);
    await botclient.SendCustomMessage(new StartMessage(), message.Chat.Id, token);
};

while(true){}