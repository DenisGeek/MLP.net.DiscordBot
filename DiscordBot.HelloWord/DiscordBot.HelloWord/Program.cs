using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace DiscordBot.HelloWord
{
    class Program
    {
        static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;

            // Remember to keep token private or to read it from an 
            // external source! In this case, we are reading the token 
            // from an environment variable. If you do not know how to set-up
            // environment variables, you may find more information on the 
            // Internet or by using other methods such as reading from 
            // a configuration.
            var v = Environment.GetEnvironmentVariable("DiscordToken");
            await _client.LoginAsync(TokenType.Bot,
                v);
            await _client.StartAsync();
            _client.MessageReceived += MessageReceived;
            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == "!Who")
            {
                await message.Channel.SendMessageAsync("MLP.net.BotTest");
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
