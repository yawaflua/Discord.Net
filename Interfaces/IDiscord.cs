using yawaflua.Discord.Net.Interfaces.Models;

namespace yawaflua.Discord.Net.Interfaces;

public interface IDiscord
{
    Task<IToken?> GetTokenAsync(string code);
    ISession? CreateSession();
}