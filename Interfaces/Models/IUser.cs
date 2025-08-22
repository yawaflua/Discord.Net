using yawaflua.Discord.Net.Entities.Enums;

namespace yawaflua.Discord.Net.Interfaces.Models;

public interface IUser
{
    /// <summary>
    /// 	the user's id
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public string Id { get; set; }
    
    /// <summary>
    /// 	the user's username, not unique across the platform
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public string Username { get; set; }
    
    /// <summary>
    /// 	the user's display name, if it is set. For bots, this is the application name
    /// </summary>
    public string GlobalName { get; set; }
    
    /// <summary>
    /// 	the user's Discord-tag (Obsolete)
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public string Discriminator { get; set; }
    
    /// <summary>
    /// 	the user's avatar hash
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/reference#image-formatting">Image formatting</seealso>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public string? AvatarHash { get; set; }
    
    /// <summary>
    /// the user's banner hash
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/reference#image-formatting">Image formatting</seealso>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    /// <remarks>Available in the User object only if the user has a banner set.</remarks>
    /// <example>https://cdn.discordapp.com/banners/{user.id}/{banner}.png?size=512</example>
    public string? Banner { get; set; }
    
    /// <summary>
    /// whether the user belongs to an OAuth2 application
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public bool? Bot { get; set; }
    
    /// <summary>
    /// whether the user is an Official Discord System user (part of the urgent message system)
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public bool? System { get; set; }
    
    /// <summary>
    /// 	whether the user has two factor enabled on their account
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public bool? MfaEnabled { get; set; }
    
    
    /// <summary>
    /// the user's banner color encoded as an integer representation of hexadecimal color code
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public int? AccentColor { get; set; }
    
    /// <summary>
    /// the user's chosen language option
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public string? Locale { get; set; }
    
    /// <summary>
    /// 	whether the email on this account has been verified
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public bool? Verified { get; set; }
    /// <summary>
    /// 	the user's email
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public string? Email { get; set; }
    
    /// <summary>
    ///     the flags on a user's account
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object-user-flags">User flags</seealso>
    public UserFlag? Flags { get; set; }
    
    /// <summary>
    /// the type of Nitro subscription on a user's account
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public PremiumType? PremiumType { get; set; }
    
    /// <summary>
    /// the public flags on a user's account
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public UserFlag? PublicFlags { get; set; }

    /// <summary>
    /// data for the user's avatar decoration
    /// </summary>
    /// <seealso href="https://discord.com/developers/docs/resources/user#user-object">User-object</seealso>
    public IAvatarDecoration? AvatarDecoration { get; set; }

    public string GetAvatarUrl(int size = 128);
    public string GetBannerUrl(int size = 128);
}