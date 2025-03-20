using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SolMemeDiscordBot
{

    public class Bot
    {
        private readonly DiscordSocketClient _client;
        private string DiscordToken = String.Empty;
        private const string DummyToken = "PLACE_YOUR_DISCORD_TOKEN_HERE_FOR_LOCAL_DEVELOPMENT";

        public Bot()
        {
            SetupDiscordToken();

            this._client = new DiscordSocketClient();
            this._client.MessageReceived += MessageHandler;
        }

        protected void SetupDiscordToken()
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables()
              .Build();

            this.DiscordToken = config["Discord_Token"];


            if (string.IsNullOrEmpty(this.DiscordToken.Trim()) || this.DiscordToken == DummyToken)
            {
                throw new Exception("Discord token is missing! Set it in appsettings.json or as an environment variable.");
            }

            Console.WriteLine("Token loaded successfully!");
        }

        public async Task Start()
        {
            await this._client.LoginAsync(Discord.TokenType.Bot, DiscordToken);
            Console.WriteLine("Bot Successfully Logged In");
            await this._client.StartAsync();
            Console.WriteLine("Bot is running!");
            await Task.Delay(-1);
        }

        private async Task MessageHandler(SocketMessage message)
        {
            if (!message.Author.IsBot)
            {
                Console.WriteLine($"Received message: {message.Content ?? String.Empty}");
                {
                    string[] greetings = new string[] { "Hey", "Hello", "Hi", "Wassup", "Waddup", "Howdy", "Yo", "You called?" };

                    if (message.Content.ToLower().Contains("hi"))
                    {
                        Random random = new Random();
                        int index = random.Next(greetings.Length);

                        await ReplyAsync(message, $"{greetings[index]} {message.Author.GlobalName}!");
                    }
                    else if (message.Content.ToLower().Contains("get-tokens"))
                    {
                        string response = "Here are the MOST viewed tokens at this very moment:\n";
                        RugCheck rugCheck = new RugCheck();
                        string mostViewedTokens = await rugCheck.GetMostViewedTokens();
                        response += mostViewedTokens;
                        await ReplyAsync(message, response);
                    }
                }

            }
        }

        private async Task ReplyAsync(SocketMessage message, string response)
        {
            await message.Channel.SendMessageAsync(response);
        }

        // Process the message from the end-user and get a response, depending on the user's request.
        private async Task<object> GetResponse(SocketMessage message)
        {
            object response = null;

            try
            {
                response = "Cool";
            }
            catch
            {

            }
            finally
            {
                response = "I'm sorry, I don't understand that command."; ;
            }

            return response;
        }
    }
}
