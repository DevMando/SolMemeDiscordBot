# SolMemeDiscordBot
A Discord bot to retrieve trending Solana meme tokens

### Setup Instructions:  
- Create an application in your discord applications in the Developer Portal: https://discord.com/developers/applications   
- Under [Installation] tab you will find an Install Link URL. Navigate to this URL and you will be prompted to add the bot to your discord channel. You can also grant permission scope (Administrator, send messsages etc..), select what you would like.  
- Under [Bot] tab -> USERNAME header, you can enter a 'UserName' for the bot. This is the username that will be displayed in Discord.  
- Under [Bot] tab -> TOKEN header, you generate or reset a token. This is the token you will declare in the appsettings.json file.   
- Place the following body in appsettings.json.  
```
{
  "Discord_Token": "YOUR TOKEN VALUE HERE"
}
```
  

### TODO:  
[] Implement Commands, instead of direct messaging for interactions.  
[] Implement Embed replies.  
[] Revamp the Solana Meme retrieval/web response processing.  
