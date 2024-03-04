using DiSi.Bot.TaskManager;
using DiSi.Bot.TaskManager.DB.Entities;
using DiSi.Bot.TaskManager.Telegram;
using DiSi.Bot.TaskManager.UI;
using Telegram.Bot;

using (var context = new BotDbContext())
    context.Database.EnsureCreated();

var botclient = new TelegramBot("1716341609:AAHasnF3rPIIPd9iURhqBG3w7obzXsepPy4");

botclient.StartReceiving();

botclient.HandleMessage += async (client, message, token) =>
{
    if(message.Text != "/start")
        return;

    await Console.Out.WriteLineAsync(message.Text + message.Chat.Id);

    using(var context = new BotDbContext())
    {
        if(context.Users.FirstOrDefault(x => x.UserId == message.From!.Id) is User user)
        {
            await botclient.SendCustomMessage(
                new WelcomeMessage($"{user.FirstName} {user.LastName}"), message.Chat.Id, token);

            user.LastActiveTime = DateTime.UtcNow;
        }
        else
        {
            await botclient.SendCustomMessage(new StartMessage(), message.Chat.Id, token);

            var newUser = new User(
                message.From!.Id, 
                message.From.Username ?? string.Empty, 
                message.From.FirstName ?? string.Empty, 
                message.From.LastName ?? string.Empty);

            context.Add(newUser);
        }
        
        context.SaveChanges();
    }
};

Console.ReadKey();