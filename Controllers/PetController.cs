using Microsoft.AspNetCore.Mvc;
using Tcc_MeAdote_API.Repositories.PetRepository;

namespace Tcc_MeAdote_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpGet]
        public IActionResult GetPets()
        {
            var listPets = _petRepository.GetPets();
            return Ok(listPets);
        }
    }
}
