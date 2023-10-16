using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Tcc_MeAdote_API.Repositories.UserLoginRepositories;
using Tcc_MeAdote_API.Repositories.UserRepository;

namespace Tcc_MeAdote_API.Authorization;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;
    private readonly IUserRepository _userRepository;

    public JwtMiddleware(RequestDelegate next, 
    IOptions<AppSettings> appSettings,
    IUserRepository userRepository)
    {
        _next = next;
        _appSettings = appSettings.Value;
        _userRepository = userRepository;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if(token != null)
        AttachUserContext(context, token);
    }

    private void AttachUserContext(HttpContext context, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,

                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validateToken);

            var jwtToken = (JwtSecurityToken)validateToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            context.Items["User"] = _userRepository.GetById(userId);
        }
        catch (System.Exception)
        {}
    }
}