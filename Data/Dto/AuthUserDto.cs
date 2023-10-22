using Tcc_MeAdote_API.Entities.User;

namespace Tcc_MeAdote_API.Data.Dto;

public class AuthUserToken
{
    public int Id { get; set; }
    public string Token { get; set; }

    public AuthUserToken(User user, string token)
    {
        Id = user.Id;
        Token = token;
    }
}