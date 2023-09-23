﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tcc_MeAdote_API.Data.Dto;
using Tcc_MeAdote_API.Entities.User;
using Tcc_MeAdote_API.Repositories.UserAdressRepositories;
using Tcc_MeAdote_API.Repositories.UserLoginRepositories;
using Tcc_MeAdote_API.Repositories.UserRepository;
using Tcc_MeAdote_API.Security.Cryptography;

namespace Tcc_MeAdote_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IUserAdressRepository _userAdressRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository,
            IUserLoginRepository userLoginRepository,
            IUserAdressRepository userAdressRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userLoginRepository = userLoginRepository;
            _userAdressRepository = userAdressRepository;
            _mapper = mapper;
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
    }
}
