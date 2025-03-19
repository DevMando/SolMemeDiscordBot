using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace SolMemeDiscordBot
{
    public class RugCheck
    {
        public const string MOST_VIEWED_TOKENS_API_URL = "https://api.rugcheck.xyz/v1/stats/recent";
        protected string RugCheckApiToken = String.Empty;

        public RugCheck() { }

        public async Task<string> GetMostViewedTokens()
        {
            string result = String.Empty;

            using var client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync(MOST_VIEWED_TOKENS_API_URL);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(content);

                    foreach (var token in data)
                    {
                        result += $"{token.metadata.name} ({token.metadata.symbol})\n";
                        result += $"User Visits: {token.user_visits}\n";
                        result += $"Visits: {token.visits}\n";
                        result += $"Score: {token.score}\n";
                        result += $"https://gmgn.ai/sol/token/{token.mint}\n\n";
                    }


                    return result;
                }
                else
                {
                    Console.WriteLine($"Network Error: {response.StatusCode}");
                    result = "I'm unable to retrieve that info at the moment. Try again later.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                result = "I'm unable to retrieve that info at the moment. Try again later.";
            }

            return result;
        }
    }
}