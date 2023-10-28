using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tcc_MeAdote_API.Authorization;
using Tcc_MeAdote_API.Data.Dto;
using Tcc_MeAdote_API.Entities.Pets;
using Tcc_MeAdote_API.Repositories.PetRepository;

namespace Tcc_MeAdote_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public PetController(IPetRepository petRepository,
                IMapper mapper,
                IPetService petService)
        {
            _petRepository = petRepository;
            _mapper = mapper;
            _petService = petService;
        }
        //[Authorize]
        [HttpGet]
        public IActionResult GetPets()
        {
            var pets = _petRepository.GetPets();
            IEnumerable<ReadPetDto> petDto = _mapper.Map<IEnumerable<ReadPetDto>>(pets); 
            return Ok(petDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetPetId(int id)
        {
            var pet = _petService.GetPetById(id);
            return Ok(pet);
        }



        [HttpPost("cadaster")]
        public IActionResult CadasterPet([FromBody] CreatePetDto model)
        {
            try
            {    
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
