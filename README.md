# SolMeme Discord Bot

![.NET](https://img.shields.io/badge/.NET-9.0-blueviolet)
![CSharp](https://img.shields.io/badge/C%23-Discord.Net-blue)
![Docker](https://img.shields.io/badge/Docker-Ready-2496ED)
![License](https://img.shields.io/badge/License-MIT-green)
![Status](https://img.shields.io/badge/Status-Active-brightgreen)
![Beta](https://img.shields.io/badge/Release-Beta-yellow)

---

A lightweight, on-demand Discord bot that fetches and posts the **most viewed Solana tokens** using the **RugCheck API**.  
Built with **C# (.NET 9)**, **Discord.Net**, and ready for **Docker deployment**.

---

## 📋 Features

- 🔥 **On-Demand Token Fetching**  
  Fetches the latest trending Solana tokens when a user types `Get-Tokens`.

- 🐳 **Docker-Ready**  
  Fully containerizable for deployment to cloud services (Azure, AWS, etc.).

- ⚡ **Modern .NET 9 Architecture**  
  Built with clean and efficient code using .NET 9.

---

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- A Discord Bot Token
- (Optional) Docker installed if you want to containerize

---

## 🛠️ Setup Instructions

### 1. Create a Discord Application

- Go to the [Discord Developer Portal](https://discord.com/developers/applications) and create a new application.

### 2. Add the Bot to Your Server

- Under **[OAuth2] -> [URL Generator]**:
  - Select **bot** under scopes.
  - Grant appropriate permissions (e.g., **Send Messages**, **Read Messages**, **Administrator**).
  - Copy and navigate to the generated invite URL to add the bot to your server.

### 3. Configure Bot Username

- Under the **[Bot]** tab, set the **Username** for your bot (this is the name users will see in Discord).

### 4. Generate Bot Token

- Under the **[Bot]** tab:
  - Generate or reset the **Token**.
  - **Copy** the token — you’ll need it to configure the bot.

### 5. Create `appsettings.json`

At the root of the project, create a file named `appsettings.json`:

```json
{
  "Discord": {
    "Token": "YOUR_DISCORD_BOT_TOKEN",
    "ChannelId": "YOUR_CHANNEL_ID"
  }
}
```

## ⚙️ How It Works
Listens to messages in the connected Discord server.

When a user sends Get-Tokens, the bot:

Calls the RugCheck API to retrieve the list of top-viewed Solana tokens.

Posts the names, symbols, and links to the configured channel.

✅ The bot only fetches data when prompted — no background polling.

## 📂 Project Structure

| File / Folder        | Description                                           |
|----------------------|-------------------------------------------------------|
| `Program.cs`          | Main entry point and application configuration.       |
| `Services/`           | Handles Discord commands and RugCheck API integration.|
| `Models/`             | Data models for representing token responses.         |
| `Helpers/`            | Utility classes for HTTP requests and JSON parsing.   |
| `appsettings.json`    | Configuration file for Discord token and channel ID.  |

## 🎯 Future Improvements
- 🎨 Add rich Discord embeds (with token logos and better formatting).
- 🔔 Allow keyword alerts and user notifications.
- 🛠️ Add configuration options for number of tokens returned (top 5, top 10, etc).
- 🌐 Multi-server (guild) support with dynamic configurations.
- 📢 **Trending Alerts**  
  Posts token names, symbols, and RugCheck links to a Discord channel.
