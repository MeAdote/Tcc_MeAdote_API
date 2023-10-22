using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tcc_MeAdote_API.Data.Dto;
using Tcc_MeAdote_API.Entities.User;
using Tcc_MeAdote_API.Repositories.UserAdressRepositories;
using Tcc_MeAdote_API.Repositories.UserLoginRepositories;
using Tcc_MeAdote_API.Repositories.UserRepository;
using Tcc_MeAdote_API.Security.Cryptography;
using Tcc_MeAdote_API.Service.UserService;

namespace Tcc_MeAdote_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IUserAdressRepository _userAdressRepository;
        private readonly IUserService _userService;

        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository,
            IUserLoginRepository userLoginRepository,
            IUserAdressRepository userAdressRepository,
            IUserService userService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userLoginRepository = userLoginRepository;
            _userAdressRepository = userAdressRepository;
            _mapper = mapper;
            _userService = userService;
        }
        
        [HttpPost("cadaster")]
        public IActionResult Cadaster([FromBody] CreateUserDto model)
        {
            try
            {
                if (_userLoginRepository.GetEmail(model.UserLogin.Email.ToLower()) != null) return Conflict("Email já Cadastrado");

                User user = _mapper.Map<User>(model.User);
                UserAdress userAdress = _mapper.Map<UserAdress>(model.UserAdress);

                PasswordCrypthografy pc = new PasswordCrypthografy();
                byte[] salt = pc.GenerateSalt();

                UserLogin userLogin = _mapper.Map<UserLogin>(model.UserLogin);
                userLogin.Salt = Convert.ToBase64String(salt);
                userLogin.Password = pc.HashPassword(userLogin.Password, salt);
                userLogin.Email = userLogin.Email.ToLower();


                _userRepository.Add(user, userAdress, userLogin);

                return Ok(new { Message = "Usuário Criado com sucesso" });
            }
            catch (Exception e)
            {
                return BadRequest(new { Message = "Erro ao criar o usuário" });
            }
        }  

        [HttpPost("authenticate")]
        public IActionResult Authentication(UserLoginDto model)
        {
            var token  = _userService.Authenticate(model);
            
            return Ok(token);

        }


        [HttpGet("UsersLogin")]
        public IActionResult GetUsers()
        {
            var list = _userLoginRepository.GetUsers();

            return Ok(list);
        }
    }
}
