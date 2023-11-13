using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tcc_MeAdote_API.Authorization;
using Tcc_MeAdote_API.Data;
using Tcc_MeAdote_API.Data.Dto;
using Tcc_MeAdote_API.Entities.Pets;
using Tcc_MeAdote_API.Entities.User;
using Tcc_MeAdote_API.Repositories.PetRepository;
using Tcc_MeAdote_API.Service.UserService;

namespace Tcc_MeAdote_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        private readonly IPetService _petService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;


        public PetController(IPetRepository petRepository,
                IMapper mapper,
                IPetService petService,
                IUserService userService
                )
        {
            _petRepository = petRepository;
            _mapper = mapper;
            _petService = petService;
            _userService = userService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetPets()
        {
            var pets = _petRepository.GetPets();
            IEnumerable<ReadPetDto> petDto = _mapper.Map<IEnumerable<ReadPetDto>>(pets); 
            return Ok(petDto);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetPetId(int id)
        {
            var pet = _petService.GetPetById(id);
            return Ok(pet);
        }


        [Authorize]
        [HttpPost("cadaster")]
        public IActionResult CadasterPet([FromBody] CreatePetDto model)
        {
            try
            {
                var userId = _userService.GetUserId();
                model.UserId = userId;
                Pet pet = _mapper.Map<Pet>(model);
                _petRepository.Add(pet);

                return Ok("Pet cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao cadastrar pet");
            }
        }
    }
}
