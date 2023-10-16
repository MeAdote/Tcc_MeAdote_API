namespace Tcc_MeAdote_API.Data.Dto;

public class AuthUserDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}


public class AuthUserToken
{
    public string Token { get; set; }
}