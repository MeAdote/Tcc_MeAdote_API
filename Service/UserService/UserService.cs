// using Tcc_MeAdote_API.Data.Dto;
// using Tcc_MeAdote_API.Repositories.UserLoginRepositories;

// namespace Tcc_MeAdote_API.Service.UserService;

// class UserService : IUserService
// {
//     private readonly IUserLoginRepository _userLoginRepository;
//     public UserService(IUserLoginRepository userLoginRepository)
//     {
//         _userLoginRepository = userLoginRepository;
//     }
//     public AuthUserToken Authenticate(AuthUserDto model)
//     {
//         var salt = _userLoginRepository.GetEmail(model);
        

//     }
// }