using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tcc_MeAdote_API.Authorization;
using Tcc_MeAdote_API.Data.Dto;
using Tcc_MeAdote_API.Entities.User;
using Tcc_MeAdote_API.Repositories.PetRepository;
using Tcc_MeAdote_API.Repositories.UserLoginRepositories;
using Tcc_MeAdote_API.Repositories.UserRepository;
using Tcc_MeAdote_API.Security.Cryptography;

namespace Tcc_MeAdote_API.Service.UserService;

class UserService : IUserService
{
    private readonly IUserLoginRepository _userLoginRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPetRepository _petRepository;
    private readonly AppSettings _appSettings;
    public UserService(IUserLoginRepository userLoginRepository, IOptions<AppSettings> appSettings, IUserRepository userRepository, IPetRepository petRepository)
    {
        _userLoginRepository = userLoginRepository;
        _appSettings = appSettings.Value;
        _userRepository = userRepository;
        _petRepository = petRepository;
    }
    public AuthUserToken Authenticate(UserLoginDto model)
    {
        
        try
        {
            PasswordValidation pc = new();
            var userLogin = _userLoginRepository.GetUserLogin(model);
            
            var validation = pc.Validation(userLogin, model);

            if (!validation)
            {
                return null;
            }

            var user = _userRepository.GetUser(userLogin);
            var token = generateJwtToken(user);

            return new AuthUserToken(user, token);
            
        }
        catch (Exception)
        {
            throw;
        }
    }

    public ReadUserDto GetPetUser(int id)
    {
        var user = _userRepository.GetById(id);
        var pets = _petRepository.GetPetByIdUser(user.Id);
        var userEmail = _userLoginRepository.GetById(user.Id);


        List<PetUserDto> petList = new List<PetUserDto>();

        foreach (var item in pets)
        {
            petList.Add(new PetUserDto
            {
                Name = item.Name,
                PetPicture = item.PetPicture
            });
        }

        ReadUserDto userDto = new ReadUserDto
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Telephone = user.Telephone,
            UserPicture = user.ProfilePicture,
            Email = userEmail.Email,
            PetUsersDto = petList,
            
            
        };

        return userDto;

    }

    private string generateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}