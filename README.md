# yawaflua.Discord.Net

[![NuGet](https://img.shields.io/nuget/v/yawaflua.Discord.Net.svg)](https://www.nuget.org/packages/yawaflua.Discord.Net/)
[![NuGet](https://img.shields.io/nuget/dt/yawaflua.Discord.Net.svg)](https://www.nuget.org/packages/yawaflua.Discord.Net/)

yawaflua.Discord.Net is a library for integrating Discord OAuth2 into your .NET applications. It provides a simple and easy-to-use interface for authenticating users with Discord, retrieving user information, and managing sessions.

## Features
- **OAuth2 Authentication**: Easily authenticate users with Discord using OAuth2.
- **User Information**: Retrieve user information such as username, avatar, and guilds.
- **Session Management**: Create and manage sessions for authenticated users.
- **Dependency Injection**: Seamlessly integrate with your .NET application's dependency injection system.

## Usage

```csharp
// Configure configuration to DI
builder.Services.AddSingleton<DiscordConfig>(
    new DiscordConfig
    {
        ClientId = "your-client-id",
        ClientSecret = "shhhhh!",
        RedirectUri = "https://example.com/Login",
        Scopes = new ScopesBuilder(OAuthScope.Identify, OAuthScope.Guilds),
        Token = "MyVeryCool.BotToken.For.Discord" // Optional, for bot interactions
    });
builder.Services.AddSingleton<IDiscord, DiscordOAuth>();

// And use it in you very cool controller or smth

public class MyController (IDiscord discord) : ControllerBase
{
    public async Task<IActionResult> Login()
    {
        var url = discord.GetAuthorizationUrl("state");
        return Redirect(url);
    }
    
    public async Task<IActionResult> Callback()
    {
        if (discord.TryGetCode(HttpContext, out var code))
        {
            var token = await discord.GetTokenAsync(code);
            var user = await discord.GetUserAsync(token);
            
            var session = discord.CreateSession();
            var guilds = await session.GetGuildsAsync();
            // Do something with the user and guilds, like storing them in a database or session
            // ...
            
            return Ok();
        }
        
        return BadRequest("Invalid code");
    }
}
```

## Feedback

`yawaflua.Discord.Net` is a library still in development, and your feedback or support is very welcome. If you have any issues, suggestions, or questions, please open an issue on the [GitHub repository](https://github.com/yawaflua/Discord.Net/)


This library is released under the [Apache 2.0](LICENSE).
