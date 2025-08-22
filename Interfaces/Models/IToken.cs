namespace yawaflua.Discord.Net.Interfaces.Models;

public interface IToken
{
    public string? AccessToken { get; set; }
    public int ExpiresIn { get; set; }
    public string? RefreshToken { get; set; }
    public string? Scope { get; set; }
    public string? TokenType { get; set; }

    Task RevokeAsync(CancellationToken cancellationToken = default);
    Task RefreshAsync(CancellationToken cancellationToken = default);
    
}