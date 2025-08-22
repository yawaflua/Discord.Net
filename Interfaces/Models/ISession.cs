namespace yawaflua.Discord.Net.Interfaces.Models;

public interface ISession
{
    Task<IList<IGuild>?> GetGuildsAsync(CancellationToken cancellationToken = default);
    Task<IGuildMember?> GetGuildMemberAsync(ulong guildId, CancellationToken cancellationToken = default);
    Task<IGuildMember?> AddMemberToGuildAsync(ulong guildId, ulong userId, CancellationToken cancellationToken = default);
    Task<IUser?> GetCurrentUserAsync(CancellationToken cancellationToken = default);
    
    Task<IConnection?> GetConnectionAsync(CancellationToken cancellationToken = default);

    IToken GetToken(CancellationToken cancellationToken = default);
    
}